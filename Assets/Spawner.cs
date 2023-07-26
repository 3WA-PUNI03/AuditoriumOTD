using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    [SerializeField] float _fireRate;

    private void Start()
    {
        //Invoke(nameof(SpawnParticle), _fireRate);
        //Invoke("SpawnParticle", _fireRate);
        //CancelInvoke("SpawnParticle");
        InvokeRepeating("SpawnParticle", 0f, _fireRate);

        //Coroutine
        //StartCoroutine(SpawnRoutine());
    }

    void SpawnParticle()
    {
        //Vector3 randomDirection = new Vector2( Random.Range(-1f, 1f), Random.Range(-1f, 1f) );
        Vector3 randomDirection = Random.insideUnitCircle;
        Vector3 destination = transform.position + randomDirection;
        Instantiate(_prefab, destination, transform.rotation);

        //Invoke("SpawnParticle", _fireRate);
    }


    // Version coroutine()
    IEnumerator SpawnRoutine()
    {
        while(true)
        {
            SpawnParticle();
            yield return new WaitForSeconds(_fireRate);
        }
    }

}
