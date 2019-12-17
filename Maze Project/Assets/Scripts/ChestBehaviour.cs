using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehaviour : MonoBehaviour
{
    private Chest chest;

    private static GameObject menu;

    private void Awake()
    {
        chest = new Chest();
        menu = GameObject.Find("Menu");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            menu.GetComponent<MenuBehaviour>().OpenChestUI(other.gameObject, chest);
            Destroy(gameObject);
        }
    }
}
