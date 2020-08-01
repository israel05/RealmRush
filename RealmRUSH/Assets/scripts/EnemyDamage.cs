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
        hitPoints--;
        hitParticlePrefab.Play();
        myAudioSource.PlayOneShot(enemyHitSFX);
    }
        
    /// <summary>
    /// Hay que hacer una instancia o los sonidos y animaciones moriran al morir el objeto
    /// demasiado rápido
    /// </summary>
    
    private void KillEnemy()
    {
        var vfx = Instantiate(deadParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
       // myAudioSource.PlayOneShot(enemyDeathSFX);
        Destroy(vfx.gameObject, vfx.main.duration);
        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
