using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    Transform car;
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("Prometheus").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0,-1,car.position.z);
    }
}
