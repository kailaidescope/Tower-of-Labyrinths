using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall
{
    Cell[] cells;
    bool active;

    public Wall(Cell[] c)
    {
        cells = c;
        active = true;
    }

    public void SetActive(bool b)
    {
        active = b;
    }

    public bool GetActive()
    {
        return active;
    }

    public Cell[] GetCells()
    {
        return cells;
    }
}
