using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;
    // Start is called before the first frame update
    [SerializeField] AudioClip playerDamageSFX;


    private void Start()
    {
        healthText.text = health.ToString();
    
    }

    private void OnTriggerEnter(Collider other)
    {
        health -= healthDecrease;
        healthText.text = health.ToString();
        //suna el golpe en la base
        GetComponent<AudioSource>().PlayOneShot(playerDamageSFX);


    }
}
