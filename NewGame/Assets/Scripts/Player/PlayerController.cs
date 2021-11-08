using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerController : MonoBehaviour
{
    private bool isMoving;
    private Vector2 input; //Tracks user movement input wasd
    public LayerMask solidObjectsLayer; //solid objects layer, used to determine if player can move to space
    public GameObject door; //Portal
    private Animator animator;
    public bool sceneTransition = false;
    private bool isAttacking = false;
    private SpriteRenderer mySpriteRenderer; //Sprite renderer component used for flipping x of player when changing direction, was more efficient then creating animations for both directions plus additional logic
    public int lastMovingDirection = 1; //1 is last moving right, -1 is last moving left
    public Transform attackPoint; //Empty game object to hold a relative position for hit detection
    public float attackRange = 0.5f; 
    public LayerMask enemyLayers; //Will change to slimeLayers and add a new layermask for all implemented enemies, used in hit detection. Distance from player to layermask. Ended up just using this to carry all enemy layers, then distinguish between them by layer name
    private TMP_Text hpText;
    public Image hpBar;         //Hp bar above char
    public Vector3 distXPlayerToAttackPoint;
    public GameObject arrow;
    public GameObject bomb;
    private Vector3 distYPlayerToGround = new Vector3(0, -0.5f, 0);
    public GameObject trap;
    public GameObject pauseMenu;
    public Text hitText;
    public Canvas playerCanvas;
    public Transform hitTextPos; //transform position for my damage text
    public GameObject eyeballSummon;


    //CDS UI
    /*
    public Image mSkillUI;
    public Image nSkillUI;
    public Image bSkillUI;*/
    public Image[] SkillsUI;

    public Text mTextUI;
    public Text nTextUI;
    public Text bTextui;

    public Sprite[] rogueSkillsSprites;
    public Sprite[] warriorSkillsSprites;
    public Sprite[] rangerSkillsSprites;
    public Sprite[] clericSkillsSprites;
    

    
    /*
     * Maybe actually dont track current stats and deal damage to specific characters
     */


    //Player stats
    /*
    private int maxHp = 100;
    private int defense = 4;
    private int attack = 20;
    private int crRate = 20;
    private float crDmg = 1.4f;
    private float dodge = 0.1f;
    private int maxMp = 100;
    
    private int currLvl = 1;
    private int currExp = 0;*/

    //General player info
    private int activeCharacter = 1; //1Rogue 2Warrior 3Ranger 4Cleric
    

    //Rogue
    public int rogueMaxHp = 100;
    public int rogueCurrHp;
    public int rogueDefense = 4;
    public int rogueAttack = 40;
    public int rogueCrRate = 20;
    public float rogueCrDmg = 1.4f;
    public float rogueDodge = 0.3f;
    public int rogueMaxMp = 100;
    public int rogueCurrMp = 100;
    public int rogueCurrLvl = 1;
    public int rogueCurrExp = 0;
    public int rogueExptoNextLvl = 10;
    public int rogueSkillPoints = 0;
    public int rogueAttributePoints;

    public int rogueStr = 5;
    public int rogueDex = 8;
    public int rogueCon = 5;
    public int rogueInt = 3;

    //Rogue skill levels
    public int rogueStealthLvl = 1;
    public int rogueExecuteLvl = 1;
    public int rogueBombLvl = 1;

    //Warrior
    public int warriorMaxHp = 100;
    public int warriorCurrHp;
    public int warriorDefense = 6;
    public int warriorAttack = 30;
    public int warriorCrRate = 20;
    public float warriorCrDmg = 1.4f;
    public float warriorDodge = 0.1f;
    public int warriorMaxMp = 100;
    public int warriorCurrMp = 100;
    public int warriorCurrLvl = 1;
    public int warriorCurrExp = 0;
    public int warriorExptoNextLvl = 10;
    public int warriorSkillPoints = 0;
    public int warriorAttributePoints;

    public int warriorStr = 5;
    public int warriorDex = 4;
    public int warriorCon = 10;
    public int warriorInt = 3;

    //Warrior skill levels
    public int warriorIronheartLvl = 1;
    public int warriorRevengeLvl = 1;
    public int warriorSacrificeLvl = 1;

    //Ranger
    public int rangerMaxHp = 100;
    public int rangerCurrHp;
    public int rangerDefense = 2;
    public int rangerAttack = 50;
    public int rangerCrRate = 20;
    public float rangerCrDmg = 1.4f;
    public float rangerDodge = 0.1f;
    public int rangerMaxMp = 100;
    public int rangerCurrMp = 100;
    public int rangerCurrLvl = 1;
    public int rangerCurrExp = 0;
    public int rangerExptoNextLvl = 10;
    public int rangerSkillPoints = 0;
    public int rangerAttributePoints;

    public int rangerStr = 5;
    public int rangerDex = 10;
    public int rangerCon = 3;
    public int rangerInt = 3;

    //Ranger skill levels
    public int rangerTrapLvl = 1;
    public int rangerFocusShotLvl = 1;
    public int rangerCripplingShotLvl = 1;


    //Cleric
    public int clericMaxHp = 100;
    public int clericCurrHp;
    public int clericDefense = 3;
    public int clericAttack = 10;
    public int clericCrRate = 5;
    public float clericCrDmg = 1.1f;
    public float clericDodge = 0.3f;
    public int clericMaxMp = 100;
    public int clericCurrMp = 100;
    public int clericCurrLvl = 1;
    public int clericCurrExp = 0;
    public int clericExptoNextLvl = 10;
    //public int clericHeal = 20;
    public int clericSkillPoints;
    public int clericAttributePoints;

    public int clericStr = 5;
    public int clericDex = 10;
    public int clericCon = 3;
    public int clericInt = 3;

    //Cleric skill levels
    public int clericHealLvl = 1;
    public int clericResurrectionLvl = 1;
    public int clericRaiseTheDeadLvl = 1;


    //Skill related or stat modifiers
    //Rogue
    public bool isStealth = false;
    private bool skillExecute = false;
    private bool skillBomb = false;
    private bool passiveStealth = false;
    private bool poisonHit = false;
    private int rogueBonusAttack = 0;
    private int rogueBonustAttack2 = 0;
    private int rogueBonusCrRate = 0;
    private float rogueBonusCrDmg = 0;
    private float executePoisonDOT = 0.06f;
    private int executePoisonDuration = 5;
    
    //Warrior
    private bool isIronheart = false;
    private bool skillRevenge = false;
    private bool skillSacrifice = false;
    private bool flameHit = false;
    private int warriorBonusAttack = 0;
    private float sacrificeFireDOT = 0.05f;
    private int sacrificeFireDuration = 5;
    private bool sacrificeAOE = false;

    //Ranger
    private bool skillTrap = false;
    private bool skillCripplingShot = false;
    private bool skillFocusShot = false;
    private int bonusArrowDamage = 0;
    private int rangerBonusCrRate = 0;
    private float rangerBonusCrDmg = 0;
    private int rangerBonusAttack = 0;
    //Cleric
    private bool skillHeal = false;
    private bool skillRes = false;
    private bool skillSummon = false;
    



    //Current character stats 
    public TMP_Text currCharTextUI;
    public Image currCharHpUI;
    public Image currCharMpUI;
    public Image currCharXpUI;
    private int currHp;
    private int currMaxHp;
    private int currMp;
    private int currMaxMp;
    private int currExp;
    private int currExpToLevel;


    //UI Status Effects
    public Sprite[] statusEffects;
    public Image[] rogueStatusEffects;
    public Image[] warriorStatusEffects;
    public Image[] rangerStatusEffects;
    public Image[] clericStatusEffects;



    //Rogue
    public Image rogueHpBarUI;
    public TMP_Text rogueTextUI;
    public Image rogueMpBarUI;
    public Image rogueXpBarUI;
    public Image[] rogueStatusUI;


    //Warrior
    public Image warriorHpBarUI;
    public TMP_Text warriorTextUI;
    public Image warriorMpBarUI;
    public Image warriorXpBarUI;
    public Image[] warriorStatusUI;

    //Ranger
    public Image rangerHpBarUI;
    public TMP_Text rangerTextUI;
    public Image rangerMpBarUI;
    public Image rangerXpBarUI;
    public Image[] rangerStatusUI;

    //Cleric
    public Image clericHpBarUI;
    public TMP_Text clericTextUI;
    public Image clericMpBarUI;
    public Image clericXpBarUI;
    public Image[] clericStatusUI;



    //CDS
    private bool healthPotCD;
    private bool manaPotCD;

    private bool stealthCD = false;
    private bool executeCD = false;
    private bool bombCD = false;

    private bool ironheartCD = false;
    private bool revengeCD = false;
    private bool sacrificeCD = false;

    private bool trapCD = false;
    private bool focusShotCD = false;
    private bool cripplingShotCD = false;

    private bool healCD = false;
    private bool resurrectionCD = false;
    private bool raiseTheDeadCD = false;



    public GameObject StatusUI;
    private float time1 = 0.0f;
    private float time2 = 0.0f;

    //Status effects
    private bool isStunned = false;
    private bool isRooted = false;
    private bool isSlowed = false;
    //private bool isBurned = false;
    private bool rogueBurned = false;
    private bool warriorBurned = false;
    private bool rangerBurned = false;
    private bool clericBurned = false;

    private int extraStunCounter = 0;
    private int extraRootCounter = 0;
    private int extraSlowCounter = 0;
    private int rogueBurnCounter = 0;
    private int warriorBurnCounter = 0;
    private int rangerBurnCounter = 0;
    private int clericBurnCounter = 0;

    private float moveSpeed = 5.0f;
    private float normalSpeed = 5.0f;
    private float slowSpeed = 3.0f;


    
    // Start is called before the first frame update
    void Start()
    {
        //Components
        //rogueAttributePoints = 5;
        //clericSkillPoints = 2;
        rogueSkillPoints = 6;
        warriorSkillPoints = 6;
        clericSkillPoints = 6;
        rangerSkillPoints = 6;
        animator = GetComponent<Animator>();
        DontDestroyOnLoad(gameObject);
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        

        rogueCurrHp = rogueMaxHp;
        warriorCurrHp = warriorMaxHp;
        rangerCurrHp = rangerMaxHp;
        clericCurrHp = clericMaxHp;

        hpText = GetComponentInChildren<TMP_Text>();
        hpText.text = "Lvl " + rogueCurrLvl + " Rogue";
        rogueTextUI.text = "Lvl " + rogueCurrLvl + " Rogue";
        warriorTextUI.text = "Lvl " + warriorCurrLvl + " Warrior";
        rangerTextUI.text = "Lvl " + rangerCurrLvl + " Ranger";
        clericTextUI.text = "Lvl " + clericCurrLvl + " Cleric";
        currCharTextUI.text = "Lvl " + rogueCurrLvl + " Rogue";
        hpBar.fillAmount = rogueCurrHp / rogueMaxHp;
        //UI bars
        rogueHpBarUI.fillAmount = rogueCurrHp / rogueMaxHp;
        warriorHpBarUI.fillAmount = warriorCurrHp / warriorMaxHp;
        rangerHpBarUI.fillAmount = rangerCurrHp / rangerMaxHp;
        clericHpBarUI.fillAmount = clericCurrHp / clericMaxHp;

        rogueMpBarUI.fillAmount = rogueCurrMp / rogueMaxMp;
        warriorMpBarUI.fillAmount = warriorCurrMp / warriorMaxMp;
        rangerMpBarUI.fillAmount = rangerCurrMp / rangerMaxMp;
        clericMpBarUI.fillAmount = clericCurrMp / clericMaxMp;

        currCharHpUI.fillAmount = rogueCurrHp / rogueMaxHp;
        currCharMpUI.fillAmount = rogueCurrMp / rogueMaxMp;
        rogueXpBarUI.fillAmount = rogueCurrExp / rogueExptoNextLvl;
        warriorXpBarUI.fillAmount = warriorCurrExp / warriorExptoNextLvl;
        rangerXpBarUI.fillAmount = rangerCurrExp / rangerExptoNextLvl;
        clericXpBarUI.fillAmount = clericCurrExp / clericExptoNextLvl;
        currCharXpUI.fillAmount = rogueCurrExp / rogueExptoNextLvl;

        arrow.GetComponent<ArrowCollision>().arrowDmg = rangerAttack;

        //Curr UI


        //distXPlayerToAttackPoint = attackPoint.transform.position - transform.position;
        //Debug.Log(distXPlayerToAttackPoint);
        distXPlayerToAttackPoint = new Vector3(0.8f, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        rogueHpBarUI.fillAmount = (float)rogueCurrHp / (float)rogueMaxHp;
        warriorHpBarUI.fillAmount = (float)warriorCurrHp / (float)warriorMaxHp;
        rangerHpBarUI.fillAmount = (float)rangerCurrHp / (float)rangerMaxHp;
        clericHpBarUI.fillAmount = (float)clericCurrHp / (float)clericMaxHp;

        rogueMpBarUI.fillAmount = (float)rogueCurrMp / (float)rogueMaxMp;
        warriorMpBarUI.fillAmount = (float)warriorCurrMp / (float)warriorMaxMp;
        rangerMpBarUI.fillAmount = (float)rangerCurrMp / (float)rangerMaxMp;
        clericMpBarUI.fillAmount = (float)clericCurrMp / (float)clericMaxMp;


        if (activeCharacter == 1)
        {
            hpBar.fillAmount = (float)rogueCurrHp / (float)rogueMaxHp;
            hpText.text = "Lvl " + rogueCurrLvl + " Rogue";
            currCharTextUI.text = "Lvl " + rogueCurrLvl + " Rogue";
            currCharHpUI.fillAmount = (float)rogueCurrHp / (float)rogueMaxHp;
            currCharMpUI.fillAmount = (float)rogueCurrMp / (float)rogueMaxMp;
            currCharXpUI.fillAmount = (float)rogueCurrExp / (float)rogueExptoNextLvl;
        }
        else if (activeCharacter == 2)
        {
            hpBar.fillAmount = (float)warriorCurrHp / (float)warriorMaxHp;
            hpText.text = "Lvl " + warriorCurrLvl + " Warrior";
            currCharTextUI.text = "Lvl " + warriorCurrLvl + " Warrior";
            currCharHpUI.fillAmount = (float)warriorCurrHp / (float)warriorMaxHp;
            currCharMpUI.fillAmount = (float)warriorCurrMp / (float)warriorMaxMp;
            currCharXpUI.fillAmount = (float)warriorCurrExp / (float)warriorExptoNextLvl;
        }
        else if (activeCharacter == 3)
        {
            hpBar.fillAmount = (float)rangerCurrHp / (float)rangerMaxHp;
            hpText.text = "Lvl " + rangerCurrLvl + " Ranger";
            currCharTextUI.text = "Lvl " + rangerCurrLvl + " Ranger";
            currCharHpUI.fillAmount = (float)rangerCurrHp / (float)rangerMaxHp;
            currCharMpUI.fillAmount = (float)rangerCurrMp / (float)rangerMaxMp;
            currCharXpUI.fillAmount = (float)rangerCurrExp / (float)rangerExptoNextLvl;
        }
        else if (activeCharacter == 4)
        {
            hpBar.fillAmount = (float)clericCurrHp / (float)clericMaxHp;
            hpText.text = "Lvl " + clericCurrLvl + " Cleric";
            currCharTextUI.text = "Lvl " + clericCurrLvl + " Cleric";
            currCharHpUI.fillAmount = (float)clericCurrHp / (float)clericMaxHp;
            currCharMpUI.fillAmount = (float)clericCurrMp / (float)clericMaxMp;
            currCharXpUI.fillAmount = (float)clericCurrExp / (float)clericExptoNextLvl;
        }

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            if (StateController.paused == false)
            {
                pauseMenu.SetActive(true);
                StateController.paused = true;
            }
            else
            {
                pauseMenu.SetActive(false);
                StateController.paused = false;
            }
        }
        if (StateController.paused == false && isStunned == false)
        {
            rogueXpBarUI.fillAmount = (float)rogueCurrExp / (float)rangerExptoNextLvl;
            warriorXpBarUI.fillAmount = (float)warriorCurrExp / (float)warriorExptoNextLvl;
            rangerXpBarUI.fillAmount = (float)rangerCurrExp / (float)rangerExptoNextLvl;
            rogueTextUI.text = "Lvl " + rogueCurrLvl + " Rogue";
            warriorTextUI.text = "Lvl " + warriorCurrLvl + " Warrior";
            rangerTextUI.text = "Lvl " + rangerCurrLvl + " Ranger";

            //For max rogue stealth skill
            if(rogueStealthLvl == 3 && isStealth == false && activeCharacter == 1 && passiveStealth == false && time1 == 0.0f)//If max stealth lvl go into stealth passively for 5s out of combat
            {
                time1 = Time.timeSinceLevelLoad;
            }
            if(Time.timeSinceLevelLoad-time1 >= 5.0 && rogueStealthLvl == 3 && isStealth == false && activeCharacter == 1 && passiveStealth == false)
            {
                StartCoroutine(Skill_Stealth());
                //Debug.Log("v");
            }
            


            //Character swaps
            if (Input.GetKeyDown(KeyCode.Alpha1) && isAttacking == false && rogueCurrHp > 0)//Add checks to make sure character is alive
            {
                if (isIronheart == true)
                {

                }
                if (skillRevenge == true)
                {

                }
                //Changing Skills UI and resetting CDS
                mTextUI.text = "Stealth\n(M)";
                nTextUI.text = "Execute\n(N)";
                bTextui.text = "Bomb\n(B)";
                for(int i = 0; i < 3; i++)
                {
                    SkillsUI[i].sprite = rogueSkillsSprites[i];
                    //SkillsUI[i].fillAmount = 1;
                }
                animator.SetTrigger("RogueSwap");
                animator.ResetTrigger("ClericSwap");
                animator.ResetTrigger("WarriorSwap");
                animator.ResetTrigger("RangerSwap");
                activeCharacter = 1;
                StatusUI.GetComponent<PlayerStatusUIManager>().ClearBuffs();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && isAttacking == false && warriorCurrHp > 0)
            {
                if (isStealth == true)
                {
                    UnStealth();
                }
                if (skillExecute == true)
                {
                    Stop_Execute();
                }
                //Changing Skills UI and resetting CDS
                mTextUI.text = "Ironheart\n(M)";
                nTextUI.text = "Revenge\n(N)";
                bTextui.text = "Sacrifice\n(B)";
                for (int i = 0; i < 3; i++)
                {
                    SkillsUI[i].sprite = warriorSkillsSprites[i];
                    //SkillsUI[i].fillAmount = 1;
                }
                animator.SetTrigger("WarriorSwap");
                animator.ResetTrigger("ClericSwap");
                animator.ResetTrigger("RogueSwap");
                animator.ResetTrigger("RangerSwap");
                activeCharacter = 2;
                StatusUI.GetComponent<PlayerStatusUIManager>().ClearBuffs();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && isAttacking == false && rangerCurrHp > 0)
            {
                if (isStealth == true)
                {
                    UnStealth();
                }
                if (skillExecute == true)
                {
                    Stop_Execute();
                }
                //Changing Skills UI and resetting CDS
                mTextUI.text = "Trap\n(M)";
                nTextUI.text = "Focus Shot\n(N)";
                bTextui.text = "Crippling \nShot\n(B)";
                for (int i = 0; i < 3; i++)
                {
                    SkillsUI[i].sprite = rangerSkillsSprites[i];
                    //SkillsUI[i].fillAmount = 1;
                }
                animator.SetTrigger("RangerSwap");
                animator.ResetTrigger("ClericSwap");
                animator.ResetTrigger("WarriorSwap");
                animator.ResetTrigger("RogueSwap");
                activeCharacter = 3;
                StatusUI.GetComponent<PlayerStatusUIManager>().ClearBuffs();
            }
            else if(Input.GetKeyDown(KeyCode.Alpha4) && isAttacking == false && clericCurrHp > 0)
            {
                if (isStealth == true)
                {
                    UnStealth();
                }
                if (skillExecute == true)
                {
                    Stop_Execute();
                }
                //Changing Skills UI and resetting CDS
                mTextUI.text = "Heal\n(M)";
                nTextUI.text = "Ressurection\n(N)";
                bTextui.text = "Raise The \nDead\n(B)";
                for (int i = 0; i < 3; i++)
                {
                    SkillsUI[i].sprite = clericSkillsSprites[i];
                    //SkillsUI[i].fillAmount = 1;
                }
                animator.SetTrigger("ClericSwap");
                animator.ResetTrigger("RengerSwap");
                animator.ResetTrigger("WarriorSwap");
                animator.ResetTrigger("RogueSwap");
                activeCharacter = 4;
                StatusUI.GetComponent<PlayerStatusUIManager>().ClearBuffs();
            }


            //Basic Attack
            if (Input.GetKeyDown(KeyCode.Space) && isAttacking == false)
            {
                if (activeCharacter == 1 || activeCharacter == 2 || activeCharacter == 4)
                {
                    StartCoroutine(BasicAttack());
                }
                else if(activeCharacter == 3)
                {
                    StartCoroutine(RangerBasicAttack());
                }
            }

            //Move function
            if (isMoving == false && sceneTransition == false && isRooted == false)
            {

                input.x = Input.GetAxisRaw("Horizontal");
                input.y = Input.GetAxisRaw("Vertical");
                if (input != Vector2.zero)
                {
                    //Debug.Log("Moving");
                    var targetPos = transform.position;
                    targetPos.x += input.x;
                    targetPos.y += input.y;
                    if (IsWalkable(targetPos))
                    {
                        StartCoroutine(Move(targetPos, input));
                    }
                }
            }


            //Rogue Skills
            if (activeCharacter == 1)
            {
                //Stealth skill
                if (Input.GetKeyDown(KeyCode.M) && isStealth == false && rogueCurrMp >= 10 && stealthCD == false)
                {
                    rogueCurrMp -= 10;
                    StartCoroutine(Skill_Stealth());
                }
                if (Input.GetKeyDown(KeyCode.N) && skillExecute == false && rogueCurrMp >= 10 && executeCD == false)
                {
                    Skill_Execute();
                }
                if (Input.GetKeyDown(KeyCode.B) && skillBomb == false && rogueCurrMp >= 10 && bombCD == false)
                {
                    StartCoroutine(Skill_Bomb());
                }
            }


            //Warrior Skills
            if (activeCharacter == 2)
            {
                if (Input.GetKeyDown(KeyCode.M) && isIronheart == false && warriorCurrMp >= 10 && ironheartCD == false)
                {
                    StartCoroutine(Skill_Ironheart());
                }
                if (Input.GetKeyDown(KeyCode.N) && skillRevenge == false && warriorCurrMp >= 10 && revengeCD == false)
                {
                    StartCoroutine(Skill_Revenge());
                }
                if (Input.GetKeyDown(KeyCode.B) && skillSacrifice == false && warriorCurrMp >= 10 && sacrificeCD == false)
                {
                    StartCoroutine(Skill_Sacrifice());
                }
                if(sacrificeAOE == true)
                {
                    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
                    foreach (Collider2D enemy in hitEnemies)
                    {
                        if (enemy.gameObject.layer == LayerMask.NameToLayer("Slime"))
                        {
                            enemy.GetComponent<testSlime>().Burned(sacrificeFireDOT, sacrificeFireDuration);
                        }
                        else if(enemy.gameObject.layer == LayerMask.NameToLayer("Goblin1"))
                        {
                            enemy.GetComponent<Goblin1Script>().Burned(sacrificeFireDOT, sacrificeFireDuration);
                        }
                        else if (enemy.gameObject.layer == LayerMask.NameToLayer("Goblin2"))
                        {
                            enemy.GetComponent<Goblin2Script>().Burned(sacrificeFireDOT, sacrificeFireDuration);
                        }
                        else if (enemy.gameObject.layer == LayerMask.NameToLayer("Worm"))
                        {
                            enemy.GetComponent<WormScript>().Burned(sacrificeFireDOT, sacrificeFireDuration);
                        }
                        else if (enemy.gameObject.layer == LayerMask.NameToLayer("Skeleton"))
                        {
                            enemy.GetComponent<SkeletonScript>().Burned(sacrificeFireDOT, sacrificeFireDuration);
                        }
                        else if (enemy.gameObject.layer == LayerMask.NameToLayer("Orc1"))
                        {
                            enemy.GetComponent<Orc1Script>().Burned(sacrificeFireDOT, sacrificeFireDuration);
                        }
                        else if (enemy.gameObject.layer == LayerMask.NameToLayer("Orc2"))
                        {
                            enemy.GetComponent<Orc2Script>().Burned(sacrificeFireDOT, sacrificeFireDuration);
                        }
                        else if (enemy.gameObject.layer == LayerMask.NameToLayer("Statue"))
                        {
                            enemy.GetComponent<StatueScript>().Burned(sacrificeFireDOT, sacrificeFireDuration);
                        }
                        else if (enemy.gameObject.layer == LayerMask.NameToLayer("Minotaur"))
                        {
                            enemy.GetComponent<MinotaurScript>().Burned(sacrificeFireDOT, sacrificeFireDuration);
                        }
                    }
                }
            }

            //Ranger skills
            if(activeCharacter == 3)
            {
                if (Input.GetKeyDown(KeyCode.M) && skillTrap == false && rangerCurrMp >= 10 && trapCD == false)
                {
                    StartCoroutine(Skill_Trap());
                }
                if(Input.GetKeyDown(KeyCode.N) && skillFocusShot == false && rangerCurrMp >= 10 && focusShotCD == false)
                {
                    Skill_FocusShot();
                }
                if (Input.GetKeyDown(KeyCode.B) && skillCripplingShot == false && rangerCurrMp >= 10 && cripplingShotCD == false)
                {
                    StartCoroutine(Skill_CripplingShot());
                }
            }

            //Cleric skills
            if(activeCharacter == 4)
            {
                if (Input.GetKeyDown(KeyCode.M) && skillHeal == false && clericCurrMp >= 10 && healCD == false)
                {
                    StartCoroutine(Skill_Heal());
                }
                if (Input.GetKeyDown(KeyCode.N) && skillRes == false && clericCurrMp >= 10 && resurrectionCD == false)
                {
                    StartCoroutine(Skill_Resurrection());
                }
                if (Input.GetKeyDown(KeyCode.B) && skillSummon == false && clericCurrMp >= 10 && raiseTheDeadCD == false)
                {
                    StartCoroutine(Skill_Summon());
                }
            }

        }
    }
    IEnumerator Move(Vector3 targetPos, Vector2 input)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon && sceneTransition == false && isRooted == false)
        {
            if (isSlowed == true)
            {
                moveSpeed = slowSpeed;
            }
            else
            {
                moveSpeed = normalSpeed;
            }
            if (activeCharacter == 1)
            {
                animator.SetBool("isMoving", true);
            }
            else if(activeCharacter == 2)
            {
                animator.SetBool("WarriorMoving", true);
            }
            else if (activeCharacter == 3)
            {
                animator.SetBool("RangerMoving", true);
            }
            else
            {
                animator.SetBool("ClericMoving", true);
            }


            if (input.x > 0)//moving right
            {
                lastMovingDirection = 1;
                mySpriteRenderer.flipX = false;
                attackPoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                attackPoint.transform.position = transform.position + distXPlayerToAttackPoint;
            }
            else if (input.x < 0)//moving left
            {
                lastMovingDirection = -1;
                mySpriteRenderer.flipX = true;
                attackPoint.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                attackPoint.transform.position = transform.position - distXPlayerToAttackPoint;
            }
            if (sceneTransition == true)
            {
                //Debug.Log("Broke");
                yield break;
            }
            else
            {
                //Debug.Log("Here");
                transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            }
            
            yield return null;
        }
        transform.position = targetPos;
        
        isMoving = false;
        animator.SetBool("isMoving", false);
        animator.SetBool("WarriorMoving", false);
        animator.SetBool("RangerMoving", false);
        animator.SetBool("ClericMoving", false);
        if (input.x > 0)
        {
            mySpriteRenderer.flipX = false;
            attackPoint.transform.position = transform.position + distXPlayerToAttackPoint;
        }
        if (input.x < 0)
        {
            mySpriteRenderer.flipX = true;
            attackPoint.transform.position = transform.position - distXPlayerToAttackPoint;
        }
    }

    IEnumerator BasicAttack()
    {
        isAttacking = true;
        animator.SetTrigger("basicAttack");
        animator.SetTrigger("WarriorAttack");
        animator.SetTrigger("ClericAttack");
        //animator.SetTrigger("RangerAttack");
        //Do a layer for every enemy type maybe and do below code for each layer 
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.layer == LayerMask.NameToLayer("Slime"))
            {
                if (activeCharacter == 1)
                {
                    enemy.GetComponent<testSlime>().Hit(rogueAttack);
                    if (poisonHit == true)
                    {
                        enemy.GetComponent<testSlime>().Poisoned(executePoisonDOT, executePoisonDuration);
                    }
                }
                else if (activeCharacter == 2)
                {
                    enemy.GetComponent<testSlime>().Hit(warriorAttack);
                    if (skillSacrifice == true)
                    {
                        enemy.GetComponent<testSlime>().Burned(sacrificeFireDOT, sacrificeFireDuration);
                    }

                }
                else if (activeCharacter == 4)
                {
                    enemy.GetComponent<testSlime>().Hit(clericAttack);
                }
                
            }

            else if(enemy.gameObject.layer == LayerMask.NameToLayer("Goblin1"))
            {
                if (activeCharacter == 1)
                {
                    enemy.GetComponent<Goblin1Script>().Hit(rogueAttack);
                    if (poisonHit == true)
                    {
                        enemy.GetComponent<Goblin1Script>().Poisoned(executePoisonDOT, executePoisonDuration);
                    }
                }
                else if (activeCharacter == 2)
                {
                    enemy.GetComponent<Goblin1Script>().Hit(warriorAttack);
                    if (skillSacrifice == true)
                    {
                        enemy.GetComponent<Goblin1Script>().Burned(sacrificeFireDOT, sacrificeFireDuration);
                    }

                }
                else if (activeCharacter == 4)
                {
                    enemy.GetComponent<Goblin1Script>().Hit(clericAttack);
                }
            }

            else if (enemy.gameObject.layer == LayerMask.NameToLayer("Goblin2"))
            {
                if (activeCharacter == 1)
                {
                    enemy.GetComponent<Goblin2Script>().Hit(rogueAttack);
                    if (poisonHit == true)
                    {
                        enemy.GetComponent<Goblin2Script>().Poisoned(executePoisonDOT, executePoisonDuration);
                    }
                }
                else if (activeCharacter == 2)
                {
                    enemy.GetComponent<Goblin2Script>().Hit(warriorAttack);
                    if (skillSacrifice == true)
                    {
                        enemy.GetComponent<Goblin2Script>().Burned(sacrificeFireDOT, sacrificeFireDuration);
                    }

                }
                else if (activeCharacter == 4)
                {
                    enemy.GetComponent<Goblin2Script>().Hit(clericAttack);
                }
            }
            else if (enemy.gameObject.layer == LayerMask.NameToLayer("Worm"))
            {
                if (activeCharacter == 1)
                {
                    enemy.GetComponent<WormScript>().Hit(rogueAttack);
                    if (poisonHit == true)
                    {
                        enemy.GetComponent<WormScript>().Poisoned(executePoisonDOT, executePoisonDuration);
                    }
                }
                else if (activeCharacter == 2)
                {
                    enemy.GetComponent<WormScript>().Hit(warriorAttack);
                    if (skillSacrifice == true)
                    {
                        enemy.GetComponent<WormScript>().Burned(sacrificeFireDOT, sacrificeFireDuration);
                    }

                }
                else if (activeCharacter == 4)
                {
                    enemy.GetComponent<WormScript>().Hit(clericAttack);
                }
            }
            else if (enemy.gameObject.layer == LayerMask.NameToLayer("Skeleton"))
            {
                if (activeCharacter == 1)
                {
                    enemy.GetComponent<SkeletonScript>().Hit(rogueAttack);
                    if (poisonHit == true)
                    {
                        enemy.GetComponent<SkeletonScript>().Poisoned(executePoisonDOT, executePoisonDuration);
                    }
                }
                else if (activeCharacter == 2)
                {
                    enemy.GetComponent<SkeletonScript>().Hit(warriorAttack);
                    if (skillSacrifice == true)
                    {
                        enemy.GetComponent<SkeletonScript>().Burned(sacrificeFireDOT, sacrificeFireDuration);
                    }

                }
                else if (activeCharacter == 4)
                {
                    enemy.GetComponent<SkeletonScript>().Hit(clericAttack);
                }
            }
            else if (enemy.gameObject.layer == LayerMask.NameToLayer("Orc1"))
            {
                if (activeCharacter == 1)
                {
                    enemy.GetComponent<Orc1Script>().Hit(rogueAttack);
                    if (poisonHit == true)
                    {
                        enemy.GetComponent<Orc1Script>().Poisoned(executePoisonDOT, executePoisonDuration);
                    }
                }
                else if (activeCharacter == 2)
                {
                    enemy.GetComponent<Orc1Script>().Hit(warriorAttack);
                    if (skillSacrifice == true)
                    {
                        enemy.GetComponent<Orc1Script>().Burned(sacrificeFireDOT, sacrificeFireDuration);
                    }

                }
                else if (activeCharacter == 4)
                {
                    enemy.GetComponent<Orc1Script>().Hit(clericAttack);
                }
            }
            else if (enemy.gameObject.layer == LayerMask.NameToLayer("Orc2"))
            {
                if (activeCharacter == 1)
                {
                    enemy.GetComponent<Orc2Script>().Hit(rogueAttack);
                    if (poisonHit == true)
                    {
                        enemy.GetComponent<Orc2Script>().Poisoned(executePoisonDOT, executePoisonDuration);
                    }
                }
                else if (activeCharacter == 2)
                {
                    enemy.GetComponent<Orc2Script>().Hit(warriorAttack);
                    if (skillSacrifice == true)
                    {
                        enemy.GetComponent<Orc2Script>().Burned(sacrificeFireDOT, sacrificeFireDuration);
                    }

                }
                else if (activeCharacter == 4)
                {
                    enemy.GetComponent<Orc2Script>().Hit(clericAttack);
                }
            }
            else if (enemy.gameObject.layer == LayerMask.NameToLayer("Statue"))
            {
                if (activeCharacter == 1)
                {
                    enemy.GetComponent<StatueScript>().Hit(rogueAttack);
                    if (poisonHit == true)
                    {
                        enemy.GetComponent<StatueScript>().Poisoned(executePoisonDOT, executePoisonDuration);
                    }
                }
                else if (activeCharacter == 2)
                {
                    enemy.GetComponent<StatueScript>().Hit(warriorAttack);
                    if (skillSacrifice == true)
                    {
                        enemy.GetComponent<StatueScript>().Burned(sacrificeFireDOT, sacrificeFireDuration);
                    }

                }
                else if (activeCharacter == 4)
                {
                    enemy.GetComponent<StatueScript>().Hit(clericAttack);
                }
            }
            else if (enemy.gameObject.layer == LayerMask.NameToLayer("Minotaur"))
            {
                if (activeCharacter == 1)
                {
                    enemy.GetComponent<MinotaurScript>().Hit(rogueAttack);
                    if (poisonHit == true)
                    {
                        enemy.GetComponent<MinotaurScript>().Poisoned(executePoisonDOT, executePoisonDuration);
                    }
                }
                else if (activeCharacter == 2)
                {
                    enemy.GetComponent<MinotaurScript>().Hit(warriorAttack);
                    if (skillSacrifice == true)
                    {
                        enemy.GetComponent<MinotaurScript>().Burned(sacrificeFireDOT, sacrificeFireDuration);
                    }

                }
                else if (activeCharacter == 4)
                {
                    enemy.GetComponent<MinotaurScript>().Hit(clericAttack);
                }
            }

        }
        if (isStealth == true)
        {
            UnStealth();
        }
        if(skillExecute == true)
        {
            Stop_Execute();
        }
        yield return new WaitForSeconds(0.5f);
        animator.ResetTrigger("basicAttack");
        animator.ResetTrigger("WarriorAttack");
        animator.ResetTrigger("ClericAttack");
        //animator.ResetTrigger("RangerAttack");
        isAttacking = false;
    }

    IEnumerator RangerBasicAttack()
    {
        //Debug.Log("here");
        arrow.GetComponent<ArrowCollision>().arrowDmg = rangerAttack; //I could just have this under level up tbh, but for now will leave here
        isAttacking = true;
        animator.SetTrigger("RangerAttack");
        GameObject shotArrow = Instantiate(arrow, attackPoint.position, attackPoint.rotation);
        Rigidbody2D rb = shotArrow.GetComponent<Rigidbody2D>();
        if(skillCripplingShot == true)
        {
            if(rangerCripplingShotLvl == 3)
            {
                shotArrow.GetComponent<ArrowCollision>().markOnHit = true;
            }
            shotArrow.GetComponent<ArrowCollision>().cripplingShot = true;
        }
        if(lastMovingDirection == 1)
        {
            rb.AddForce(new Vector2(1000.0f, 0));
        }
        else
        {
            rb.AddForce(new Vector2(-1000.0f, 0));
        }
        
        if(skillFocusShot == true)
        {
            Stop_FocusShot();
        }
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
        animator.ResetTrigger("RangerAttack");
    }

    //Just using for testing attack range, can be useful for alot of things
    /*
    void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }

    }*/
    
    //Using layermask for solidobjects to determine if my targetpos(where ym character will go) is viable
    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectsLayer) != null)
        {
            return false;
        }
        return true;
    }

    public int Hit(int damage)
    {
        //currHp -= damage;
        //Debug.Log(currHp);
        //hpText.text = currHp.ToString();
        int damageBeforeDefense = damage;
        if (activeCharacter == 1)
        {
            damage -= rogueDefense;
            if(damage < 0)
            {
                damage = 0;
            }
            rogueCurrHp -= damage;
            if (rogueCurrHp <= 0)
            {
                animator.SetBool("isDead", true);
                StartCoroutine(charDeath(1));
            }
        }

        else if (activeCharacter == 2)
        {
         
            damage -= warriorDefense;
            warriorCurrHp -= damage;
            if (warriorCurrHp <= 0)
            {
                animator.SetBool("WarriorDead", true);
                StartCoroutine(charDeath(2));
            }
        }

        else if (activeCharacter == 3)
        {
            damage -= rangerDefense;
            rangerCurrHp -= damage;
            if (rangerCurrHp <= 0)
            {
                animator.SetBool("RangerDead", true);
                StartCoroutine(charDeath(3));
            }
        }
        else
        {
            damage -= clericDefense;
            clericCurrHp -= damage;
            if (clericCurrHp <= 0)
            {
                animator.SetBool("ClericDead", true);
                StartCoroutine(charDeath(4));
            }
        }
        ShowDmgText(damage);
        

        if (skillRevenge == true && activeCharacter == 2)
        {
            int revengeDamage = 0;
            if (warriorRevengeLvl == 1)
            {
                revengeDamage = damageBeforeDefense;
            }
            else if(warriorRevengeLvl == 2)
            {
                revengeDamage = (int)(damageBeforeDefense * 1.3);
            }
            else
            {
                revengeDamage = (int)(damageBeforeDefense * 1.6);
            }
            
            return revengeDamage;
        }
        else
        {
            return 0;
        }

        
    }

    //Called from enemy script on death
    public void LevelUp(int exp)
    {
        if(activeCharacter == 1)
        {
            rogueCurrExp += exp; 
            if (rogueCurrExp >= rogueExptoNextLvl)
            {
                rogueCurrExp -= rogueExptoNextLvl;
                rogueCurrLvl += 1;
                rogueExptoNextLvl *= 2;
                rogueSkillPoints += 1;
                rogueAttributePoints += 5;
            }

        }
        else if(activeCharacter == 2)
        {
            warriorCurrExp += exp;
            if (warriorCurrExp >= warriorExptoNextLvl)
            {
                warriorCurrExp -= warriorExptoNextLvl;
                warriorCurrLvl += 1;
                warriorExptoNextLvl *= 2;
                warriorSkillPoints += 1;
                warriorAttributePoints += 5;
            }
        }
        else if (activeCharacter == 3)
        {
            rangerCurrExp += exp;
            if (rangerCurrExp >= rangerExptoNextLvl)
            {
                rangerCurrExp -= rangerExptoNextLvl;
                rangerCurrLvl += 1;
                rangerExptoNextLvl *= 2;
                rangerSkillPoints += 1;
                rangerAttributePoints += 5;
            }
        }
        else
        {
            clericCurrExp += exp;
            if (clericCurrExp >= clericExptoNextLvl)
            {
                clericCurrExp -= clericExptoNextLvl;
                clericCurrLvl += 1;
                clericExptoNextLvl *= 2;
                clericSkillPoints += 1;
                clericAttributePoints += 5;
            }
        }
    }

    //Called on char death to handle switching to other chars or if all dead then death screen and respawn at last checkpoint
    IEnumerator charDeath(int deadChar)
    {
        int charToSpawn = 0;
        if (rogueCurrHp > 0)
        {
            charToSpawn = 1;
        }
        else if(warriorCurrHp > 0)
        {
            charToSpawn = 2;
        }
        else if(rangerCurrHp > 0)
        {
            charToSpawn = 3;
        }
        else if(clericCurrHp > 0)
        {
            charToSpawn = 4;
        }
        yield return new WaitForSeconds(0.5f);
        if (charToSpawn == 1)
        {
            //Cycle between other chars, for now just rogue and warrior, change conditionals accordingly
            animator.SetTrigger("RogueSwap");
            animator.ResetTrigger("WarriorSwap");
            animator.ResetTrigger("RangerSwap");
            animator.ResetTrigger("ClericSwap");
            //animator.ResetTrigger("RogueSwap");
            activeCharacter = 1;
            hpBar.fillAmount = (float)rogueCurrHp / (float)rogueMaxHp;
            mTextUI.text = "Stealth\n(M)";
            nTextUI.text = "Execute\n(N)";
            bTextui.text = "Bomb\n(N)";
            for (int i = 0; i < 3; i++)
            {
                SkillsUI[i].sprite = rogueSkillsSprites[i];
                //SkillsUI[i].fillAmount = 1;
            }
        }
        else if(charToSpawn == 2)
        {
            animator.SetTrigger("WarriorSwap");
            animator.ResetTrigger("RogueSwap");
            animator.ResetTrigger("RangerSwap");
            animator.ResetTrigger("ClericSwap");
            //animator.ResetTrigger("WarriorSwap");
            hpBar.fillAmount = (float)warriorCurrHp / (float)warriorMaxHp;
            activeCharacter = 2;
            mTextUI.text = "Ironheart\n(M)";
            nTextUI.text = "Revenge\n(N)";
            bTextui.text = "Sacrifice\n(N)";
            for (int i = 0; i < 3; i++)
            {
                SkillsUI[i].sprite = warriorSkillsSprites[i];
                //SkillsUI[i].fillAmount = 1;
            }
        }
        else if (charToSpawn == 3)
        {
            animator.SetTrigger("RangerSwap");
            animator.ResetTrigger("WarriorSwap");
            animator.ResetTrigger("RogueSwap");
            animator.ResetTrigger("ClericSwap");
            //animator.ResetTrigger("WarriorSwap");
            activeCharacter = 3;
            hpBar.fillAmount = (float)rangerCurrHp / (float)rangerMaxHp;
            mTextUI.text = "Trap\n(M)";
            nTextUI.text = "Focus Shot\n(N)";
            bTextui.text = "Crippling \nShot\n(N)";
            for (int i = 0; i < 3; i++)
            {
                SkillsUI[i].sprite = rangerSkillsSprites[i];
                //SkillsUI[i].fillAmount = 1;
            }
        }
        else if(charToSpawn == 4)
        {
            animator.SetTrigger("ClericSwap");
            animator.ResetTrigger("WarriorSwap");
            animator.ResetTrigger("RangerSwap");
            animator.ResetTrigger("RogueSwap");
            //animator.ResetTrigger("WarriorSwap");
            activeCharacter = 4;
            mTextUI.text = "Heal\n(M)";
            nTextUI.text = "Ressurection\n(N)";
            bTextui.text = "Raise The \nDead\n(N)";
            for (int i = 0; i < 3; i++)
            {
                SkillsUI[i].sprite = clericSkillsSprites[i];
                //SkillsUI[i].fillAmount = 1;
            }
            hpBar.fillAmount = (float)clericCurrHp / (float)clericMaxHp;
        }
        else
        {
            //Place holder for now, I dont want to ever destory this game object. Just send back to a town or healing place after death message
            Destroy(gameObject);
        }
        animator.SetBool("isDead", false);
        animator.SetBool("WarriorDead", false);
        animator.SetBool("RangerDead", false);
        animator.SetBool("ClericDead", false);
    }


    private void ShowDmgText(int damage)
    {
        Vector3 offset = new Vector3(3.2f, 2.4f, 0.0f);
        Text dmgText = Instantiate(hitText, transform.position, Quaternion.identity);
        dmgText.transform.SetParent(playerCanvas.transform, false);
        dmgText.transform.position = transform.position + offset;
        dmgText.text = damage.ToString();
    }

    private void ShowStatusText(string status)
    {
        Vector3 offset = new Vector3(3.2f, 2.8f, 0.0f);
        Text dmgText = Instantiate(hitText, transform.position, Quaternion.identity);
        dmgText.transform.SetParent(playerCanvas.transform, false);
        dmgText.transform.position = transform.position + offset;
        dmgText.text = status;
    }

    //Rogue Skills & related functions

    IEnumerator Skill_Stealth()
    {
        if (isStealth == false)
        {
            passiveStealth = true;
            int bonusAttack = 0;
            if (rogueStealthLvl == 1)
            {
                bonusAttack = (int)(rogueAttack * 1.5);
                
            }
            else
            {
                bonusAttack = (int)(rogueAttack * 3);
            }

            for (float f = 1f; f >= 0.5; f -= 0.05f)
            {
                Color c = mySpriteRenderer.material.color;
                c.a = f;
                mySpriteRenderer.material.color = c;
                yield return new WaitForSeconds(0.05f);
            }
            isStealth = true;
            rogueAttack += bonusAttack;
            rogueBonusAttack = bonusAttack;
            StatusUI.GetComponent<PlayerStatusUIManager>().AddBuffs(0);
            StartCoroutine(ShowCooldown(5.0f, 0));
            time1 = 0.0f;
        }
    }

    private void UnStealth()
    {
        Color c = mySpriteRenderer.material.color;
        c.a = 1.0f;
        mySpriteRenderer.material.color = c;
        passiveStealth = false;
        isStealth = false;
        StatusUI.GetComponent<PlayerStatusUIManager>().RemoveBuffs(0);
        rogueAttack -= rogueBonusAttack; 
    }

    private void Skill_Execute()
    {
        int bonusAttack = 0;
        bonusAttack = (int)(rogueAttack * 2);
        if (rogueExecuteLvl == 2)
        {
            rogueBonusCrRate = 30;
            rogueBonusCrDmg = 0.4f;
            rogueCrRate += rogueBonusCrRate;
            rogueCrDmg += rogueBonusCrDmg;
        }
        if(rogueExecuteLvl >= 3)
        {
            poisonHit = true;
        }
        rogueCurrMp -= 10;
        skillExecute = true;
        rogueAttack += bonusAttack;
        rogueBonustAttack2 = bonusAttack;
        
        StatusUI.GetComponent<PlayerStatusUIManager>().AddBuffs(1);
        StartCoroutine(ShowCooldown(3.0f, 1));
        //Debug.Log(rogueAttack);
    }

    private void Stop_Execute()
    {
        if(rogueBonusCrRate >= 0)
        {
            rogueCrRate -= rogueBonusCrRate;
            rogueCrDmg -= rogueBonusCrDmg;
        }
        
        poisonHit = false;
        rogueAttack -= rogueBonustAttack2;
        skillExecute = false;
        StatusUI.GetComponent<PlayerStatusUIManager>().RemoveBuffs(1);
    }

    IEnumerator Skill_Bomb()
    {
        Vector3 bombPos = attackPoint.transform.position + distYPlayerToGround;
        if(rogueBombLvl == 1)
        {
            bomb.GetComponent<BombScript>().stunChance = 0;
            bomb.GetComponent<BombScript>().stunDuration = 0;
        }
        else if (rogueBombLvl == 2)
        {
            if (isStealth == true)
            {
                bomb.GetComponent<BombScript>().stealth = isStealth;
                bomb.GetComponent<BombScript>().stunChance = 50;
                bomb.GetComponent<BombScript>().stunDuration = 3;
            }
        }
        else if(rogueBombLvl == 3)
        {
            if (isStealth == true)
            {
                bomb.GetComponent<BombScript>().stealth = isStealth;
                bomb.GetComponent<BombScript>().stunChance = 75;
                bomb.GetComponent<BombScript>().stunDuration = 4;
            }

        }

        Instantiate(bomb, bombPos, Quaternion.identity);
        rogueCurrMp -= 10;
        skillBomb = true;

        StartCoroutine(ShowCooldown(2.0f, 2));
        yield return new WaitForSeconds(2.0f);
        skillBomb = false;
    }


    //Warrior Skills and related functions
    IEnumerator Skill_Ironheart()
    {
        warriorCurrMp -= 10;
        int bonusAttack = 0;
        int bonusDefense = 0;
        if(warriorIronheartLvl == 1)
        {
            bonusAttack = (int)(warriorAttack*1.2);
            bonusDefense = (int)(warriorDefense * 1.2);
        }
        if (warriorIronheartLvl == 1)
        {
            bonusAttack = (int)(warriorAttack * 1.3);
            bonusDefense = (int)(warriorDefense * 1.3);
        }
        if (warriorIronheartLvl == 1)
        {
            bonusAttack = (int)(warriorAttack * 1.4);
            bonusDefense = (int)(warriorDefense * 1.4);
        }

        warriorAttack += bonusAttack;
        warriorDefense += bonusDefense;
        isIronheart = true;
        StatusUI.GetComponent<PlayerStatusUIManager>().AddBuffs(2);
        StartCoroutine(ShowCooldown(5.0f, 0));
        yield return new WaitForSeconds(5.0f);
        StatusUI.GetComponent<PlayerStatusUIManager>().RemoveBuffs(2);
        warriorAttack -= bonusAttack;
        warriorDefense -= bonusDefense;
        isIronheart = false;
    }

    IEnumerator Skill_Revenge()
    {
        //Revenge damage is done in hit function
        warriorCurrMp -= 10;
        skillRevenge = true;
        StatusUI.GetComponent<PlayerStatusUIManager>().AddBuffs(3);
        StartCoroutine(ShowCooldown(5.0f, 1));
        yield return new WaitForSeconds(5.0f);
        StatusUI.GetComponent<PlayerStatusUIManager>().RemoveBuffs(3);
        skillRevenge = false;
    }

    IEnumerator Skill_Sacrifice()
    {
        int duration = 5;
        float selfDamage = 0.05f;
        int bonusAttack = (int)(warriorAttack*0.25);
        if(warriorSacrificeLvl == 3)
        {
            selfDamage = 0.03f;
        }
        if(warriorSacrificeLvl >= 2)
        {
            sacrificeAOE = true;
        }
        int damage = (int)(warriorMaxHp * selfDamage);
        warriorCurrMp -= 10;
        skillSacrifice = true;
        StatusUI.GetComponent<PlayerStatusUIManager>().AddBuffs(4);
        warriorAttack += bonusAttack;
        for(int i = 0; i < duration; i++)
        {
            ShowDmgText(damage);
            warriorCurrHp -= damage;
            yield return new WaitForSeconds(1);
        }
        StartCoroutine(ShowCooldown(10.0f, 2));
        //yield return new WaitForSeconds(duration);
        StatusUI.GetComponent<PlayerStatusUIManager>().RemoveBuffs(4);
        skillSacrifice = false;
        sacrificeAOE = false;
        warriorAttack -= bonusAttack;
    }


    //Ranger skills and related functions
    IEnumerator Skill_Trap()
    {
        rangerCurrMp -= 10;
        skillTrap = true;
        Vector3 trapPos = attackPoint.transform.position + distYPlayerToGround;
        if(rangerTrapLvl == 1)
        {
            trap.GetComponent<TrapScript>().rootDuration = 3;
            trap.GetComponent<TrapScript>().markDuration = 0;
        }
        else if(rangerTrapLvl == 2)
        {
            trap.GetComponent<TrapScript>().rootDuration = 5;
        }
        else
        {
            trap.GetComponent<TrapScript>().rootDuration = 5;
            trap.GetComponent<TrapScript>().markDuration = 5;
        }
        Instantiate(trap, trapPos, Quaternion.identity);
        StartCoroutine(ShowCooldown(2.0f, 0));
        yield return new WaitForSeconds(2.0f);
        skillTrap = false;
    }

    private void Skill_FocusShot()
    {
        rangerCurrMp -= 10;
        skillFocusShot = true;
        if(rangerFocusShotLvl == 1)
        {
            bonusArrowDamage = (int)(rangerAttack * 1.5);
        }
        else if(rangerFocusShotLvl == 2)
        {
            bonusArrowDamage = (int)(rangerAttack * 1.7);
        }
        else if(rangerFocusShotLvl == 3)
        {
            bonusArrowDamage = (int)(rangerAttack * 1.7);
            rangerBonusCrRate = 20;
            rangerBonusCrDmg = 0.2f;
            rangerCrRate += rangerBonusCrRate;
            rangerCrDmg += rangerBonusCrDmg;
        }
        rangerAttack += bonusArrowDamage;
        StatusUI.GetComponent<PlayerStatusUIManager>().AddBuffs(5);
        StartCoroutine(ShowCooldown(3.0f, 1));


    }

    private void Stop_FocusShot()
    {
        if(rangerBonusCrRate >= 0)
        {
            rangerCrRate -= rangerBonusCrRate;
            rangerCrDmg -= rangerBonusCrDmg;
        }
        skillFocusShot = false;
        rangerAttack -= bonusArrowDamage;
        StatusUI.GetComponent<PlayerStatusUIManager>().RemoveBuffs(5);
    }

    IEnumerator Skill_CripplingShot()
    {
        int duration = 0;
        if(rangerCripplingShotLvl == 1)
        {
            duration = 3;
        }
        else
        {
            duration = 5;
        }
        rangerCurrMp -= 10;
        skillCripplingShot = true;
        StatusUI.GetComponent<PlayerStatusUIManager>().AddBuffs(6);
        yield return new WaitForSeconds(duration);
        StartCoroutine(ShowCooldown(10.0f, 2));
        StatusUI.GetComponent<PlayerStatusUIManager>().RemoveBuffs(6);
        skillCripplingShot = false;
    }


    //Cleric skills and related functions
    IEnumerator Skill_Heal()
    {
        animator.SetTrigger("ClericHeal");
        clericCurrMp -= 10;
        skillHeal = true;
        float healAmount = 0;
        if(clericHealLvl == 1)
        {
            healAmount = 0.20f;
        }
        else if(clericHealLvl == 2)
        {
            healAmount = 0.25f;
        }
        else
        {
            healAmount = 0.30f;
        }

        if (rogueCurrHp > 0)
        {
            rogueCurrHp += (int)(rogueCurrHp * healAmount);
        }
        if(warriorCurrHp > 0)
        {
            warriorCurrHp += (int)(warriorCurrHp * healAmount);
        }
        if(rangerCurrHp > 0)
        {
            rangerCurrHp += (int)(rangerCurrHp * healAmount);
        }
        if(clericCurrHp > 0)
        {
            clericCurrHp += (int)(clericCurrHp * healAmount);
        }
        StartCoroutine(ShowCooldown(3.0f, 0));
        yield return new WaitForSeconds(3.0f);
        animator.ResetTrigger("ClericHeal");
        skillHeal = false;
    }

    IEnumerator Skill_Resurrection()
    {
        animator.SetTrigger("ClericHeal");
        skillRes = true;
        float resHealth = 0;
        if(clericResurrectionLvl == 1)
        {
            resHealth = 0.1f;
        }
        else if(clericResurrectionLvl == 2)
        {
            resHealth = 0.2f;
        }
        else
        {
            resHealth = 0.3f;
        }


        if(rogueCurrHp <= 0)
        {
            rogueCurrHp = (int)(rogueMaxHp * resHealth);
            animator.SetBool("isDead", false);
        }
        if(warriorCurrHp <= 0)
        {
            warriorCurrHp = (int)(warriorMaxHp * resHealth);
            animator.SetBool("WarriorDead", false);
        }
        if (rangerCurrHp <= 0)
        {
            rangerCurrHp = (int)(rangerMaxHp * resHealth);
            animator.SetBool("RangerDead", false);
        }
        if (clericCurrHp <= 0)
        {
            clericCurrHp = (int)(clericMaxHp * resHealth);
            animator.SetBool("ClericDead", false);
        }
        StartCoroutine(ShowCooldown(5.0f, 1));
        yield return new WaitForSeconds(5.0f);
        animator.ResetTrigger("ClericHeal");
        skillRes = false;
    }

    IEnumerator Skill_Summon()
    {
        skillSummon = true;
        animator.SetTrigger("ClericHeal");
        //animator.ResetTrigger("ClericHeal");
        //Debug.Log(clericRaiseTheDeadLvl);
        if (clericRaiseTheDeadLvl == 1)
        {
            
            Vector3 offset;
            if(lastMovingDirection == 1)
            {
                offset = new Vector3(0, 1, 0);
            }
            else
            {
                offset = new Vector3(0, 1, 0);
            }
            
            eyeballSummon.GetComponent<EyeballSummonScript>().eyeballAttack = clericAttack;
            GameObject eyeball = Instantiate(eyeballSummon, transform.position+offset, Quaternion.identity);
            eyeball.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(15);
            skillSummon = false;
            Destroy(eyeball);
        }
        else if(clericRaiseTheDeadLvl == 2)
        {
            Vector3 offset;
            if (lastMovingDirection == 1)
            {
                offset = new Vector3(0, 1, 0);
            }
            else
            {
                offset = new Vector3(0, 1, 0);
            }

            eyeballSummon.GetComponent<EyeballSummonScript>().eyeballAttack = clericAttack;
            GameObject eyeball = Instantiate(eyeballSummon, transform.position + offset, Quaternion.identity);
            eyeball.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(25);
            skillSummon = false;
            Destroy(eyeball);
        }
        else
        {
            Vector3 offset;
            if (lastMovingDirection == 1)
            {
                offset = new Vector3(0, 1, 0);
            }
            else
            {
                offset = new Vector3(0, 1, 0);
            }

            eyeballSummon.GetComponent<EyeballSummonScript>().eyeballAttack = clericAttack;
            GameObject eyeball = Instantiate(eyeballSummon, transform.position + offset, Quaternion.identity);
            eyeball.transform.parent = gameObject.transform;
        }
        animator.ResetTrigger("ClericHeal");
        //StartCouroutine(ShowCooldown(25.0f, 2));
        yield return null;
    }

    //Vendor heal
    public void HealParty()
    {
        int price = 10;
        if (InventoryManager.gold >= price)
        {
            rogueCurrHp = rogueMaxHp;
            rogueCurrMp = rogueMaxMp;
            warriorCurrHp = warriorMaxHp;
            warriorCurrMp = warriorMaxMp;
            rangerCurrHp = rangerMaxHp;
            rangerCurrMp = rangerMaxMp;
            clericCurrHp = clericMaxHp;
            clericCurrMp = clericMaxMp;
            currCharHpUI.fillAmount = 1;
            currCharMpUI.fillAmount = 1;
            hpBar.fillAmount = 1;
            InventoryManager.gold -= price;
        }
    }

    //Potions
    public void HpPotionBtnClick()
    {
        if (healthPotCD == false && currCharHpUI.fillAmount < 1.0f)
        {
            StartCoroutine(HpPotion());
        }
    }
    public IEnumerator HpPotion()
    {
        healthPotCD = true;
        float hpPotStrength = 0.2f;
        if(InventoryManager.healthPots > 0)
        {
            InventoryManager.healthPots--;
            if(activeCharacter == 1)
            {
                rogueCurrHp = rogueCurrHp + (int)(rogueCurrHp * hpPotStrength);
            }
            else if(activeCharacter == 2)
            {
                warriorCurrHp = warriorCurrHp + (int)(warriorCurrHp * hpPotStrength);
            }
            else if(activeCharacter == 3)
            {
                rangerCurrHp = rangerCurrHp + (int)(rangerCurrHp * hpPotStrength);
            }
        }
        yield return new WaitForSeconds(5.0f);
        healthPotCD = false;
    }

    public void MpPotionBtnClick()
    {
        if(manaPotCD == false && currCharMpUI.fillAmount < 1.0f)
        {
            StartCoroutine(MpPotion());
        }
    }

    public IEnumerator MpPotion()
    {
        manaPotCD = true;
        float manaPotStrength = 0.2f;
        if (InventoryManager.manaPots > 0)
        {
            InventoryManager.manaPots--;
            if (activeCharacter == 1)
            {
                rogueCurrMp = rogueCurrMp + (int)(rogueCurrMp * manaPotStrength);
            }
            else if (activeCharacter == 2)
            {
                warriorCurrMp = warriorCurrMp + (int)(warriorCurrMp * manaPotStrength);
            }
            else if (activeCharacter == 3)
            {
                rangerCurrMp = rangerCurrMp + (int)(rangerCurrMp * manaPotStrength);
            }
        }
        yield return new WaitForSeconds(1.0f);
        manaPotCD = false;
    }


    IEnumerator ShowCooldown(float duration, int skill)
    {
        float currTime = Time.timeSinceLevelLoad;
        float endTime = Time.timeSinceLevelLoad+duration;
        float tempTime1 = 0.0f;
        float tempTime2 = endTime - currTime;
        //Setting CDS
        if(skill == 0)
        {
            stealthCD = true;
            ironheartCD = true;
            trapCD = true;
            healCD = true;
        }
        else if(skill == 1)
        {
            executeCD = true;
            revengeCD = true;
            focusShotCD = true;
            resurrectionCD = true;

        }
        else if(skill == 2)
        {
            bombCD = true;
            sacrificeCD = true;
            cripplingShotCD = true;
            raiseTheDeadCD = true;
        }
        while (tempTime1 < 1.00f)
        {
            tempTime1 = Time.timeSinceLevelLoad - currTime;
            tempTime1 = tempTime1 / tempTime2;
            SkillsUI[skill].fillAmount = tempTime1;
            //Debug.Log(tempTime1);
            yield return null;
        }
        //Restting CDS
        if (skill == 0)
        {
            stealthCD = false;
            ironheartCD = false;
            trapCD = false;
            healCD = false;
        }
        else if (skill == 1)
        {
            executeCD = false;
            revengeCD = false;
            focusShotCD = false;
            resurrectionCD = false;

        }
        else if (skill == 2)
        {
            bombCD = false;
            sacrificeCD = false;
            cripplingShotCD = false;
            raiseTheDeadCD = false;
        }
        yield return null;
    }

    //Having trouble when I get stunned and kill goblin at the same time, i think has to do with returning a value to a destroyed object hence why I am using this void function to take the call 
    public void CallStunned(int chance, float duration)
    {
        StartCoroutine(Stunned(chance, duration));
    }
    //Status effects
    //Technically only one char can be stunned
    public IEnumerator Stunned(int chance, float duration)
    {
        //Debug.Log("stunned");
        int rnd = Random.Range(1, 100);
        if (activeCharacter == 1)
        {
            if (chance > rnd)
            {
                extraStunCounter++;
                isStunned = true;
                AddStatusEffect(0, false);
                ShowStatusText("STUNNED");
                yield return new WaitForSeconds(duration);
                extraStunCounter--;
                if (extraStunCounter == 0)
                {
                    isStunned = false;
                    RemoveStatusEffect(0, 1);
                }
            }
        }
        else if(activeCharacter == 2)
        {
            if (chance > rnd)
            {
                extraStunCounter++;
                isStunned = true;
                AddStatusEffect(0, false);
                ShowStatusText("STUNNED");
                yield return new WaitForSeconds(duration);
                extraStunCounter--;
                if (extraStunCounter == 0)
                {
                    isStunned = false;
                    RemoveStatusEffect(0, 2);
                }
            }
        }
        else if (activeCharacter == 3)
        {
            if (chance > rnd)
            {
                extraStunCounter++;
                isStunned = true;
                AddStatusEffect(0, false);
                ShowStatusText("STUNNED");
                yield return new WaitForSeconds(duration);
                extraStunCounter--;
                if (extraStunCounter == 0)
                {
                    isStunned = false;
                    RemoveStatusEffect(0, 3);
                }
            }
        }
        else if (activeCharacter == 4)
        {
            if (chance > rnd)
            {
                extraStunCounter++;
                isStunned = true;
                AddStatusEffect(0, false);
                ShowStatusText("STUNNED");
                yield return new WaitForSeconds(duration);
                extraStunCounter--;
                if (extraStunCounter == 0)
                {
                    isStunned = false;
                    RemoveStatusEffect(0, 4);
                }
            }
        }
        yield return null;
    }

    public void CallRooted(int duration, int chance)
    {
        StartCoroutine(Rooted(duration, chance));
    }
    IEnumerator Rooted(int duration, int chance)
    {
        int rnd = Random.Range(1, 100);
        if (chance > rnd)
        {
            extraRootCounter++;
            isRooted = true;
            AddStatusEffect(1, true);
            ShowStatusText("ROOTED");
            yield return new WaitForSeconds(duration);
            extraRootCounter--;
            if (extraRootCounter <= 0)
            {
                isRooted = false;
                RemoveStatusEffect(1, 10);
            }
        }
        
    }

    public void CallSlowed(int duration, int chance)
    {
        StartCoroutine(Slowed(duration, chance));
    }

    IEnumerator Slowed(int duration, int chance)
    {
        int rnd = Random.Range(1, 100);
        if(chance > rnd)
        {
            extraSlowCounter++;
            isSlowed = true;
            AddStatusEffect(3, true);
            yield return new WaitForSeconds(duration);
            extraSlowCounter--;
            if(extraSlowCounter <= 0)
            {
                isSlowed = false;
                RemoveStatusEffect(3, 10);
            }
        }
    }

    public void CallBurned(int duration, float DOT)
    {
        StartCoroutine(Burned(duration, DOT));
    }

    IEnumerator Burned(int duration, float DOT)
    {
        if(activeCharacter == 1)
        {
            int i;
            int dotDamage;
            rogueBurnCounter++;
            if (rogueBurned == true)
            {
                i = 0;
            }
            rogueBurned = true;
            AddStatusEffect(5, false);
            for (i = 0; i < duration; i++)
            {
                dotDamage = (int)(rogueMaxHp * DOT);
                rogueCurrHp = (int)(rogueCurrHp - dotDamage);
                if(activeCharacter == 1)
                {
                    ShowDmgText(dotDamage);
                    if (rogueCurrHp <= 0)
                    {
                        animator.SetBool("isDead", true);
                        StartCoroutine(charDeath(1));
                    }
                }

                yield return new WaitForSeconds(1.0f);
            }
            rogueBurnCounter--;
            if(rogueBurnCounter <= 0)
            {
                rogueBurned = false;
                RemoveStatusEffect(5, 1);
            }
            
        }
        else if(activeCharacter == 2)
        {
            int i;
            int dotDamage;
            if (warriorBurned == true)
            {
                i = 0;
            }
            warriorBurned = true;
            AddStatusEffect(5, false);
            for (i = 0; i < duration; i++)
            {
                dotDamage = (int)(warriorMaxHp * DOT);
                warriorCurrHp = (int)(warriorCurrHp - dotDamage);
                if (activeCharacter == 2)
                {
                    ShowDmgText(dotDamage);
                    if (warriorCurrHp <= 0)
                    {
                        animator.SetBool("WarriorDead", true);
                        StartCoroutine(charDeath(2));
                    }
                }
                yield return new WaitForSeconds(1.0f);
            }
            warriorBurnCounter--;
            if (warriorBurnCounter <= 0)
            {
                warriorBurned = false;
                RemoveStatusEffect(5, 1);
            }

        }
        else if(activeCharacter == 3)
        {
            int i;
            int dotDamage;
            if (rangerBurned == true)
            {
                i = 0;
            }
            rangerBurned = true;
            AddStatusEffect(5, false);
            for (i = 0; i < duration; i++)
            {
                dotDamage = (int)(rangerMaxHp * DOT);
                rangerCurrHp = (int)(rangerCurrHp - dotDamage);
                if (activeCharacter == 3)
                {
                    ShowDmgText(dotDamage);
                    if (rangerCurrHp <= 0)
                    {
                        animator.SetBool("RangerDead", true);
                        StartCoroutine(charDeath(3));
                    }
                }
                yield return new WaitForSeconds(1.0f);
            }
            rangerBurnCounter--;
            if (rangerBurnCounter <= 0)
            {
                rangerBurned = false;
                RemoveStatusEffect(5, 1);
            }
        }
        else if (activeCharacter == 4)
        {
            int i;
            int dotDamage;
            if (clericBurned == true)
            {
                i = 0;
            }
            clericBurned = true;
            AddStatusEffect(5, false);
            for (i = 0; i < duration; i++)
            {
                dotDamage = (int)(clericMaxHp * DOT);
                clericCurrHp = (int)(clericCurrHp - dotDamage);
                if (activeCharacter == 4)
                {
                    ShowDmgText(dotDamage);
                    if (clericCurrHp <= 0)
                    {
                        animator.SetBool("ClericDead", true);
                        StartCoroutine(charDeath(4));
                    }
                }
                yield return new WaitForSeconds(1.0f);
            }
            clericBurnCounter--;
            if (clericBurnCounter <= 0)
            {
                clericBurned = false;
                RemoveStatusEffect(5, 1);
            }
        }

        yield return null;

    }

    //Assuming the current active character is the one recieving the status effect
    private void AddStatusEffect(int statusToAdd, bool addForAll)
    {
        Image tempImage;
        if (addForAll == true) //Add status effect for all characters
        {
            foreach (Image i in rogueStatusEffects)
            {
                if (i.sprite == statusEffects[statusToAdd]) //dont want multiple of the same status effects showing
                {
                    break;
                }
                if (i.sprite == null)
                {
                    i.sprite = statusEffects[statusToAdd];
                    tempImage = i.GetComponent<Image>();
                    i.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 1.0f);
                    break;
                }
            }
            foreach (Image i in warriorStatusEffects)
            {
                if (i.sprite == statusEffects[statusToAdd]) //dont want multiple of the same status effects showing
                {
                    break;
                }
                if (i.sprite == null)
                {
                    i.sprite = statusEffects[statusToAdd];
                    tempImage = i.GetComponent<Image>();
                    i.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 1.0f);
                    break;
                }
            }
            foreach (Image i in rangerStatusEffects)
            {
                if (i.sprite == statusEffects[statusToAdd]) //dont want multiple of the same status effects showing
                {
                    break;
                }
                if (i.sprite == null)
                {
                    i.sprite = statusEffects[statusToAdd];
                    tempImage = i.GetComponent<Image>();
                    i.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 1.0f);
                    break;
                }
            }
            foreach (Image i in clericStatusEffects)
            {
                if (i.sprite == statusEffects[statusToAdd]) //dont want multiple of the same status effects showing
                {
                    break;
                }
                if (i.sprite == null)
                {
                    i.sprite = statusEffects[statusToAdd];
                    tempImage = i.GetComponent<Image>();
                    i.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 1.0f);
                    break;
                }
            }
        }
        else
        {
            if (activeCharacter == 1)
            {
                foreach (Image i in rogueStatusEffects)
                {
                    if (i.sprite == statusEffects[statusToAdd]) //dont want multiple of the same status effects showing
                    {
                        break;
                    }
                    if (i.sprite == null)
                    {
                        i.sprite = statusEffects[statusToAdd];
                        tempImage = i.GetComponent<Image>();
                        i.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 1.0f);
                        break;
                    }
                }
            }
            else if (activeCharacter == 2)
            {
                foreach (Image i in warriorStatusEffects)
                {
                    if (i.sprite == statusEffects[statusToAdd]) //dont want multiple of the same status effects showing
                    {
                        break;
                    }
                    if (i.sprite == null)
                    {
                        i.sprite = statusEffects[statusToAdd];
                        tempImage = i.GetComponent<Image>();
                        i.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 1.0f);
                        break;
                    }
                }
            }
            else if (activeCharacter == 3)
            {
                foreach (Image i in rangerStatusEffects)
                {
                    if (i.sprite == statusEffects[statusToAdd]) //dont want multiple of the same status effects showing
                    {
                        break;
                    }
                    if (i.sprite == null)
                    {
                        i.sprite = statusEffects[statusToAdd];
                        tempImage = i.GetComponent<Image>();
                        i.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 1.0f);
                        break;
                    }
                }
            }
            else if (activeCharacter == 4)
            {
                foreach (Image i in clericStatusEffects)
                {
                    if (i.sprite == statusEffects[statusToAdd]) //dont want multiple of the same status effects showing
                    {
                        break;
                    }
                    if (i.sprite == null)
                    {
                        i.sprite = statusEffects[statusToAdd];
                        tempImage = i.GetComponent<Image>();
                        i.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 1.0f);
                        break;
                    }
                }
            }
        }
    }

    private void RemoveStatusEffect(int statusToRemove, int character)
    {
        Image tempImage;
        if (character == 10) //Remove status effect for all characters
        {
            foreach (Image i in rogueStatusEffects)
            {
                if (i.sprite == statusEffects[statusToRemove])
                {
                    i.sprite = null;
                    tempImage = i.GetComponent<Image>();
                    i.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 0.0f);
                    break;
                }
            }
            for (int i = 0; i < rogueStatusEffects.Length; i++)
            {
                if (rogueStatusEffects[i] == null)
                {
                    rogueStatusEffects[i] = rogueStatusEffects[i + 1];
                    rogueStatusEffects[i + 1] = null;
                }
            }
            foreach (Image i in warriorStatusEffects)
            {
                if (i.sprite == statusEffects[statusToRemove])
                {
                    i.sprite = null;
                    tempImage = i.GetComponent<Image>();
                    i.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 0.0f);
                    break;
                }
            }
            for (int i = 0; i < warriorStatusEffects.Length; i++)
            {
                if (warriorStatusEffects[i] == null)
                {
                    warriorStatusEffects[i] = warriorStatusEffects[i + 1];
                    warriorStatusEffects[i + 1] = null;
                }
            }
            foreach (Image i in rangerStatusEffects)
            {
                if (i.sprite == statusEffects[statusToRemove])
                {
                    i.sprite = null;
                    tempImage = i.GetComponent<Image>();
                    i.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 0.0f);
                    break;
                }
            }
            for (int i = 0; i < rangerStatusEffects.Length; i++)
            {
                if (rangerStatusEffects[i] == null)
                {
                    rangerStatusEffects[i] = rangerStatusEffects[i + 1];
                    rangerStatusEffects[i + 1] = null;
                }
            }
            foreach (Image i in clericStatusEffects)
            {
                if (i.sprite == statusEffects[statusToRemove])
                {
                    i.sprite = null;
                    tempImage = i.GetComponent<Image>();
                    i.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 0.0f);
                    break;
                }
            }
            for (int i = 0; i < clericStatusEffects.Length; i++)
            {
                if (clericStatusEffects[i] == null)
                {
                    clericStatusEffects[i] = clericStatusEffects[i + 1];
                    clericStatusEffects[i + 1] = null;
                }
            }

        }
        else if(character == 1)
        {
            foreach (Image i in rogueStatusEffects)
            {
                if (i.sprite == statusEffects[statusToRemove])
                {
                    i.sprite = null;
                    tempImage = i.GetComponent<Image>();
                    i.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 0.0f);
                    break;
                }
            }
            for (int i = 0; i < rogueStatusEffects.Length; i++)
            {
                if (rogueStatusEffects[i] == null)
                {
                    rogueStatusEffects[i] = rogueStatusEffects[i + 1];
                    rogueStatusEffects[i + 1] = null;
                }
            }
        }
        else if(character == 2)
        {
            foreach (Image i in warriorStatusEffects)
            {
                if (i.sprite == statusEffects[statusToRemove])
                {
                    i.sprite = null;
                    tempImage = i.GetComponent<Image>();
                    i.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 0.0f);
                    break;
                }
            }
            for (int i = 0; i < warriorStatusEffects.Length; i++)
            {
                if (warriorStatusEffects[i] == null)
                {
                    warriorStatusEffects[i] = warriorStatusEffects[i + 1];
                    warriorStatusEffects[i + 1] = null;
                }
            }
        }
        else if(character == 3)
        {
            foreach (Image i in rangerStatusEffects)
            {
                if (i.sprite == statusEffects[statusToRemove])
                {
                    i.sprite = null;
                    tempImage = i.GetComponent<Image>();
                    i.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 0.0f);
                    break;
                }
            }
            for (int i = 0; i < rangerStatusEffects.Length; i++)
            {
                if (rangerStatusEffects[i] == null)
                {
                    rangerStatusEffects[i] = rangerStatusEffects[i + 1];
                    rangerStatusEffects[i + 1] = null;
                }
            }
        }
        else if(character == 4)
        {
            foreach (Image i in clericStatusEffects)
            {
                if (i.sprite == statusEffects[statusToRemove])
                {
                    i.sprite = null;
                    tempImage = i.GetComponent<Image>();
                    i.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 0.0f);
                    break;
                }
            }
            for (int i = 0; i < clericStatusEffects.Length; i++)
            {
                if (clericStatusEffects[i] == null)
                {
                    clericStatusEffects[i] = clericStatusEffects[i + 1];
                    clericStatusEffects[i + 1] = null;
                }
            }
        }

    }



}
