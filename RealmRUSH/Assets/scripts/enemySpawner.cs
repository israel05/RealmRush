using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class enemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab; //al poner enemyMovement que es un script
    [SerializeField] Transform enemyParentTransfor;
    [SerializeField] Text enemySpawnCounter;
    [SerializeField] AudioClip spawnedEnemySFX;

    int contadorEnemySpawnCounter;
    
    // propio de enemigo, nos eviatamos poner cualquier gameobject que es genérico
        void Start()
    {
        //lanza la corutina
        StartCoroutine(RepeatedlySpawnEnemies());
        enemySpawnCounter.text = contadorEnemySpawnCounter.ToString();


    }



    private IEnumerator RepeatedlySpawnEnemies()
    {
        while (true)
        {
            IncrementoContadorEnemigosEnPantalla();
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity); //spawn el enemigo, en la posicion del enemigo inicial, con rotacion ninguna
            newEnemy.transform.parent = enemyParentTransfor;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void IncrementoContadorEnemigosEnPantalla()
    {
        contadorEnemySpawnCounter++;
        enemySpawnCounter.text = contadorEnemySpawnCounter.ToString();
    }
}
