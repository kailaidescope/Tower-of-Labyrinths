using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float time;

    List<Item> inventory = new List<Item>();

    void Start()
    {
        time = 0f;
        inventory.Add(new Item("Coin", 0));
    }

    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
    }

    public float GetTimerTime()
    {
        return time;
    }

    public void AddItem(Item i)
    {
        foreach(Item I in inventory)
        {
            if(I.GetName() == i.GetName())
            {
                I.Add(i.GetCount());
                return;
            }
        }

        inventory.Add(i);
    }

    public int GetCoinNum()
    {
        foreach(Item I in inventory)
        {
            if(I.GetName() == "Coin")
            {
                return I.GetCount();
            }
        }

        return -1;
    }
}
