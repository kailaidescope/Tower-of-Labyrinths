using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BattleManager : MonoBehaviour
{
    public Camera MoveCam, BattleCam;

    public Transform prefab;

    [SerializeField]
    public Transform BattleMainMenu = null;    
    [SerializeField]
    public Transform AttackSelection = null; 
    [SerializeField]
    public Transform ItemSelection = null; 
    [SerializeField]
    public Transform Response = null;
    [SerializeField]
    public Transform ErrorMSG = null;
    [SerializeField]
    public Transform Outcome = null;

    public TextMeshProUGUI rPlayer;
    public TextMeshProUGUI rEnemy;
    
    public TextMeshProUGUI rOutcome;

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
    public float[] enemyElement;
    public float[] enemyClass;
    public float[] eapower, empower, edefense;
    public float eapi, empi, edi;

    private string characterName;

    private string enemyName;
    private float enemyHealth;
    private float enemyMana;
    void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        NewBattle();
    }

    public void NewBattle(){
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
        ErrorMSG.gameObject.SetActive(false);
        Outcome.gameObject.SetActive(false);
        
        enemyHealth = enemyHealths[(int)eID];
        enemyMana = enemyManas[(int)eID];
        eapi = eapower[(int)eID];
        empi = empower[(int)eID];
        edi = edefense[(int)eID];

        a0.SetText(attackNames[(int)cAttID[0]]);
        a1.SetText(attackNames[(int)cAttID[1]]);
        a2.SetText(attackNames[(int)cAttID[2]]);
        a3.SetText(attackNames[(int)cAttID[3]]);
        
        i0.SetText(itemNames[(int)cItemsID[0]]);
        i1.SetText(itemNames[(int)cItemsID[1]]);
        i2.SetText(itemNames[(int)cItemsID[2]]);
        i3.SetText(itemNames[(int)cItemsID[3]]);

        

        characterHealth = pScript.hp;
        characterMana = pScript.mana;
    }

    // Update is called once per frame
    void Update()
    {
        eID = pScript.attackerID;
        eAttID = pScript.enemyMoves;
        
        cName.SetText(characterNames[(int)cID]);
        eName.SetText(enemyNames[(int)eID]);
        
        pScript.hp = characterHealth;
        pScript.mana = characterMana;

        cHP.SetText("Health: " + characterHealth);
        cMP.SetText("Mana: " + characterMana);

        eHP.SetText("Health: " + enemyHealth);
        eMP.SetText("Mana: " + enemyMana);

        a0.SetText(attackNames[(int)cAttID[0]]);
        a1.SetText(attackNames[(int)cAttID[1]]);
        a2.SetText(attackNames[(int)cAttID[2]]);
        a3.SetText(attackNames[(int)cAttID[3]]);

        i0.SetText(itemNames[(int)cItemsID[0]]);
        i1.SetText(itemNames[(int)cItemsID[1]]);
        i2.SetText(itemNames[(int)cItemsID[2]]);
        i3.SetText(itemNames[(int)cItemsID[3]]);
    }

    public void AttackSClick(){
        BattleMainMenu.gameObject.SetActive(false);
        AttackSelection.gameObject.SetActive(true);
        ItemSelection.gameObject.SetActive(false);
        Response.gameObject.SetActive(false);
        ErrorMSG.gameObject.SetActive(false);
    }

    public void ItemSClick(){
        BattleMainMenu.gameObject.SetActive(false);
        AttackSelection.gameObject.SetActive(false);
        ItemSelection.gameObject.SetActive(true);
        Response.gameObject.SetActive(false);
        ErrorMSG.gameObject.SetActive(false);
    }

    public void BackClick(){
        BattleMainMenu.gameObject.SetActive(true);
        AttackSelection.gameObject.SetActive(false);
        ItemSelection.gameObject.SetActive(false);
        Response.gameObject.SetActive(false);
        ErrorMSG.gameObject.SetActive(false);
    }

    public void dispResponse(){
        BattleMainMenu.gameObject.SetActive(false);
        AttackSelection.gameObject.SetActive(false);
        ItemSelection.gameObject.SetActive(false);
        Response.gameObject.SetActive(true);
        ErrorMSG.gameObject.SetActive(false);
    }

    public void dispError(){
        BattleMainMenu.gameObject.SetActive(false);
        AttackSelection.gameObject.SetActive(false);
        ItemSelection.gameObject.SetActive(false);
        Response.gameObject.SetActive(false);
        ErrorMSG.gameObject.SetActive(true);
    }

    public void OKBUTTON(){
        Outcome.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void EndBattlePlayer(){
        Debug.Log("UBFEKGYV");
        Outcome.gameObject.SetActive(true);
        rOutcome.SetText(characterNames[(int)cID] + " defeated " + enemyNames[(int)eID] + "!");
        BattleCam.enabled = !BattleCam.enabled;
        MoveCam.enabled = !MoveCam.enabled;
        Instantiate(prefab, new Vector3(389.67f, 134.6f, -189.16f), Quaternion.identity);
    }

    public void EndBattleEnemy(){
        Outcome.gameObject.SetActive(true);
        rOutcome.SetText(enemyNames[(int)eID] + " defeated " + characterNames[(int)cID] + "!");
        BattleCam.enabled = !BattleCam.enabled;
        MoveCam.enabled = !MoveCam.enabled;
        Instantiate(prefab, new Vector3(389.67f, 134.6f, -189.16f), Quaternion.identity);
        Instantiate(prefab, new Vector3(385.63f, 134.6f, -195.38f), Quaternion.identity);
    }

    int ChooseEnemyID(){
        int[] data = new int[4];
        int choice = Random.Range(0,4);
        bool oom = true;
        for(int i = 0; i < 4; i++){
            if(!(manaCost[(int)eAttID[i]] > enemyMana)){
                oom = false;
            }
        }
        if(oom){
            choice = 4;
            return choice;
        }else{
            for(;;){
                if(eAttID[choice] == 0 || manaCost[(int)eAttID[choice]] > enemyMana){
                    choice = Random.Range(0,4);
                }
                else{
                    break;
                }
            }
        }
        Debug.Log(choice);
        return choice;
    }
    
    public float advantageCalculator(int IDNUM){
        float typeAdvantage = 1;
        float[ , ] classAdvantages = new float[3,3] {{1f,2f,.5f},
                                        {.5f,1f,2f},
                                        {2f,.5f,1f}};
        //class advantage
        typeAdvantage *= classAdvantages[(int)characterClass,(int)enemyClass[(int)eID]];

        float[ , ] elementAdvantages = new float[7,7] {{1f,1f,.75f,.5f,.5f,.25f,.25f},
                                        {1.5f,.5f,.5f,3f,.75f,1f,1.5f},
                                        {1.25f,3f,.5f,.25f,1f,1f,1f},
                                        {1f,.25f,2f,.5f,2f,.5f,1f},
                                        {1f,1.5f,.5f,.75f,1f,1.5f,.5f},
                                        {2f,1f,2f,1f,2f,.5f,2f},
                                        {2f,2f,1f,2f,1f,2f,.5f}};
        //element advantage
        typeAdvantage *= elementAdvantages[(int)characterElement,(int)enemyElement[(int)eID]] * elementAdvantages[(int)attackElement[IDNUM],(int)enemyElement[(int)eID]];

        return typeAdvantage;
    }

    public void handleBattle(int IDNUM, int enemyChoice){
        float typeAdvantage = advantageCalculator(IDNUM); //input formula later
        Debug.Log("TA: " + typeAdvantage);
        float dmgDrop = 0;
        if(attackPriority[IDNUM] <= attackPriority[enemyChoice]){
            switch ((int)attackType[IDNUM]){
                case 0:
                    float dmg = edi * abilityMagnitude[IDNUM] * typeAdvantage  * capower - dmgDrop;
                    if(dmg < 0) dmg = 0;
                    enemyHealth -= dmg;     
                    characterMana -= manaCost[IDNUM];
                    rPlayer.SetText(characterNames[(int)cID] + " did " + dmg + " damage to " + enemyNames[(int)eID] + " with " + attackNames[IDNUM]);
                    break;
                case 1:
                    float hpgain = abilityMagnitude[IDNUM] * typeAdvantage * cmpower;
                    characterHealth += hpgain;
                    characterMana -= manaCost[IDNUM];
                    rPlayer.SetText(characterNames[(int)cID] + " gained " + hpgain + " HP!" + " with " + attackNames[IDNUM]);
                    break;
                case 2:
                    float defMultiplier = 1 - (abilityMagnitude[IDNUM] * cmpower);
                    cdefense *= defMultiplier;
                    characterMana -= manaCost[IDNUM];
                    rPlayer.SetText(characterNames[(int)cID] + " boosted their defense!" + " with " + attackNames[IDNUM]);
                    break;
                case 3:
                    float atkMultiplier = 1 + (abilityMagnitude[IDNUM] * cmpower);
                    capower *= atkMultiplier;
                    characterMana -= manaCost[IDNUM];
                    rPlayer.SetText(characterNames[(int)cID] + " boosted their attack power!" + " with " + attackNames[IDNUM]);
                    break;
                case 4:
                    float mMultiplier =  1 + (abilityMagnitude[IDNUM]);
                    cmpower *= mMultiplier;
                    characterMana -= manaCost[IDNUM];
                    rPlayer.SetText(characterNames[(int)cID] + " boosted their magic power!" + " with " + attackNames[IDNUM]);
                    break;
                case 5:
                    dmgDrop = (abilityMagnitude[IDNUM] * capower);
                    Debug.Log(dmgDrop);
                    characterMana -= manaCost[IDNUM];
                    rPlayer.SetText(characterNames[(int)cID] + " tried parrying " + enemyNames[(int)eID] + "'s attack!" + " with " + attackNames[IDNUM]);
                    break;
                default:
                    break;
            }
            switch ((int)attackType[enemyChoice]){
                case 0:
                    Debug.Log(dmgDrop);
                    float dmg = cdefense * abilityMagnitude[enemyChoice] * (1/typeAdvantage) * eapi - dmgDrop;
                    if(dmg < 0) dmg = 0;
                    characterHealth -= dmg;     
                    enemyMana -= manaCost[enemyChoice];
                    rEnemy.SetText( enemyNames[(int)eID] + " did " + dmg + " damage to " + characterNames[(int)cID] + " with " + attackNames[enemyChoice]);
                    break;
                case 1:
                    float hpgain = abilityMagnitude[enemyChoice] * (1/typeAdvantage) * empi;
                    enemyHealth += hpgain;
                    enemyMana -= manaCost[enemyChoice];
                    rEnemy.SetText(enemyNames[(int)eID] + " gained " + hpgain + " HP!"+ " with " + attackNames[enemyChoice]);
                    break;
                case 2:
                    float defMultiplier = 1 - (abilityMagnitude[enemyChoice] * empi);
                    edi *= defMultiplier;
                    enemyMana -= manaCost[enemyChoice];
                    rEnemy.SetText(enemyNames[(int)eID] + " boosted their defense!"+ " with " + attackNames[enemyChoice]);
                    break;
                case 3:
                    float atkMultiplier = 1 + (abilityMagnitude[enemyChoice] * empi);
                    eapi *= atkMultiplier;
                    enemyMana -= manaCost[enemyChoice];
                    rEnemy.SetText(enemyNames[(int)eID] + " boosted their attack power!"+ " with " + attackNames[enemyChoice]);
                    break;
                case 4:
                    float mMultiplier =  1 + (abilityMagnitude[enemyChoice]);
                    empi *= mMultiplier;
                    enemyMana -= manaCost[enemyChoice];
                    rEnemy.SetText(enemyNames[(int)eID] + " boosted their magic power!"+ " with " + attackNames[enemyChoice]);
                    break;
                case 5:
                    dmgDrop = (abilityMagnitude[enemyChoice] * eapi);
                    enemyMana -= manaCost[enemyChoice];
                    rEnemy.SetText(enemyNames[(int)eID] + " tried parrying " + characterNames[(int)cID] + "'s attack!"+ " with " + attackNames[enemyChoice]);
                    break;
                default:
                    rEnemy.SetText(enemyNames[(int)eID] + " has no mana!"); 
                    break;
            }
        }
        else
        {
            switch ((int)attackType[enemyChoice]){
                case 0:
                    float dmg = cdefense * abilityMagnitude[enemyChoice] * (1/typeAdvantage) * eapi - dmgDrop;
                    if(dmg < 0) dmg = 0;
                    characterHealth -= dmg;     
                    enemyMana -= manaCost[enemyChoice];
                    rEnemy.SetText( enemyNames[(int)eID] + " did " + dmg + " damage to " + characterNames[(int)cID]+ " with " + attackNames[enemyChoice]);
                    break;
                case 1:
                    float hpgain = abilityMagnitude[enemyChoice] * (1/typeAdvantage) * empi;
                    enemyHealth += hpgain;
                    enemyMana -= manaCost[enemyChoice];
                    rEnemy.SetText(enemyNames[(int)eID] + " gained " + hpgain + " HP!"+ " with " + attackNames[enemyChoice]);
                    break;
                case 2:
                    float defMultiplier = 1 - (abilityMagnitude[enemyChoice] * empi);
                    edi *= defMultiplier;
                    enemyMana -= manaCost[enemyChoice];
                    rEnemy.SetText(enemyNames[(int)eID] + " boosted their defense!"+ " with " + attackNames[enemyChoice]);
                    break;
                case 3:
                    float atkMultiplier = 1 + (abilityMagnitude[enemyChoice] * empi);
                    eapi *= atkMultiplier;
                    enemyMana -= manaCost[enemyChoice];
                    rEnemy.SetText(enemyNames[(int)eID] + " boosted their attack power!"+ " with " + attackNames[enemyChoice]);
                    break;
                case 4:
                    float mMultiplier =  1 + (abilityMagnitude[enemyChoice]);
                    empi *= mMultiplier;
                    enemyMana -= manaCost[enemyChoice];
                    rEnemy.SetText(enemyNames[(int)eID] + " boosted their magic power!"+ " with " + attackNames[enemyChoice]);
                    break;
                case 5:
                    dmgDrop = (abilityMagnitude[enemyChoice] * eapi);
                    enemyMana -= manaCost[enemyChoice];
                    rEnemy.SetText(enemyNames[(int)eID] + " tried parrying " + characterNames[(int)cID] + "'s attack!"+ " with " + attackNames[enemyChoice]);
                    break;
                default:
                    rEnemy.SetText(enemyNames[(int)eID] + " has no mana!"); 
                    break;
            }
            switch ((int)attackType[IDNUM]){
                case 0:
                    float dmg = edi * abilityMagnitude[IDNUM] * typeAdvantage  * capower - dmgDrop;
                    if(dmg < 0) dmg = 0;
                    enemyHealth -= dmg;     
                    characterMana -= manaCost[IDNUM];
                    rPlayer.SetText(characterNames[(int)cID] + " did " + dmg + " damage to " + enemyNames[(int)eID] + " with " + attackNames[IDNUM]);
                    break;
                case 1:
                    float hpgain = abilityMagnitude[IDNUM] * typeAdvantage * cmpower;
                    characterHealth += hpgain;
                    characterMana -= manaCost[IDNUM];
                    rPlayer.SetText(characterNames[(int)cID] + " gained " + hpgain + " HP!" + " with " + attackNames[IDNUM]);
                    break;
                case 2:
                    float defMultiplier = 1 - (abilityMagnitude[IDNUM] * cmpower);
                    cdefense *= defMultiplier;
                    characterMana -= manaCost[IDNUM];
                    rPlayer.SetText(characterNames[(int)cID] + " boosted their defense!" + " with " + attackNames[IDNUM]);
                    break;
                case 3:
                    float atkMultiplier = 1 + (abilityMagnitude[IDNUM] * cmpower);
                    capower *= atkMultiplier;
                    characterMana -= manaCost[IDNUM];
                    rPlayer.SetText(characterNames[(int)cID] + " boosted their attack power!" + " with " + attackNames[IDNUM]);
                    break;
                case 4:
                    float mMultiplier =  1 + (abilityMagnitude[IDNUM]);
                    cmpower *= mMultiplier;
                    characterMana -= manaCost[IDNUM];
                    rPlayer.SetText(characterNames[(int)cID] + " boosted their magic power!" + " with " + attackNames[IDNUM]);
                    break;
                case 5:
                    dmgDrop = (abilityMagnitude[IDNUM] * capower);
                    characterMana -= manaCost[IDNUM];
                    rPlayer.SetText(characterNames[(int)cID] + " tried parrying " + enemyNames[(int)eID] + "'s attack!" + " with " + attackNames[IDNUM]);
                    break;
                default:
                    break;
            }
        }
        if(enemyHealth <= 0){
            if(characterHealth<=0){
                EndBattleEnemy();
            }
            else{
                EndBattlePlayer();
            } 
        }
        if(characterHealth<=0){
            EndBattleEnemy();
        }
        dispResponse();
        
    }
    public void handleITEMS(int IDNUM, int index){
        switch(IDNUM){
            case 1:
                float hpgain1 = 40;
                characterHealth += hpgain1;
                cItemsID[index] = 0;
                rPlayer.SetText(characterNames[(int)cID] + " healed 40 HP!");
                break;
            case 2:
                float managain1 = 40;
                characterMana += managain1;
                cItemsID[index] = 0;
                rPlayer.SetText(characterNames[(int)cID] + " generated 40 MP!");
                break;
            case 3:
                float defMultiplier1 = .8f;
                cdefense *= defMultiplier1;
                cItemsID[index] = 0;
                rPlayer.SetText(characterNames[(int)cID] + " boosted their defense!");
                break;
            case 4:
                float atkMultiplier1 = 1.2f;
                capower *= atkMultiplier1;
                cItemsID[index] = 0;
                rPlayer.SetText(characterNames[(int)cID] + " boosted their attack power!");
                break;
            case 5:
                float mMultiplier1 = 1.2f;
                cmpower *= mMultiplier1;
                cItemsID[index] = 0;
                rPlayer.SetText(characterNames[(int)cID] + " boosted their magic power!");
                break;
            case 6:
                float hpgain2 = 100;
                characterHealth += hpgain2;
                cItemsID[index] = 0;
                rPlayer.SetText(characterNames[(int)cID] + " healed 100 HP!");
                break;
            case 7:
                float managain2 = 100;
                characterMana += managain2;
                cItemsID[index] = 0;
                rPlayer.SetText(characterNames[(int)cID] + " generated 100 MP!");
                break;
            default:
                dispError();
                return;
                break;
        }
        int enemyChoice;
        if(ChooseEnemyID() != 4) enemyChoice = (int)eAttID[ChooseEnemyID()];
        else enemyChoice = 0;
        float typeAdvantage = advantageCalculator(0); //input formula later
        float dmgDrop = 0;
        
        switch ((int)attackType[enemyChoice]){
            case 0:
                float dmg = cdefense * abilityMagnitude[enemyChoice] * (1/typeAdvantage) * eapi - dmgDrop;
                if(dmg < 0) dmg = 0;
                characterHealth -= dmg;     
                enemyMana -= manaCost[enemyChoice];
                rEnemy.SetText( enemyNames[(int)eID] + " did " + dmg + " damage to " + characterNames[(int)cID]+ " with " + attackNames[enemyChoice]);
                break;
            case 1:
                float hpgain = abilityMagnitude[enemyChoice] * (1/typeAdvantage) * empi;
                enemyHealth += hpgain;
                enemyMana -= manaCost[enemyChoice];
                rEnemy.SetText(enemyNames[(int)eID] + " gained " + hpgain + " HP!"+ " with " + attackNames[enemyChoice]);
                break;
            case 2:
                float defMultiplier = 1 - (abilityMagnitude[enemyChoice] * empi);
                edi *= defMultiplier;
                enemyMana -= manaCost[enemyChoice];
                rEnemy.SetText(enemyNames[(int)eID] + " boosted their defense!"+ " with " + attackNames[enemyChoice]);
                break;
            case 3:
                float atkMultiplier = 1 + (abilityMagnitude[enemyChoice] * empi);
                eapi *= atkMultiplier;
                enemyMana -= manaCost[enemyChoice];
                rEnemy.SetText(enemyNames[(int)eID] + " boosted their attack power!"+ " with " + attackNames[enemyChoice]);
                break;
            case 4:
                float mMultiplier =  1 + (abilityMagnitude[enemyChoice]);
                empi *= mMultiplier;
                enemyMana -= manaCost[enemyChoice];
                rEnemy.SetText(enemyNames[(int)eID] + " boosted their magic power!"+ " with " + attackNames[enemyChoice]);
                break;
            case 5:
                dmgDrop = (abilityMagnitude[enemyChoice] * eapi);
                enemyMana -= manaCost[enemyChoice];
                rEnemy.SetText(enemyNames[(int)eID] + " tried parrying " + characterNames[(int)cID] + "'s attack!"+ " with " + attackNames[enemyChoice]);
                break;
            default:
                rEnemy.SetText(enemyNames[(int)eID] + " has no mana!"); 
                break;
        }
        if(enemyHealth <= 0){
            if(characterHealth<=0){
                EndBattleEnemy();
            }
            else{
                EndBattlePlayer();
            } 
        }
        
        if(characterHealth<=0){
            EndBattleEnemy();
        }
        dispResponse();

    }

    public void Attack0Click(){
        int IDNUM = (int) cAttID[0];
        if(manaCost[IDNUM] > characterMana){dispError();return;}
        if(ChooseEnemyID() == 4) {
            handleBattle(IDNUM, 0);
            return;
        }
        int enemyChoice = (int)eAttID[ChooseEnemyID()]; 
        Debug.Log(enemyChoice);
        handleBattle(IDNUM, enemyChoice);
    }
    
    public void Item0Click(){
        int IDNUM = (int)cItemsID[0];
        handleITEMS(IDNUM,0);
    }
   
    public void Attack1Click(){
        int IDNUM = (int) cAttID[1];
        if(manaCost[IDNUM] > characterMana){dispError();return;}
        if(ChooseEnemyID() == 4) {
            handleBattle(IDNUM, 0);
            return;
        }
        int enemyChoice = (int)eAttID[ChooseEnemyID()]; 
        Debug.Log(enemyChoice);
        handleBattle(IDNUM, enemyChoice);
    }
 
    public void Item1Click(){
        int IDNUM = (int)cItemsID[1];
        handleITEMS(IDNUM,1);
    }
    
    public void Attack2Click(){
        int IDNUM = (int) cAttID[2];
        if(manaCost[IDNUM] > characterMana){dispError();return;}
        if(ChooseEnemyID() == 4) {
            handleBattle(IDNUM, 0);
            return;
        }
        int enemyChoice = (int)eAttID[ChooseEnemyID()]; 
        Debug.Log(enemyChoice);
        handleBattle(IDNUM, enemyChoice);
    }
 
    public void Item2Click(){
        int IDNUM = (int)cItemsID[2];
        handleITEMS(IDNUM,2);
    }
 
    public void Attack3Click(){
        int IDNUM = (int) cAttID[3];
        if(manaCost[IDNUM] > characterMana){dispError();return;}
        if(ChooseEnemyID() == 4) {
            handleBattle(IDNUM, 0);
            return;
        }
        int enemyChoice = (int)eAttID[ChooseEnemyID()]; 
        Debug.Log(enemyChoice);
        handleBattle(IDNUM, enemyChoice);
    }
  
    public void Item3Click(){
        int IDNUM = (int)cItemsID[3];
        handleITEMS(IDNUM,3);
    }
}
