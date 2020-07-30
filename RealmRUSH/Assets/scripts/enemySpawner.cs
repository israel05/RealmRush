using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab; //al poner enemyMovement que es un script
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
            print("Creando enemigo");
            yield return new WaitForSeconds(secondsBetweenSpawns); 
        }               
    }



}
