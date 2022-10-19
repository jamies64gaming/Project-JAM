using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject placeholder;

    public int steps = 10;

    public int spacing = 20;

    Vector3 startingPos = new Vector3(0,0,0);
    Vector3 currentPos;
    Vector3 nextPos;

    Vector3 rotation;

    List<Vector3> positions = new List<Vector3>();
    List<Vector3> rotations = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        currentPos = startingPos;
        for (int i = 0; i < steps; i++)
        {
            Direction();
        }
        for(int i = 0; i < positions.Count; i++)
        {
            placeholder.name = i.ToString();

            Instantiate(placeholder ,positions[i], Quaternion.Euler(rotations[i]));
        }
    }


    void Direction()
    {
        int breakpoint = 0;
        bool valid = false;
        while (!valid && breakpoint != 10)
        {
            int D = Random.Range(0, 3);
            if (D == 0)
            {
                nextPos = currentPos + new Vector3(spacing, 0, 0);
                rotation = new Vector3(0, 0, 0);
            }
            else if (D == 1)
            {
                nextPos = currentPos + new Vector3(0, 0, -spacing);
                rotation = new Vector3(0, 90, 0);
            }
            else
            {
                nextPos = currentPos + new Vector3(0, 0, spacing);
                rotation = new Vector3(0, 90, 0);
            }

            for (int i = 0; i < positions.Count; i++)
            {
                if(positions[i] == nextPos)
                {
                    valid = false;
                    break; 
                }
                valid = true;
            }
            breakpoint++;
        }
        Debug.Log(breakpoint);
        positions.Add(nextPos);
        rotations.Add(rotation);
        currentPos = nextPos;
    }

}
