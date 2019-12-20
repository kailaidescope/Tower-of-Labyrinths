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
    [SerializeField]
    public Transform Response = null;

    public TextMeshProUGUI rPlayer;
    public TextMeshProUGUI rEnemy;
    
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
    public float[] cItemsID;

    public string[] attackNames;
    public float[] attackType;//0,1,2,3,4,5,6
                                //damage,heal,defBoost,atkBoost,magBoost, shield,None
    public float[] attackElement; //0,1,2,3,4,5,6
                                    //normal, fire, water, air, earth, light, shadow
    //classes //0,1,2
                              //warrior, mage, rogue
    public float[] abilityMagnitude; //scalarValue of attack
    public float[] manaCost;
    public float[] attackPriority;

    public string[] itemNames;

    public string[] characterNames;
    public float characterHealth;
    public float characterMana;
    public float characterElement;
    public float characterClass;
    public float cdchance, capower, cmpower, cdefense;
    public string[] enemyNames;
    public float[] enemyHealths;
    public float[] enemyManas;
    public float[] enemyClass;

    private string characterName;

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
        cItemsID = pScript.items;
        characterHealth = pScript.hp;
        characterMana = pScript.mana;
        characterElement = pScript.element;
        characterClass = pScript.classType;
        cdchance = pScript.dodgeChance;
        capower = pScript.attackPower;
        cmpower = pScript.magicPower;
        cdefense = pScript.defense;
        BattleMainMenu.gameObject.SetActive(true);
        AttackSelection.gameObject.SetActive(false);
        ItemSelection.gameObject.SetActive(false);
        Response.gameObject.SetActive(false);

        enemyHealth = enemyHealths[(int)eID];
        enemyMana = enemyManas[(int)eID];

        a0.SetText(attackNames[(int)cAttID[0]]);
        a1.SetText(attackNames[(int)cAttID[1]]);
        a2.SetText(attackNames[(int)cAttID[2]]);
        a3.SetText(attackNames[(int)cAttID[3]]);
        
        i0.SetText(itemNames[(int)cItemsID[0]]);
        i1.SetText(itemNames[(int)cItemsID[1]]);
        i2.SetText(itemNames[(int)cItemsID[2]]);
        i3.SetText(itemNames[(int)cItemsID[3]]);

        cName.SetText(characterNames[(int)cID]);
        eName.SetText(enemyNames[(int)eID]);
    }

    // Update is called once per frame
    void Update()
    {
        eID = pScript.attackerID;
        eAttID = pScript.enemyMoves;
        characterHealth = pScript.hp;
        characterMana = pScript.mana;

        cHP.SetText("Health: " + characterHealth);
        cMP.SetText("Mana: " + characterMana);

        eHP.SetText("Health: " + enemyHealth);
        eMP.SetText("Mana: " + enemyMana);
    }


    public void AttackSClick(){
        BattleMainMenu.gameObject.SetActive(false);
        AttackSelection.gameObject.SetActive(true);
        ItemSelection.gameObject.SetActive(false);
        Response.gameObject.SetActive(false);
    }
    public void ItemSClick(){
        BattleMainMenu.gameObject.SetActive(false);
        AttackSelection.gameObject.SetActive(false);
        ItemSelection.gameObject.SetActive(true);
        Response.gameObject.SetActive(false);
    }
    public void BackClick(){
        BattleMainMenu.gameObject.SetActive(true);
        AttackSelection.gameObject.SetActive(false);
        ItemSelection.gameObject.SetActive(false);
        Response.gameObject.SetActive(false);
    }
    public void dispResponse(){
        BattleMainMenu.gameObject.SetActive(false);
        AttackSelection.gameObject.SetActive(false);
        ItemSelection.gameObject.SetActive(false);
        Response.gameObject.SetActive(true);
    }

    int ChooseEnemyID(){
        int[] data = new int[4];
        int choice = Random.Range(0,4);
        for(;;){
            if(eAttID[choice] == 0){
                choice = Random.Range(0,4);
            }
            else{
                break;
            }
        }
        Debug.Log(choice);
        return choice;
    }

    public void Attack0Click(){
        int IDNUM = (int) cAttID[0];
        int enemyChoice = (int)eAttID[ChooseEnemyID()]; 
        Debug.Log(enemyChoice);
        float typeAdvantage = 1; //input formula later
        float dmgDrop = 0;
        if(attackPriority[IDNUM] >= attackPriority[enemyChoice]){
            switch ((int)attackType[IDNUM]){
                case 0:
                    float dmg = abilityMagnitude[IDNUM] * typeAdvantage  * capower - dmgDrop;
                    if(dmg < 0) dmg = 0;
                    enemyHealth -= dmg;     
                    characterMana -= manaCost[IDNUM];
                    rPlayer.SetText(characterNames[(int)cID] + " did " + dmg + " damage to " + enemyNames[(int)eID]);
                    break;
                case 1:
                    float hpgain = abilityMagnitude[IDNUM] * typeAdvantage * cmpower;
                    characterHealth += hpgain;
                    characterMana -= manaCost[IDNUM];
                    rPlayer.SetText(characterNames[(int)cID] + " gained " + hpgain + " HP!");
                    break;
                case 2:
                    float defMultiplier = 1 - (abilityMagnitude[IDNUM] * cmpower);
                    cdefense *= defMultiplier;
                    characterMana -= manaCost[IDNUM];
                    rPlayer.SetText(characterNames[(int)cID] + " boosted their defense!");
                    break;
                case 3:
                    float atkMultiplier = 1 + (abilityMagnitude[IDNUM] * cmpower);
                    capower *= atkMultiplier;
                    characterMana -= manaCost[IDNUM];
                    rPlayer.SetText(characterNames[(int)cID] + " boosted their attack power!");
                    break;
                case 4:
                    float mMultiplier =  1 + (abilityMagnitude[IDNUM]);
                    cmpower *= mMultiplier;
                    characterMana -= manaCost[IDNUM];
                    rPlayer.SetText(characterNames[(int)cID] + " boosted their magic power!");
                    break;
                case 5:
                    dmgDrop = (abilityMagnitude[IDNUM] * capower);
                    characterMana -= manaCost[IDNUM];
                    rPlayer.SetText(characterNames[(int)cID] + " tried parrying " + enemyNames[(int)eID] + "'s attack!");
                    break;
                default:
                    break;
            }
        }
        else
        {

        }

        dispResponse();
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
