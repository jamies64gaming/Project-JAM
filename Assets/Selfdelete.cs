using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selfdelete : MonoBehaviour
{
    Transform wave;
    // Start is called before the first frame update
    void Start()
    {
        wave = GameObject.Find("wave").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(wave.position.z > transform.position.z + 10)
        {
            Destroy(gameObject);
        }
    }
}
