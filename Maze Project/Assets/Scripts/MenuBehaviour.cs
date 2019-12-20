using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject inventoryPanel;

    bool inventoryOpen;

    void Start()
    {
        inventoryOpen = false;
        inventoryPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inventoryOpen = !inventoryOpen;
        }
    }

    private void FixedUpdate()
    {
        if (inventoryOpen)
        {
            Time.timeScale = 0f;
            inventoryPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            inventoryPanel.SetActive(false);
        }
    }
}
