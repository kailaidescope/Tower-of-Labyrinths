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
        Time.timeScale = 1f;
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
            Debug.Log("hi");
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

    public void Quit(){
        Application.Quit();
        Time.timeScale = 1f;
    }
}
