using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject inventoryPanel;

    bool inventoryToggle;
    bool inventoryOpen;

    void Start()
    {
        inventoryToggle = false;
        inventoryOpen = false;
        inventoryPanel.SetActive(false);
    }

    void Update()
    {
        //Inputs
        inventoryToggle = Input.GetKeyDown(KeyCode.Escape);


        //Outputs
        if (!inventoryOpen && inventoryToggle)
        {
            Time.timeScale = 0f;
            inventoryOpen = true;
            inventoryPanel.SetActive(true);
        }
        else if(inventoryOpen && inventoryToggle)
        {
            Time.timeScale = 1f;
            inventoryOpen = false;
            inventoryPanel.SetActive(false);
        }
    }
}
