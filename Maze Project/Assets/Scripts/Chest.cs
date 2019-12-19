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

    public Chest()
    {
        item = new Item("Coin", Random.Range(1,6));
    }

    public Item GetItem()
    {
        return item;
    }
}
