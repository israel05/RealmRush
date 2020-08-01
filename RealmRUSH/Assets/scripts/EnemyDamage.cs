using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab, deadParticlePrefab;
  
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints < 0)
        {
            KillEnemy();
        }
    }
       

    void ProcessHit()
    {
        hitPoints--;
        hitParticlePrefab.Play();
    }
        
    private void KillEnemy()
    {
        var vfx = Instantiate(deadParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }
}
