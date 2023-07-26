using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicBox : MonoBehaviour
{
    [SerializeField] int _validationThreshold;
    [SerializeField] float _objectiveTime;
    [SerializeField] AudioSource _audio;


    [Header("DEBUG")]
    [Header("Le nombre de particule dans la zone")]
    [SerializeField] int _particleCount;
    [Header("Le nombre de secondes où l'objectif a été validé")]
    [SerializeField] float _currentTime;
    [Header("Le taux de complétion du niveau entre 0 et 1 (0% => 100%)")]
    [SerializeField] float _currentPercentage;


    private void Update()
    {
        UpdateCompletion();

        CompletionTest();
    }

    private void CompletionTest()
    {
        // Victoire : si la complétion a dépassé XX secondes
        if (_currentTime > _objectiveTime)
        {
            Debug.Log("WIN");
            //SceneManager.LoadScene("WinScreen");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void UpdateCompletion()
    {
        // Threshold 
        if (_particleCount >= _validationThreshold)
        {
            _currentTime += Time.deltaTime;
        }
        else
        {
            _currentTime -= Time.deltaTime;
            if (_currentTime < 0)
            {
                _currentTime = 0;
            }
        }

        _currentPercentage = _currentTime / _objectiveTime;
        _audio.volume = _currentPercentage;
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
