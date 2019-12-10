using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject player;
    public PlayerTestScript pScript;
    public float cID; 
    public float eID;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pScript = player.GetComponent<PlayerTestScript>();
        cID = pScript.charID;
    }

    // Update is called once per frame
    void Update()
    {
        eID = pScript.attackerID;
    }


}
