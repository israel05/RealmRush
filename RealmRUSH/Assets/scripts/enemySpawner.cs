using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab; //al poner enemyMovement que es un script
    [SerializeField] Transform enemyParentTransfor;

    // propio de enemigo, nos eviatamos poner cualquier gameobject que es genérico

    void Start()
    {
        //lanza la corutina
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    private IEnumerator RepeatedlySpawnEnemies()
    {
        while (true)
        {
           

            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity); //spawn el enemigo, en la posicion del enemigo inicial, con rotacion ninguna
            newEnemy.transform.parent = enemyParentTransfor;
            yield return new WaitForSeconds(secondsBetweenSpawns); 
        }               
    }



}
