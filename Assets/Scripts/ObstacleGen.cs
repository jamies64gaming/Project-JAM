using System.Collections.Generic;
using UnityEngine;

public class ObstacleGen : MonoBehaviour
{
    MapGenerator manager;

    public int ItemNo;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<MapGenerator>();
        List<GameObject> items = manager.items;
        float chanceOfObjSpawn = manager.chanceOfObjSpawn;
        float spawnPercentage = Random.Range(0, 100);

        if (spawnPercentage <= chanceOfObjSpawn)
        {

            ItemNo = Random.Range(0, items.Count);

            Instantiate(items[ItemNo], transform.position, transform.rotation);
        }
    }
}
