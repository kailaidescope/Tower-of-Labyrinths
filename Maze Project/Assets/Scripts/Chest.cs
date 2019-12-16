using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest
{
    Item item;

    public Chest(Item i)
    {
        item = i;
    }

    public Item GetItem()
    {
        return item;
    }
}
