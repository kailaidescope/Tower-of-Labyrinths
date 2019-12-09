using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    Cell[,] cells;
    List<Wall> walls;
    Stack<Cell> cStack;


    public void GenerateGrid(int h, int w)
    {
        cells = new Cell[h, w];
        walls = new List<Wall>();
        cStack = new Stack<Cell>();

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
                    c[0] = cells[i + 1, j];
                }
                if (j > 0)
                {
                    c[0] = cells[i, j - 1];
                }
                if (j < w - 1)
                {
                    c[0] = cells[i, j + 1];
                }

                cells[i, j].SetAround(c);
            }
        }

        for (int i = 0; i < h; i++)
        {
            for (int j = i % 2; j + 2 < w; j += 2)
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

        cStack.Push(cells[0, 0]);
    }

    public void CarveGrid()
    { 
        if(cStack.Count > 0)
        {
            Cell currentCell = cStack.Pop();

            foreach (Cell c in currentCell.GetAround())
            {
                if (c != null && !c.GetVisited())
                {
                    RemoveWall(c, currentCell);
                    c.SetVisited(true);
                    cStack.Push(c);
                    CarveGrid();
                }
            }
        }
    }

    public void RemoveWall(Cell a, Cell b)
    {
        for(int i = 0; i < walls.Count; i++)
        {
            if(new Cell[2] {a, b} == walls[i].GetCells() || new Cell[2] {b, a} == walls[i].GetCells())
            {
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
            }
        }
    }

    void Start()
    {
        GenerateGrid(10, 10);
        CarveGrid();

        SpawnMaze();
    }

    void Update()
    {
        
    }
}
