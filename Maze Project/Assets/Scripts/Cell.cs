using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    Cell[] around;
    bool hasEnemy;
    float enemyID;
    float enemyChance;
    bool hasItem;
    float itemChance;
    Item item;
    bool hasChest;
    bool visited;
    float x;
    float z;

    public Cell(float a, float b)
    {
        around = new Cell[4];
        visited = false;
        hasChest = false;
        enemyChance = 0.1f;
        itemChance = 0.1f;
        x = a;
        z = b;

        //float dist = Mathf.Sqrt(Mathf.Pow(a,2) + Mathf.Pow(b,2));
        float rand = Random.Range(0f, 1f);
        if (rand < enemyChance && x > 2f && z > 2f)
        {
            hasEnemy = true;
        }
        else
        {
            hasEnemy = false;
        }

        rand = Random.Range(0f, 1f);
        if (!hasEnemy && rand < itemChance)
        {
            hasItem = true;
            item = new Item("Coin", 1);
        }
        else
        {
            hasItem = false;
        }
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

    public float GetEnemyID()
    {
        if (hasEnemy)
        {
            return enemyID;
        }
        else
        {
            return -1;
        }
    }

    public void SetHasEnemy(bool b)
    {
        hasEnemy = b;
    }

    public bool GetHasEnemy()
    {
        return hasEnemy;
    }

    public void SetHasItem(bool b)
    {
        hasItem = b;
    }

    public bool GetHasItem()
    {
        return hasItem;
    }

    public Item GetItem()
    {
        return item;
    }

    public void SetHasChest(bool b)
    {
        hasChest = b;
        hasItem = !b;
    }

    public bool GetHasChest()
    {
        return hasChest;
    }
}
