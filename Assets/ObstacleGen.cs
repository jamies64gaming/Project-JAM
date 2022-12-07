using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGen : MonoBehaviour
{
    [SerializeField] private List<GameObject> items = new List<GameObject>();

    public int ItemNo;
    // Start is called before the first frame update
    void Start()
    {
        ItemNo = Random.Range(0, items.Count);

        Instantiate(items[ItemNo], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
