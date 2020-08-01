using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab, deadParticlePrefab;
    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDeathSFX;
    AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

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
        myAudioSource.PlayOneShot(enemyHitSFX);
        hitPoints--;
        hitParticlePrefab.Play();
    }
        
    private void KillEnemy()
    {
        var vfx = Instantiate(deadParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
       // myAudioSource.PlayOneShot(enemyDeathSFX);
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }
}
