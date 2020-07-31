using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    // Parámetros
    [SerializeField] Transform objectToPan;
    [SerializeField] float range = 10f;
    [SerializeField] ParticleSystem projectileParticle;

    //Estado // para que cambie segund el enemigo
    [SerializeField] Transform targetEnemy;

    void Update()
    {
        setTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();

        } else
        {
            Shoot(false);
        }


    }

    private void setTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>(); //todos los objetos que tengan el script EnemyDamage
        if (sceneEnemies.Length == 0 ) { return; } // si no hay enemigos,vuelve
        Transform closestEnemy = sceneEnemies[0].transform;
        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transform.position, transformA.position);
        var distToB = Vector3.Distance(transform.position, transformB.position);
        if (distToA < distToB)
        {
            return transformA;
        }
        return transformB;
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
     //   print("distancia hasta el enemigo :" + distanceToEnemy);
        if (distanceToEnemy <= range)
        {
            Shoot(true);
        } else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
