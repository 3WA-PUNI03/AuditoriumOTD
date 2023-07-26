using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{

    int _particleCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.gameObject.CompareTag("Particle") == false) return;

        _particleCount++;



        // Methode 2
        //if (collision.attachedRigidbody.gameObject.CompareTag("Particle") == true)
        //{
        //    _particleCount++;
        //}


    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.gameObject.CompareTag("Particle") == false) return;
        _particleCount--;
    }

}
