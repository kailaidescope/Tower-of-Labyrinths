using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    Cell[] around;
    bool visited;
    float x;
    float z;

    public Cell(float a, float b)
    {
        around = new Cell[4];
        visited = false;
        x = a;
        z = b;
    }

    public void SetVisited(bool b)
    {
        visited = b;
    }

    public bool GetVisited()
    {
        return visited;
    }

    public void SetAround(Cell[] a)
    {
        around = a;
    }

    public Cell[] GetAround()
    {
        return around;
    }

    public float[] GetPos()
    {
        return new float[2] { x, z };
    }
}
