using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BattleManager : MonoBehaviour
{
    [SerializeField]
    public Transform BattleMainMenu = null;    
    [SerializeField]
    public Transform AttackSelection = null; 
    [SerializeField]
    public Transform ItemSelection = null; 
    
    public TextMeshProUGUI a0;
    public TextMeshProUGUI a1;
    public TextMeshProUGUI a2;
    public TextMeshProUGUI a3;

    public TextMeshProUGUI i0;
    public TextMeshProUGUI i1;
    public TextMeshProUGUI i2;
    public TextMeshProUGUI i3;

    public TextMeshProUGUI cName;
    public TextMeshProUGUI cHP;
    public TextMeshProUGUI cMP;

    public TextMeshProUGUI eName;
    public TextMeshProUGUI eHP;
    public TextMeshProUGUI eMP;

    public GameObject player;
    public PlayerTestScript pScript;
    public float cID; 
    public float eID;
    public float[] cAttID;
    public float[] eAttID;

    public string[] attackNames;
    public float[] attackType;
    public float[] dmgOrHeal;
    public float[] manaCost;

    public string[] characterNames;
    public float[] characterHealths;
    public float[] characterManas;

    public string[] enemyNames;
    public float[] enemyHealths;
    public float[] enemyManas;

    private string characterName;
    private float characterHealth;
    private float characterMana;

    private string enemyName;
    private float enemyHealth;
    private float enemyMana;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pScript = player.GetComponent<PlayerTestScript>();
        cID = pScript.charID;
        cAttID = pScript.attackID;
        BattleMainMenu.gameObject.SetActive(true);
        AttackSelection.gameObject.SetActive(false);
        ItemSelection.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        eID = pScript.attackerID;
        eAttID = pScript.enemyMoves;
    }


    public void AttackSClick(){
        BattleMainMenu.gameObject.SetActive(false);
        AttackSelection.gameObject.SetActive(true);
        ItemSelection.gameObject.SetActive(false);
    }
    public void ItemSClick(){
        BattleMainMenu.gameObject.SetActive(false);
        AttackSelection.gameObject.SetActive(false);
        ItemSelection.gameObject.SetActive(true);
    }
    public void BackClick(){
        BattleMainMenu.gameObject.SetActive(true);
        AttackSelection.gameObject.SetActive(false);
        ItemSelection.gameObject.SetActive(false);
    }


    public void Attack0Click(){
        
    }
    public void Item0Click(){

    }
    public void Attack1Click(){
        
    }
    public void Item1Click(){

    }
    public void Attack2Click(){
        
    }
    public void Item2Click(){

    }
    public void Attack3Click(){
        
    }
    public void Item3Click(){

    }



}
