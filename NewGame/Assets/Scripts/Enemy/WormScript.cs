﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WormScript : MonoBehaviour
{
    private Animator animator;
    private bool isAttacking = false;
    public LayerMask playerLayer;
    private GameObject player;
    private float moveSpeed = 4.0f;
    private float slowSpeed = 2.0f;
    private float idleSpeed = 3.0f;
    private float normalSpeed = 4.0f;
    //private int lastMovingDirection = 1; //1 is last moving right, -1 is last moving left
    private SpriteRenderer mySpriteRenderer;
    private bool isMoving = false;
    private TMP_Text lvlText;
    private int currLevel;
    public Image hpBar;
    public Image[] statusPlaceholders;
    public Sprite[] statusEffects;
    private Image tempImage;
    private int slowStack = 0;
    public Text hitText;
    public Text goldText;
    public Text expText;
    public Canvas enemyCanvas;


    private bool isDead = false;
    private bool isAggro = false;
    private bool isHit = false;
    private bool idleMoving = false;
    private string lastOffset = "-";

    private bool wormAggro = false;


    //Status effects
    private bool isStunned = false;
    private bool isRooted = false;
    private bool isMarked = false;
    private bool isCrippled = false;
    private bool isPoisoned = false;
    private bool isBurned = false;

    //Base stats before levels
    private int maxHpBase = 110;
    private int attackBase = 12;
    private int defenseBase = 4;
    private int expGiveBase = 1;
    //Slime stats
    private int maxHp = 100;
    private int currHp;
    private int attack;
    private int defense;
    private float aggroRange = 10.0f;
    private int expGive = 1;
    private int goldGive = 1;

    private int rootDuration = 3;
    private int rootChance = 10;


    // Start is called before the first frame update
    void Start()
    {
        lastOffset = "-";
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        foreach (Image i in statusPlaceholders)
        {
            tempImage = i.GetComponent<Image>();
            i.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 0.0f);
        }
    }

    void Awake()
    {
        lvlText = GetComponentInChildren<TMP_Text>(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, 2.0f, playerLayer) != null && isAttacking == false && player.GetComponent<PlayerController>().isStealth == false && StateController.paused == false && isStunned == false && isDead == false)
        {
            //if in range of attack
            animator.SetTrigger("isAggro");
            wormAggro = true;
            StartCoroutine(Attack());
        }
        if(Physics2D.OverlapCircle(transform.position, 2.0f, playerLayer) == null)
        {
            animator.SetTrigger("isHide");
            wormAggro = false;
        }
        //else back to hidden state

        hpBar.fillAmount = (float)currHp / (float)maxHp;
        if (currHp <= 0 && isDead == false)
        {
            //Debug.Log("Here");
            player.GetComponent<PlayerController>().LevelUp(expGive);
            InventoryManager.gold += goldGive;
            isDead = true; //without this the arrow seems to proc it this conditional too many times since slime is set to destroy after death anim
            ShowRewardsText(goldGive, expGive);
            animator.SetTrigger("isDead");

            //death anim

        }
        

    }

   

    public void Hit(int damage)
    {
        if (wormAggro == true)
        {
            damage -= defense;
            if (damage > 0) //Dont want to accidentally heal on for ranger shot or something
            {
                if (isMarked == true)
                {
                    damage = (int)(damage * 1.5);
                    currHp -= damage;
                }
                else
                {
                    currHp -= damage;
                }

            }

            ShowDmgText(damage);

        }
        else
        {
            ShowStatusText("IMMUNE");
        }
        
    }

    private void ShowStatusText(string status)
    {
        Vector3 offset = new Vector3(3.2f, 1.0f, 0.0f);
        Text dmgText = Instantiate(hitText, transform.position, Quaternion.identity);
        dmgText.transform.SetParent(enemyCanvas.transform, false);
        dmgText.transform.position = transform.position + offset;
        dmgText.text = status;
    }

    public void setStats(int level)
    {
        //Call this after instantiate
        currLevel = level;
        maxHp = maxHpBase * (int)(level*0.5);
        attack = attackBase * (int)(level * 0.5);
        defense = defenseBase * (int)(level * 0.5);
        expGive = expGiveBase * level;
        currHp = maxHp;
        goldGive = goldGive * level;
        //Debug.Log("hp: " + currHp + "attack: " + attack + "defense: " + defense);
        lvlText.text = "Worm Lvl " + currLevel.ToString();
    }

    IEnumerator Attack()
    {
        if (transform.position.x < player.transform.position.x)
        {
            mySpriteRenderer.flipX = false;
        }
        else
        {
            mySpriteRenderer.flipX = true;
        }
        isAggro = true;
        isAttacking = true;
        animator.SetTrigger("isAttacking");
        int revengeDamage = 0;
        revengeDamage = player.GetComponent<PlayerController>().Hit(attack); //For revenge damage
        player.GetComponent<PlayerController>().CallRooted(rootDuration, rootChance);
        if (revengeDamage > 0 && revengeDamage != null)
        {
            currHp -= revengeDamage;
            ShowDmgText(revengeDamage);
        }
        yield return new WaitForSeconds(2.5f);
        animator.ResetTrigger("isAttacking");
        isAttacking = false;
        isAggro = false;
    }

    
    //Status effects
    public void CripplingShot(int duration)
    {
        StartCoroutine(CripplingShotEnemy(duration));
    }

    IEnumerator CripplingShotEnemy(int duration)
    {
        slowStack += 1;
        isCrippled = true;
        AddStatusEffect(3);
        yield return new WaitForSeconds(duration);
        slowStack -= 1;
        if (slowStack <= 0) //Incase of stacking cripplingshots, i only want iscrippled to be false based on last shot hit
        {
            RemoveStatusEffect(3);
            isCrippled = false;
        }

    }

    public void Marked(int duration)
    {
        StartCoroutine(MarkedEnemy(duration));
    }
    IEnumerator MarkedEnemy(int duration)
    {
        if (duration <= 0)
        {
            yield return null;
        }
        else
        {
            isMarked = true;
            AddStatusEffect(2);
            yield return new WaitForSeconds(duration);
            RemoveStatusEffect(2);
            isMarked = false;
        }

    }

    public void Rooted(int duration)
    {
        StartCoroutine(RootedEnemy(duration));
    }
    IEnumerator RootedEnemy(int duration)
    {
        isRooted = true;
        AddStatusEffect(1);
        yield return new WaitForSeconds(duration);
        isRooted = false;
        RemoveStatusEffect(1);
    }


    public void Stunned(int chance, int duration) //Made void function to take call from bomb script, couldnt call enumerator function because bomb object was being destroyed before enumerator could return value
    {
        StartCoroutine(StunnedEnemy(chance, duration));
    }
    IEnumerator StunnedEnemy(int chance, int duration)
    {
        if (isStunned == false) //Stun shouldnt stack, also it was creating issues, sometimes stun status would insta go false because of multiple stun coroutines at same time
        {
            int rnd = Random.Range(1, 100);
            if (chance > rnd)
            {
                isStunned = true;
                AddStatusEffect(0);
                for (int i = 0; i < duration; i++)
                {
                    yield return new WaitForSeconds(1.0f);
                }
            }
            yield return new WaitForSeconds(3.0f);
            RemoveStatusEffect(0);
            isStunned = false;
        }
    }

    public void Poisoned(float DOT, int duration)
    {
        StartCoroutine(PoisonedEnemy(DOT, duration));
    }
    IEnumerator PoisonedEnemy(float DOT, int duration)
    {
        bool refreshDOT = false;
        if (isPoisoned == false)
        {
            AddStatusEffect(4);
            isPoisoned = true;
            int dotDamage;
            for (int i = 0; i < duration; i++)
            {
                if (refreshDOT = true)
                {
                    i = 0;
                    refreshDOT = false;
                }
                dotDamage = (int)(maxHp * DOT);
                currHp = (int)(currHp - dotDamage);
                yield return new WaitForSeconds(1.0f);
                ShowDmgText(dotDamage);
                //Debug.Log(currHp);
            }
            isPoisoned = false;
            RemoveStatusEffect(4);
        }
        else
        {
            refreshDOT = true;
        }


        yield return null;
    }


    public void Burned(float DOT, int duration)
    {
        StartCoroutine(BurnedEnemy(DOT, duration));
    }
    IEnumerator BurnedEnemy(float DOT, int duration)
    {
        bool refreshDOT = false;
        if (isBurned == false)
        {
            isBurned = true;
            AddStatusEffect(5);
            int dotDamage;
            for (int i = 0; i < duration; i++)
            {
                if (refreshDOT = true)
                {
                    i = 0;
                    refreshDOT = false;
                }
                dotDamage = (int)(maxHp * DOT);
                currHp = (int)(currHp - dotDamage);
                ShowDmgText(dotDamage);
                yield return new WaitForSeconds(1.0f);
                //Debug.Log(currHp);
            }
            isBurned = false;
            RemoveStatusEffect(5);
        }
        else
        {
            refreshDOT = true;
        }

        yield return null;
    }

    private void ShowDmgText(int damage)
    {
        Vector3 offset = new Vector3(3.2f, 1.0f, 0.0f);
        Text dmgText = Instantiate(hitText, transform.position, Quaternion.identity);
        dmgText.transform.SetParent(enemyCanvas.transform, false);
        dmgText.transform.position = transform.position + offset;
        dmgText.text = damage.ToString();
    }

    private void ShowRewardsText(int gold, int exp)
    {
        Vector3 offset = new Vector3(4.2f, 1.0f, 0.0f);
        Text gText = Instantiate(goldText, transform.position, Quaternion.identity);
        gText.transform.SetParent(enemyCanvas.transform, false);
        gText.transform.position = transform.position + offset;
        gText.text = "+" + gold.ToString() + "g";

        Vector3 offset2 = new Vector3(4.2f, 2.0f, 0.0f);
        Text xpText = Instantiate(expText, transform.position, Quaternion.identity);
        xpText.transform.SetParent(enemyCanvas.transform, false);
        xpText.transform.position = transform.position + offset2;
        xpText.text = "+" + exp.ToString() + "xp";
    }

    private void AddStatusEffect(int statusToAdd)
    {
        foreach (Image i in statusPlaceholders)
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

    private void RemoveStatusEffect(int statusToRemove)
    {
        foreach (Image i in statusPlaceholders)
        {
            if (i.sprite == statusEffects[statusToRemove])
            {
                i.sprite = null;
                tempImage = i.GetComponent<Image>();
                i.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 0.0f);
                break;
            }
        }

        //Re Order buffs
        for (int i = 0; i < statusPlaceholders.Length; i++)
        {
            if (statusPlaceholders[i] == null)
            {
                statusPlaceholders[i] = statusPlaceholders[i + 1];
                statusPlaceholders[i + 1] = null;
            }
        }
    }

    public void AggroIdle()
    {
        animator.SetTrigger("isAggro2");
        animator.ResetTrigger("isHide");
        animator.ResetTrigger("Hidden");
    }

    public void Hiding()
    {
        animator.ResetTrigger("isAggro");
        animator.ResetTrigger("isAggro2");
        animator.SetTrigger("Hidden");
    }
}
