using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeWallsGenerator : MonoBehaviour
{
    [SerializeField] private GameObject plane;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject emptyPrefab;

    private bool[,] walls;
    private string[] directions;
    private string[] directions2;
    private string nextDirection;
    private float xLen;
    private float zLen;

    // Start is called before the first frame update
    void Start()
    {
        xLen = plane.transform.localScale.x * 10f;
        zLen = plane.transform.localScale.z * 10f;

        walls = new bool[(int)xLen, (int)zLen];
        directions = new string[]{"down", "right", "down", "right", "both"};
        directions2 = new string[] { "down", "right", "up", "left", "neither", "neither", "neither" };

        walls[0, 0] = true;
        //walls[x, z] = (Random.value > 0.5f);

        for (int x = 0; x < (int)xLen-1; x++)
        {
            for (int z = 0; z < (int)zLen-1; z++)
            {
                if (walls[x, z])
                {
                    nextDirection = directions[Random.Range(0,directions.Length)];
                    if(nextDirection == "down")
                    {
                        walls[x + 1, z] = true;
                    }
                    if (nextDirection == "right")
                    {
                        walls[x, z + 1] = true;
                    }
                    if (nextDirection == "both")
                    {
                        walls[x + 1, z] = true;
                        walls[x, z + 1] = true;
                    }
                }
            }
        }

        for (int x = 1; x < (int)xLen - 1; x++)
        {
            for (int z = 1; z < (int)zLen - 1; z++)
            {
                if (walls[x, z])
                {
                    nextDirection = directions[Random.Range(0, directions2.Length)];
                    if (nextDirection == "down")
                    {
                        walls[x + 1, z] = true;
                    }
                    if (nextDirection == "right")
                    {
                        walls[x, z + 1] = true;
                    }
                    if (nextDirection == "up")
                    {
                        walls[x - 1, z] = true;
                    }
                    if (nextDirection == "right")
                    {
                        walls[x, z - 1] = true;
                    }
                }
            }
        }

        for (int x = 0; x < (int)xLen; x++)
        {
            for(int z = 0; z < (int)zLen; z++)
            {
                if (walls[x, z])
                {
                    GameObject wall = Instantiate(emptyPrefab);
                    wall.transform.position = new Vector3((float)x + 0.5f, 0.5f, (float)z + 0.5f);
                    wall.transform.parent = plane.transform;
                }
                else
                {
                    GameObject wall = Instantiate(wallPrefab);
                    wall.transform.position = new Vector3((float)x + 0.5f, 0.5f, (float)z + 0.5f);
                    wall.transform.parent = plane.transform;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
