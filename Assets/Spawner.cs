using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject _prefab;


    private void Update()
    {

        //Vector3 randomDirection = new Vector2( Random.Range(-1f, 1f), Random.Range(-1f, 1f) );
        
        Vector3 randomDirection = Random.insideUnitCircle;

        Vector3 destination = transform.position + randomDirection;

        Instantiate(_prefab, destination, transform.rotation);

    }



}
