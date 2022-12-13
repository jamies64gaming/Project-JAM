using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour
{

    [Header("car settings")]
    public GameObject car;
    public GameObject prom;

    [Header("road settings")]
    public GameObject straightRoad;
    public List<GameObject> obstacles;

    public int steps = 10;

    public int spacing = 20;

    [Header("obstacle settings")]
    [Range(0, 100)]
    public float chanceOfObjSpawn;
    public List<GameObject> items = new List<GameObject>();


    Vector3 startingPos = new Vector3(0, 0, 0);
    Vector3 currentPos;
    Vector3 nextPos;
    string direction;


    Vector3 rotation;

    List<Vector3> positions = new List<Vector3>();
    List<Vector3> rotations = new List<Vector3>();
    List<string> directions = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        currentPos = startingPos;
        for (int i = 0; i < steps; i++)
        {
            Direction();
        }
        car.transform.position = positions[0];
    }


    void Direction()
    {

        nextPos = currentPos + new Vector3(0, 0, spacing);

        positions.Add(nextPos);
        //Debug.Log(nextPos);
        PlaceRoad(nextPos);
    }

    void PlaceRoad(Vector3 pos)
    {
        if (positions.Count % 5 == 0)
        {
            GameObject obs = obstacles[Random.Range(0, obstacles.Count)];
            currentPos = currentPos + obs.transform.Find("last").transform.position;
            Vector3 rot;
            if (obs.name == "obs1")
            {
                rot = new Vector3(0, 180, 0);
            }
            else
            {
                rot = new Vector3(0, 0, 0);
            }
            Instantiate(obs, pos, Quaternion.Euler(rot));
        }
        else
        {
            straightRoad.name = currentPos.ToString();
            Instantiate(straightRoad, pos, Quaternion.Euler(0, 0, 0));
            currentPos = nextPos;
        }
    }

    public void SpawnMore()
    {
        for (int i = 0; i < steps; i++)
        {
            Direction();
        }
        //Debug.Log("exec");
    }

    private void Update()
    {
        Death();
    }

    void Death()
    {
        if (Mathf.RoundToInt(prom.GetComponent<PrometeoCarController>().carSpeed) == 0)
        {
            //Debug.Log("Dead in the water");
        }
        // Debug.Log(Mathf.RoundToInt(prom.GetComponent<PrometeoCarController>().carSpeed));

    }

}
