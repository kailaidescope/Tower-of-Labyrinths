using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    string name;
    int count;

    public Item(string n, int c)
    {
        name = n;
        count = c;
    }

    public void Add(int c)
    {
        count += c;
    }

    public int GetCount()
    {
        return count;
    }

    public string GetName()
    {
        return name;
    }
}
