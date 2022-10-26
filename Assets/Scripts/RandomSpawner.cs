using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform plane;
    public int density;
    public List<GameObject> gameObjects = new List<GameObject>();

    // Plane Properties
    float x_dim;
    float z_dim;

    void Start()
    {
        // Get the length and width of the plane
        x_dim = plane.GetComponent<MeshRenderer>().bounds.size.x;
        z_dim = plane.GetComponent<MeshRenderer>().bounds.size.z;
        x_dim /= 2;
        z_dim /= 2;

        for(int i = 0; i < density; i++)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        // Spawn the object as a child of the plane. This will solve any rotation issues
        GameObject obj = Instantiate(gameObjects[Random.Range(0,gameObjects.Count-1)], plane.localPosition,
         Quaternion.identity, plane) as GameObject;

        /* Move the object to where you want withing in the dimensions of the plane */
        // random the x and z position between bounds
        var x_rand = Random.Range(-x_dim, x_dim);
        var z_rand = Random.Range(-z_dim, z_dim);

        float y_rot = Random.Range(0, 360);
        // Random the y position from the smallest bewteen x and z
        //z_rand = x_rand > z_rand ? Random.Range(0, z_rand) : Random.Range(0, x_rand);

        // Now move the object
        // Since the object is a child of the plane it will automatically handle rotational offset
        obj.transform.position = new Vector3(x_rand, 0, z_rand) + plane.position;
        obj.transform.localRotation = Quaternion.Euler(0, y_rot, 0);

        // Now unassign the parent
        obj.transform.parent = null;
        obj.transform.localScale = new Vector3(1,1,1);
    }
}