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
        menu = null;
        menu = GameObject.Find("ChestPanel");
    }

    private void Start()
    {
        menu.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OpenUI(other.gameObject);
            Destroy(gameObject);
        }
    }

    public void OpenUI(GameObject obj)
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        for(int i = 0;i< menu.gameObject.transform.childCount; i++)
        {
            if(menu.gameObject.transform.GetChild(i).name == "ItemDisplay")
            {
                menu.gameObject.transform.GetChild(i).GetComponent<UnityEngine.UI.Text>().text = chest.GetItem().ToString();
                obj.GetComponent<PlayerBehaviour>().AddItem(chest.GetItem());
                return;
            }
        }
    }

    public void CloseUI()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
    }
}
