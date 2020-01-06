using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Cell[,] cells;
    List<Wall> walls;
    float[] pos;
    Cell currentCell;

    float time;
    float moveTime;

    void Start()
    {
        time = 0f;
        moveTime = 5f;

        pos = new float[] { transform.position.x, transform.position.z };
        cells = GameObject.Find("MazeGenerator").GetComponent<MazeGenerator>().GetGrid();
        walls = GameObject.Find("MazeGenerator").GetComponent<MazeGenerator>().GetWalls();
        foreach (Cell c in cells)
        {
            if(c.GetPos() == pos)
            {
                currentCell = c;
                break;
            }
        }

    }

    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        if(time >= moveTime)
        {
            //if (currentCell.GetAround()[0] != null)
            //{
                //transform.position = new Vector3(currentCell.GetAround()[0].GetPos()[0], transform.position.y, currentCell.GetAround()[0].GetPos()[1]);
            //}
            time = 0f;
        }
    }
}
