using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Text timer;
    [SerializeField] private UnityEngine.UI.Text coins;

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        UpdateTime();
        UpdateCoins();
    }

    public void UpdateTime()
    {
        string time = player.GetComponent<PlayerBehaviour>().GetTimerTime().ToString();
        timer.text = "Time: " + time.Substring(0, time.Length - 3);
    }

    public void UpdateCoins()
    {
        int c = player.GetComponent<PlayerBehaviour>().GetCoinNum();
        coins.text = "Coins: " + c;
    }
}
