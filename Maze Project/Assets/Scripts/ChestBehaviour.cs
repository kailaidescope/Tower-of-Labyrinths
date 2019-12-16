using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehaviour : MonoBehaviour
{

    [SerializeField] private string name;
    [SerializeField] private int count;

    private static GameObject menu;

    private void Start()
    {
        menu = GameObject.Find("ChestPanel");
        CloseUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OpenUI();
            other.gameObject.GetComponent<PlayerBehaviour>().AddItem(new Item(name, count));
            Destroy(gameObject);
        }
    }

    public static void OpenUI()
    {

    }

    public static void CloseUI()
    {
        menu.SetActive(false);
    }
}
