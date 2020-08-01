using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        health = health - healthDecrease;

        if (health < 1)
        {
            Destroy(gameObject);
        }        
    }
}
