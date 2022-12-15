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

    [SerializeField] GameObject wastedUI;
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
            pos += new Vector3(0, 0, 3 * speed * Time.deltaTime);
        }
        transform.position = pos; 

        speed += Time.deltaTime / 100;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Prometheus")
        {
            Time.timeScale = .1f;
            Invoke("StopTime", 1);
            wastedUI.SetActive(true);
            PlayerPrefs.SetInt("Alive", 0);
            
        }
         
    }
    
    void StopTime()
    {
        Time.timeScale = 0;
    }

    private void OnCollisionExit(Collision collision)
    {
        Destroy(collision.gameObject);
    }

}
