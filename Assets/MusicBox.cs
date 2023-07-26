using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    [SerializeField] int _validationThreshold;
    int _particleCount;

    float _completion;      // 0f  ==>   1f

    private void Update()
    {
        // Threshold 
        if(_particleCount > _validationThreshold)
        {
            _completion += Time.deltaTime;
        }

        // Victoire : si la complétion a dépassé XX secondes




    }

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
