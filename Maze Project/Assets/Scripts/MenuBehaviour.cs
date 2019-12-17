using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject ChestUI;
    [SerializeField] private GameObject InventoryUI;

    void Start()
    {
        ChestUI.SetActive(false);
        InventoryUI.SetActive(false);
    }

    void Update()
    {
        
    }

    public void OpenChestUI(GameObject obj, Chest chest)
    {
        ChestUI.SetActive(true);
        Time.timeScale = 0f;
        for (int i = 0; i < ChestUI.gameObject.transform.childCount; i++)
        {
            if (ChestUI.gameObject.transform.GetChild(i).name == "ItemDisplay")
            {
                ChestUI.gameObject.transform.GetChild(i).GetComponent<UnityEngine.UI.Text>().text = chest.GetItem().ToString();
                obj.GetComponent<PlayerBehaviour>().AddItem(chest.GetItem());
                return;
            }
        }
    }

    public void CloseChestUI()
    {
        Time.timeScale = 1;
        ChestUI.SetActive(false);
    }

    public void OpenInventoryUI()
    {
        InventoryUI.SetActive(true);
        Time.timeScale = 0f;

    }
}
