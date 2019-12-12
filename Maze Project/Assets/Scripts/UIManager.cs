using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Text timer;

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        UpdateTime();
    }

    public void UpdateTime()
    {
        string time = player.GetComponent<PlayerMovement>().GetTimerTime().ToString();
        timer.text = "Time: " + time.Substring(0, time.Length - 3);
    }
}
