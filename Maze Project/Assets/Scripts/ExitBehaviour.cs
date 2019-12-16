using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBehaviour : MonoBehaviour
{
    //1245526462146146136136661664661636616366163616515615115146123562344
    GameObject menu;

    private void Start()
    {
        menu = GameObject.Find("Victory Text");
        menu.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            menu.SetActive(true);
        }
    }
}
