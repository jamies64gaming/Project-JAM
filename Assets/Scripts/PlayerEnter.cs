using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnter : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        Transform gamemanager = GameObject.FindGameObjectWithTag("GameController").transform;
        gamemanager.GetComponent<MapGenerator>().SpawnMore();

    }
}
