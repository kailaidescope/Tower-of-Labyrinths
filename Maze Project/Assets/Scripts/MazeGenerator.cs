using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private Vector2 size;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject corner;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject chest;
    [SerializeField] private GameObject exit;
    [SerializeField] private GameObject plane;
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
            for (int j = i % 2; j < w; j += 2)
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

        foreach (Cell c in clls)
        {
            if (c != null && !c.GetVisited())
            {
                RemoveWall(c, currentCell);
                c.SetVisited(true);
                CarveGrid(c);
            }
        }
    }

    public void RemoveWall(Cell a, Cell b)
    {
        for (int i = 0; i < walls.Count; i++)
        {
            if ((a == walls[i].GetCells()[0] && b == walls[i].GetCells()[1]) || (a == walls[i].GetCells()[1] && b == walls[i].GetCells()[0]))
            {
                walls[i].SetActive(false);
            }
        }
    }

    public void RemoveRandomWall()
    {
        foreach (Wall w in walls)
        {
            float rand = Random.Range(0f, 1f);
            if (rand < 0.01f)
            {
                w.SetActive(false);
            }
        }
    }

    public void SpawnMaze()
    {
        GameObject par = new GameObject("walls");
        par.transform.position = new Vector3(0f, 0f, 0f);

        foreach (Wall w in walls)
        {
            if (w.GetActive())
            {
                float x = (w.GetCells()[0].GetPos()[0] + w.GetCells()[1].GetPos()[0]) / 2;
                float z = (w.GetCells()[0].GetPos()[1] + w.GetCells()[1].GetPos()[1]) / 2;
                GameObject obj = Instantiate(wall);
                obj.transform.position = new Vector3(x, 0.5f, z);
                if (w.GetCells()[0].GetPos()[1] == w.GetCells()[1].GetPos()[1])
                {
                    obj.transform.eulerAngles = new Vector3(0, 180f, 0);
                }
                else
                {

                }
                obj.transform.parent = par.transform;
            }
        }

        foreach (Cell c in cells)
        {
            int i = 0;

            foreach (Wall w in walls)
            {
                if (w.GetCells()[0] == c || w.GetCells()[1] == c)
                {
                    if (w.GetActive())
                    {
                        i++;
                    }
                }
            }

            if (i == 3)
            {
                c.SetHasChest(true);
                c.SetHasEnemy(false);
                c.SetHasItem(false);
            }
        }

        foreach (Cell c in cells)
        {
            if (c.GetPos()[0] == 0.5f && c.GetPos()[1] == 0.5f)
            {
                c.SetHasChest(false);
                c.SetHasEnemy(false);
                c.SetHasItem(false);
            }
        }

        for (int i = 0; i < size.x; i++)
        {
            GameObject obj = Instantiate(wall);
            obj.transform.position = new Vector3(i + 0.5f, 0.5f, 0);
            obj.transform.parent = par.transform;
            GameObject obj2 = Instantiate(wall);
            obj2.transform.position = new Vector3(i + 0.5f, 0.5f, size.y);
            obj2.transform.parent = par.transform;
        }
        for (int i = 0; i < size.y; i++)
        {
            GameObject obj = Instantiate(wall);
            obj.transform.position = new Vector3(0, 0.5f, i + 0.5f);
            obj.transform.eulerAngles = new Vector3(0, 180f, 0);
            obj.transform.parent = par.transform;
            GameObject obj2 = Instantiate(wall);
            obj2.transform.position = new Vector3(size.x, 0.5f, i + 0.5f);
            obj2.transform.eulerAngles = new Vector3(0, 180f, 0);
            obj2.transform.parent = par.transform;
        }
        for (int i = 0; i < size.x + 1; i++)
        {
            for (int j = 0; j < size.y + 1; j++)
            {
                GameObject obj = Instantiate(corner);
                obj.transform.position = new Vector3(i, 0.5f, j);
                obj.transform.parent = par.transform;
            }
        }

        GameObject enemies = new GameObject("enemies");
        enemies.transform.position = new Vector3(0f, 0f, 0f);

        GameObject items = new GameObject("items");
        enemies.transform.position = new Vector3(0f, 0f, 0f);

        foreach (Cell c in cells)
        {
            if (c.GetHasEnemy())
            {
                GameObject obj = Instantiate(enemy);
                obj.transform.position = new Vector3(c.GetPos()[0], 0.5f, c.GetPos()[1]);
                obj.transform.parent = enemies.transform;
            }
            if (c.GetHasItem())
            {
                GameObject obj = null;
                if (c.GetItem().GetName() == "Coin")
                {
                    obj = Instantiate(coin);
                    obj.transform.position = new Vector3(c.GetPos()[0], 0.5f, c.GetPos()[1]);
                }
                obj.transform.parent = items.transform;
            }
            if (c.GetHasChest())
            {
                GameObject obj = Instantiate(chest);
                obj.transform.position = new Vector3(c.GetPos()[0], 0.25f, c.GetPos()[1]);
                obj.transform.parent = items.transform;
            }
        }

        GameObject o = Instantiate(exit);
        o.transform.position = new Vector3(size.x - 0.5f, 0.5f, size.y - 0.5f);
        o.transform.parent = par.transform;
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
        CarveGrid(cells[0, 0]);
        RemoveRandomWall();

        plane.transform.localScale = new Vector3(size.x / 10f, 1, size.y / 10f);
        plane.transform.position = new Vector3(size.x / 2, 0, size.y / 2);

        SpawnMaze();
    }

    void Update()
    {

    }

    public Cell[,] GetGrid()
    {
        return cells;
    }

    public List<Wall> GetWalls()
    {
        return walls;
    }
}
