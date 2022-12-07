using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float carDist;
    public Transform car;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        //Debug.Log(car.position.z - pos.z);
        if (car.position.z - pos.z <= carDist+1)
        {
            pos += new Vector3(0, 0, speed * Time.deltaTime);
        }
        else
        {
            pos = car.position - new Vector3(0, -4, carDist);
        }
        transform.position = pos; 

        speed += Time.deltaTime / 100;
    }
    
}
