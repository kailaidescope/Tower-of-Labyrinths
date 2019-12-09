using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private Vector2 size;
    [SerializeField] private GameObject wall;
    Cell[,] cells;
    List<Wall> walls;


    public void GenerateGrid(int h, int w)
    {
        cells = new Cell[h, w];
        walls = new List<Wall>();

        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                cells[i, j] = new Cell(i + 0.5f, j + 0.5f);
            }
        }

        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                Cell[] c = new Cell[4];

                if (i > 0)
                {
                    c[0] = cells[i - 1, j];
                }
                if (i < h - 1)
                {
                    c[1] = cells[i + 1, j];
                }
                if (j > 0)
                {
                    c[2] = cells[i, j - 1];
                }
                if (j < w - 1)
                {
                    c[3] = cells[i, j + 1];
                }

                cells[i, j].SetAround(c);
            }
        }

        for (int i = 0; i < h; i++)
        {
            for (int j = i%2; j + 2 < w; j += 2)
            {
                Cell[] c = cells[i, j].GetAround();
                foreach (Cell v in c)
                {
                    if (v != null)
                    {
                        walls.Add(new Wall(new Cell[2] { v, cells[i, j] }));
                    }
                }
            }
        }
    }

    public void CarveGrid(Cell currentCell)
    {
        List<Cell> clls = new List<Cell>(currentCell.GetAround());
        Shuffle(clls);

        foreach(Cell c in clls)
        {
            if(c != null && !c.GetVisited())
            {
                RemoveWall(c, currentCell);
                c.SetVisited(true);
                CarveGrid(c);
            }
        }
    }

    public void RemoveWall(Cell a, Cell b)
    {
        Debug.Log("1");
        for(int i = 0; i < walls.Count; i++)
        {
            if((a == walls[i].GetCells()[0] && b == walls[i].GetCells()[1]) || (a == walls[i].GetCells()[1] && b == walls[i].GetCells()[0]))
            {
                Debug.Log("2");
                walls[i].SetActive(false);
            }
        }
    }

    public void SpawnMaze()
    {
        foreach(Wall w in walls)
        {
            if (w.GetActive())
            {
                float x = (w.GetCells()[0].GetPos()[0] + w.GetCells()[1].GetPos()[0]) / 2;
                float z = (w.GetCells()[0].GetPos()[1] + w.GetCells()[1].GetPos()[1]) / 2;
                GameObject obj = Instantiate(wall);
                obj.transform.position = new Vector3(x, 0.5f, z);
                if(w.GetCells()[0].GetPos()[1] == w.GetCells()[1].GetPos()[1])
                {
                    obj.transform.eulerAngles = new Vector3(0, 180f, 0);
                }
                else
                {
                    
                }
            }
        }
    }

    public void Shuffle<Cell>(List<Cell> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = (int)Random.Range(0, n + 1);
            Cell value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    void Start()
    {
        GenerateGrid((int)size.x, (int)size.y);
        CarveGrid(cells[0,0]);
        
        foreach(Wall w in walls)
        {
            Debug.Log(w.GetActive());
        }

        SpawnMaze();
    }

    void Update()
    {
        
    }
}
