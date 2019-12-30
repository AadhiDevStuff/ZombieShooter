using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
           if(this.CompareTag("AmmoBox"))
           {
                other.GetComponent<Shoot>().totalBullets += 10;
           }

            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("Pickup");
        }

    }
}
