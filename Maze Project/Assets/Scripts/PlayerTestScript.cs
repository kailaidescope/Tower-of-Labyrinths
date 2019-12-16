using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerTestScript : MonoBehaviour
{
    Rigidbody rb3d;
    public Camera MoveCam, BattleCam;
    public float attackerID = 000f;
    public float charID = 000f;
    public float mana;
    public float hp;
    public float element;
    public float classType;
    public float dodgeChance;
    public float attackPower;
    public float magicPower;
    public float defense;
    public float[] attackID;
    public float[] items;
    public float[] enemyMoves;
    // Start is called before the first frame update
    void Start()
    {
        rb3d = GetComponent<Rigidbody>();
        BattleCam.enabled = false; 
        MoveCam.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Enemy"){
            Debug.Log("Enter Battle");
            SwitchCameras();
            Destroy(other.gameObject.GetComponent<Rigidbody>());
            other.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            attackerID = other.gameObject.GetComponent<AIMovement>().enemyID;
            enemyMoves = other.gameObject.GetComponent<AIMovement>().enemyAttackID;
            other.gameObject.GetComponent<AIMovement>().enabled = false;
            other.gameObject.transform.position = new Vector3(389.67f, 132.6f, -189.16f);
        }
    }
    public void SwitchCameras(){
        BattleCam.enabled = !BattleCam.enabled;
        MoveCam.enabled = !MoveCam.enabled;
    }
}
