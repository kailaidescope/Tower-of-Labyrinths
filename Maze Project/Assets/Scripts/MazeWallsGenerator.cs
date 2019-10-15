using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeWallsGenerator : MonoBehaviour
{
    [SerializeField] private GameObject plane;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject emptyPrefab;

    private bool[,] walls;
    private float xLen;
    private float zLen;

    // Start is called before the first frame update
    void Start()
    {
        xLen = plane.transform.localScale.x * 10f;
        zLen = plane.transform.localScale.z * 10f;

        walls = new bool[(int)xLen, (int)zLen];

        for(int x = 0; x < (int)xLen; x++)
        {
            for(int z = 0; z < (int)zLen; z++)
            {
                walls[x, z] = (Random.value > 0.5f);
                if (walls[x, z])
                {
                    Instantiate(wallPrefab).transform.position = new Vector3((float)x + 0.5f, 0.5f, (float)z + 0.5f);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
