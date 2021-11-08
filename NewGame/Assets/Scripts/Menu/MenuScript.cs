using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuScript : MonoBehaviour
{
    private GameObject player;
    //General party screen
    public TMP_Text rogueStats;
    public TMP_Text warriorStats;
    public TMP_Text rangerStats;
    public TMP_Text clericStats;

    //Individual level up screens
    public TMP_Text rogueStats2;
    public TMP_Text warriorStats2;
    public TMP_Text rangerStats2;
    public TMP_Text clericStats2;

    
    private int rogueMaxHp;
    private int rogueCurrHp;
    private int rogueDefense;
    private int rogueAttack;
    private int rogueCrRate;
    private float rogueCrDmg;
    private float rogueDodge;
    private int rogueMaxMp;
    private int rogueCurrMp;
    private int rogueSkillPoints;
    private int rogueAttributePoints;
    private int rogueStr;
    private int rogueDex;
    private int rogueCon;
    private int rogueInt;


    private int warriorMaxHp;
    private int warriorCurrHp;
    private int warriorDefense;
    private int warriorAttack;
    private int warriorCrRate;
    private float warriorCrDmg;
    private float warriorDodge;
    private int warriorMaxMp;
    private int warriorCurrMp;
    private int warriorSkillPoints;
    private int warriorAttributePoints;
    private int warriorStr;
    private int warriorDex;
    private int warriorCon;
    private int warriorInt;


    private int rangerMaxHp;
    private int rangerCurrHp;
    private int rangerDefense;
    private int rangerAttack;
    private int rangerCrRate;
    private float rangerCrDmg;
    private float rangerDodge;
    private int rangerMaxMp;
    private int rangerCurrMp;
    private int rangerSkillPoints;
    private int rangerAttributePoints;
    private int rangerStr;
    private int rangerDex;
    private int rangerCon;
    private int rangerInt;


    private int clericMaxHp;
    private int clericCurrHp;
    private int clericDefense;
    private int clericAttack;
    private int clericCrRate;
    private float clericCrDmg;
    private float clericDodge;
    private int clericMaxMp;
    private int clericCurrMp;
    private int clericSkillPoints;
    private int clericAttributePoints;
    private int clericStr;
    private int clericDex;
    private int clericCon;
    private int clericInt;

    //Rogue
    public Image[] Stealth;
    public Image[] Execute;
    public Image[] Bomb;

    public Button[] StealthBtns;
    public Button[] ExecuteBtns;
    public Button[] BombBtns;

    private int Skill_Stealth;
    private int Skill_Execute;
    private int Skill_Bomb;

    //Warrior
    public Image[] Ironheart;
    public Image[] Revenge;
    public Image[] Sacrifice;

    public Button[] IronheartBtns;
    public Button[] RevengeBtns;
    public Button[] SacrificeBtns;

    private int Skill_Ironheart;
    private int Skill_Revenge;
    private int Skill_Sacrifice;


    //Ranger
    public Image[] Trap;
    public Image[] FocusShot;
    public Image[] CripplingShot;

    public Button[] TrapBtns;
    public Button[] FocusShotBtns;
    public Button[] CripplingShotBtns;

    private int Skill_Trap;
    private int Skill_FocusShot;
    private int Skill_CripplingShot;


    //Cleric 
    public Image[] Heal;
    public Image[] Resurrection;
    public Image[] RaiseTheDead;

    public Button[] HealBtns;
    public Button[] ResurrectionBtns;
    public Button[] RaiseTheDeadBtns;

    private int Skill_Heal;
    private int Skill_Resurrection;
    private int Skill_RaiseTheDead;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    public void UpdateParty()
    {
        
        //Setting temp vars to hold temp value 
        rogueMaxHp = player.GetComponent<PlayerController>().rogueMaxHp;
        rogueCurrHp = player.GetComponent<PlayerController>().rogueCurrHp;
        rogueDefense = player.GetComponent<PlayerController>().rogueDefense;
        rogueAttack = player.GetComponent<PlayerController>().rogueAttack;
        rogueCrRate = player.GetComponent<PlayerController>().rogueCrRate;
        rogueCrDmg = player.GetComponent<PlayerController>().rogueCrDmg;
        rogueDodge = player.GetComponent<PlayerController>().rogueDodge;
        rogueMaxMp = player.GetComponent<PlayerController>().rogueMaxMp;
        rogueCurrMp = player.GetComponent<PlayerController>().rogueCurrMp;
        rogueSkillPoints = player.GetComponent<PlayerController>().rogueSkillPoints;
        rogueAttributePoints = player.GetComponent<PlayerController>().rogueAttributePoints;
        rogueStr = player.GetComponent<PlayerController>().rogueStr;
        rogueDex = player.GetComponent<PlayerController>().rogueDex;
        rogueCon = player.GetComponent<PlayerController>().rogueCon;
        rogueInt = player.GetComponent<PlayerController>().rogueInt;

        Skill_Stealth = player.GetComponent<PlayerController>().rogueStealthLvl;
        Skill_Execute = player.GetComponent<PlayerController>().rogueExecuteLvl;
        Skill_Bomb = player.GetComponent<PlayerController>().rogueBombLvl;


        warriorMaxHp = player.GetComponent<PlayerController>().warriorMaxHp;
        warriorCurrHp = player.GetComponent<PlayerController>().warriorCurrHp;
        warriorDefense = player.GetComponent<PlayerController>().warriorDefense;
        warriorAttack = player.GetComponent<PlayerController>().warriorAttack;
        warriorCrRate = player.GetComponent<PlayerController>().warriorCrRate;
        warriorCrDmg = player.GetComponent<PlayerController>().warriorCrDmg;
        warriorDodge = player.GetComponent<PlayerController>().warriorDodge;
        warriorMaxMp = player.GetComponent<PlayerController>().warriorMaxMp;
        warriorCurrMp = player.GetComponent<PlayerController>().warriorCurrMp;
        warriorSkillPoints = player.GetComponent<PlayerController>().warriorSkillPoints;
        warriorAttributePoints = player.GetComponent<PlayerController>().warriorAttributePoints;
        warriorStr = player.GetComponent<PlayerController>().warriorStr;
        warriorDex = player.GetComponent<PlayerController>().warriorDex;
        warriorCon = player.GetComponent<PlayerController>().warriorCon;
        warriorInt = player.GetComponent<PlayerController>().warriorInt;

        Skill_Ironheart = player.GetComponent<PlayerController>().warriorIronheartLvl;
        Skill_Revenge = player.GetComponent<PlayerController>().warriorRevengeLvl;
        Skill_Sacrifice = player.GetComponent<PlayerController>().warriorSacrificeLvl;


        rangerMaxHp = player.GetComponent<PlayerController>().rangerMaxHp;
        rangerCurrHp = player.GetComponent<PlayerController>().rangerCurrHp;
        rangerDefense = player.GetComponent<PlayerController>().rangerDefense;
        rangerAttack = player.GetComponent<PlayerController>().rangerAttack;
        rangerCrRate = player.GetComponent<PlayerController>().rangerCrRate;
        rangerCrDmg = player.GetComponent<PlayerController>().rangerCrDmg;
        rangerDodge = player.GetComponent<PlayerController>().rangerDodge;
        rangerMaxMp = player.GetComponent<PlayerController>().rangerMaxMp;
        rangerCurrMp = player.GetComponent<PlayerController>().rangerCurrMp;
        rangerSkillPoints = player.GetComponent<PlayerController>().rangerSkillPoints;
        rangerAttributePoints = player.GetComponent<PlayerController>().rangerAttributePoints;
        rangerStr = player.GetComponent<PlayerController>().rangerStr;
        rangerDex = player.GetComponent<PlayerController>().rangerDex;
        rangerCon = player.GetComponent<PlayerController>().rangerCon;
        rangerInt = player.GetComponent<PlayerController>().rangerInt;

        Skill_Trap = player.GetComponent<PlayerController>().rangerTrapLvl;
        Skill_FocusShot = player.GetComponent<PlayerController>().rangerFocusShotLvl;
        Skill_CripplingShot = player.GetComponent<PlayerController>().rangerCripplingShotLvl;


        clericMaxHp = player.GetComponent<PlayerController>().clericMaxHp;
        clericCurrHp = player.GetComponent<PlayerController>().clericCurrHp;
        clericDefense = player.GetComponent<PlayerController>().clericDefense;
        clericAttack = player.GetComponent<PlayerController>().clericAttack;
        clericCrRate = player.GetComponent<PlayerController>().clericCrRate;
        clericCrDmg = player.GetComponent<PlayerController>().clericCrDmg;
        clericDodge = player.GetComponent<PlayerController>().clericDodge;
        clericMaxMp = player.GetComponent<PlayerController>().clericMaxMp;
        clericCurrMp = player.GetComponent<PlayerController>().clericCurrMp;
        clericSkillPoints = player.GetComponent<PlayerController>().clericSkillPoints;
        clericAttributePoints = player.GetComponent<PlayerController>().clericAttributePoints;
        clericStr = player.GetComponent<PlayerController>().clericStr;
        clericDex = player.GetComponent<PlayerController>().clericDex;
        clericCon = player.GetComponent<PlayerController>().clericCon;
        clericInt = player.GetComponent<PlayerController>().clericInt;

        Skill_Heal = player.GetComponent<PlayerController>().clericHealLvl;
        Skill_Resurrection = player.GetComponent<PlayerController>().clericResurrectionLvl;
        Skill_RaiseTheDead = player.GetComponent<PlayerController>().clericRaiseTheDeadLvl;



        //Stealth
        Image image;
        for (int i = 1; i < Stealth.Length-2; i++)
        {
            if (Skill_Stealth == i)
            {
                StealthBtns[i + 1].interactable = true;
                StealthBtns[i].interactable = false;
            }
            else
            {
                StealthBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= Stealth.Length-1; i++)
        {
            if (Skill_Stealth >= i)
            {
                image = Stealth[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = Stealth[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }

        //Execute
        for (int i = 1; i < Execute.Length - 2; i++)
        {
            if (Skill_Execute == i)
            {
                ExecuteBtns[i + 1].interactable = true;
                ExecuteBtns[i].interactable = false;
            }
            else
            {
                ExecuteBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= Execute.Length - 1; i++)
        {
            if (Skill_Execute >= i)
            {
                image = Execute[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = Execute[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }

        //Bomb
        for (int i = 1; i < Bomb.Length - 2; i++)
        {
            if (Skill_Bomb == i)
            {
                BombBtns[i + 1].interactable = true;
                BombBtns[i].interactable = false;
            }
            else
            {
                BombBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= Bomb.Length - 1; i++)
        {
            if (Skill_Bomb >= i)
            {
                image = Bomb[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = Bomb[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }

        //Ironheart
        for (int i = 1; i < Ironheart.Length - 2; i++)
        {
            if (Skill_Ironheart == i)
            {
                IronheartBtns[i + 1].interactable = true;
                IronheartBtns[i].interactable = false;
            }
            else
            {
                IronheartBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= Ironheart.Length - 1; i++)
        {
            if (Skill_Ironheart >= i)
            {
                image = Ironheart[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = Ironheart[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }

        //Revenge
        for (int i = 1; i < Revenge.Length - 2; i++)
        {
            if (Skill_Revenge == i)
            {
                RevengeBtns[i + 1].interactable = true;
                RevengeBtns[i].interactable = false;
            }
            else
            {
                RevengeBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= Revenge.Length - 1; i++)
        {
            if (Skill_Revenge >= i)
            {
                image = Revenge[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = Revenge[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }

        //Sacrifice
        for (int i = 1; i < Sacrifice.Length - 2; i++)
        {
            if (Skill_Sacrifice == i)
            {
                SacrificeBtns[i + 1].interactable = true;
                SacrificeBtns[i].interactable = false;
            }
            else
            {
                SacrificeBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= Sacrifice.Length - 1; i++)
        {
            if (Skill_Sacrifice >= i)
            {
                image = Sacrifice[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = Sacrifice[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }


        //Trap
        for (int i = 1; i < Trap.Length - 2; i++)
        {
            if (Skill_Trap == i)
            {
                TrapBtns[i + 1].interactable = true;
                TrapBtns[i].interactable = false;
            }
            else
            {
                TrapBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= Trap.Length - 1; i++)
        {
            if (Skill_Trap >= i)
            {
                image = Trap[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = Trap[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }

        //Focus Shot
        for (int i = 1; i < FocusShot.Length - 2; i++)
        {
            if (Skill_FocusShot == i)
            {
                
                FocusShotBtns[i + 1].interactable = true;
                
                FocusShotBtns[i].interactable = false;
            }
            else
            {
                FocusShotBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= FocusShot.Length - 1; i++)
        {
            if (Skill_FocusShot >= i)
            {
                image = FocusShot[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = FocusShot[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }

        //Crippling shot
        for (int i = 1; i < CripplingShot.Length - 2; i++)
        {
            if (Skill_CripplingShot == i)
            {
                CripplingShotBtns[i + 1].interactable = true;
                CripplingShotBtns[i].interactable = false;
            }
            else
            {
                CripplingShotBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= CripplingShot.Length - 1; i++)
        {
            if (Skill_CripplingShot >= i)
            {
                image = CripplingShot[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = CripplingShot[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }

        //Heal
        for (int i = 1; i < Heal.Length - 2; i++)
        {
            if (Skill_Heal == i)
            {
                HealBtns[i + 1].interactable = true;
                HealBtns[i].interactable = false;
            }
            else
            {
                HealBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= Heal.Length - 1; i++)
        {
            if (Skill_Heal >= i)
            {
                image = Heal[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = Heal[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }

        //Resurrection
        for (int i = 1; i < Resurrection.Length - 2; i++)
        {
            if (Skill_Resurrection == i)
            {
                ResurrectionBtns[i + 1].interactable = true;
                ResurrectionBtns[i].interactable = false;
            }
            else
            {
                ResurrectionBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= Resurrection.Length - 1; i++)
        {
            if (Skill_Resurrection >= i)
            {
                image = Resurrection[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = Resurrection[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }

        //RaiseTheDead
        for (int i = 1; i < RaiseTheDead.Length - 2; i++)
        {
            if (Skill_RaiseTheDead == i)
            {
                RaiseTheDeadBtns[i + 1].interactable = true;
                RaiseTheDeadBtns[i].interactable = false;
            }
            else
            {
                RaiseTheDeadBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= RaiseTheDead.Length - 1; i++)
        {
            if (Skill_RaiseTheDead >= i)
            {
                image = RaiseTheDead[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = RaiseTheDead[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }


        rogueStats.text =
            "Rogue Stats:" +
            "\nLevel: " + player.GetComponent<PlayerController>().rogueCurrLvl +
            "\nHealth: " + player.GetComponent<PlayerController>().rogueCurrHp + "/" + player.GetComponent<PlayerController>().rogueMaxHp +
            "\nMana: " + player.GetComponent<PlayerController>().rogueCurrMp + "/" + player.GetComponent<PlayerController>().rogueMaxMp +
            "\nDefense: " + player.GetComponent<PlayerController>().rogueDefense +
            "\nAttack: " + player.GetComponent<PlayerController>().rogueAttack +
            "\nCrit rate: " + player.GetComponent<PlayerController>().rogueCrRate +
            "\nCrit Damage " + player.GetComponent<PlayerController>().rogueCrDmg +
            "\nDodge: " + player.GetComponent<PlayerController>().rogueDodge +
            "\n\nUnspent Skill Points: " + player.GetComponent<PlayerController>().rogueSkillPoints;

        warriorStats.text =
            "Warrior Stats:" +
            "\nLevel: " + player.GetComponent<PlayerController>().warriorCurrLvl +
            "\nHealth: " + player.GetComponent<PlayerController>().warriorCurrHp + "/" + player.GetComponent<PlayerController>().warriorMaxHp +
            "\nMana: " + player.GetComponent<PlayerController>().warriorCurrMp + "/" + player.GetComponent<PlayerController>().warriorMaxMp +
            "\nDefense: " + player.GetComponent<PlayerController>().warriorDefense +
            "\nAttack: " + player.GetComponent<PlayerController>().warriorAttack +
            "\nCrit rate: " + player.GetComponent<PlayerController>().warriorCrRate +
            "\nCrit Damage " + player.GetComponent<PlayerController>().warriorCrDmg +
            "\nDodge: " + player.GetComponent<PlayerController>().warriorDodge +
            "\n\nUnspent Skill Points: " + player.GetComponent<PlayerController>().warriorSkillPoints;

        rangerStats.text =
            "Ranger Stats: " +
            "\nLevel: " + player.GetComponent<PlayerController>().rangerCurrLvl +
            "\nHealth: " + player.GetComponent<PlayerController>().rangerCurrHp + "/" + player.GetComponent<PlayerController>().rangerMaxHp +
            "\nMana: " + player.GetComponent<PlayerController>().rangerCurrMp + "/" + player.GetComponent<PlayerController>().rangerMaxMp +
            "\nDefense: " + player.GetComponent<PlayerController>().rangerDefense +
            "\nAttack: " + player.GetComponent<PlayerController>().rangerAttack +
            "\nCrit rate: " + player.GetComponent<PlayerController>().rangerCrRate +
            "\nCrit Damage " + player.GetComponent<PlayerController>().rangerCrDmg +
            "\nDodge: " + player.GetComponent<PlayerController>().rangerDodge +
            "\n\nUnspent Skill Points: " + player.GetComponent<PlayerController>().rangerSkillPoints;

        clericStats.text =
            "Cleric Stats: " +
            "\nLevel: " + player.GetComponent<PlayerController>().clericCurrLvl +
            "\nHealth: " + player.GetComponent<PlayerController>().clericCurrHp + "/" + player.GetComponent<PlayerController>().clericMaxHp +
            "\nMana: " + player.GetComponent<PlayerController>().clericCurrMp + "/" + player.GetComponent<PlayerController>().clericMaxMp +
            "\nDefense: " + player.GetComponent<PlayerController>().clericDefense +
            "\nAttack: " + player.GetComponent<PlayerController>().clericAttack +
            "\nCrit rate: " + player.GetComponent<PlayerController>().clericCrRate +
            "\nCrit Damage " + player.GetComponent<PlayerController>().clericCrDmg +
            "\nDodge: " + player.GetComponent<PlayerController>().clericDodge +
            "\n\nUnspent Skill Points: " + player.GetComponent<PlayerController>().clericSkillPoints;

        rogueStats2.text =
            "Rogue Stats:" +
            "\nLevel: " + player.GetComponent<PlayerController>().rogueCurrLvl + "\t\t\t\tStrength: " + player.GetComponent<PlayerController>().rogueStr +
            "\nHealth: " + player.GetComponent<PlayerController>().rogueCurrHp + "/" + player.GetComponent<PlayerController>().rogueMaxHp + "\t\t\tDexterity: " + player.GetComponent<PlayerController>().rogueDex +
            "\nMana: " + player.GetComponent<PlayerController>().rogueCurrMp + "/" + player.GetComponent<PlayerController>().rogueMaxMp + "\t\t\tConstitution: " + player.GetComponent<PlayerController>().rogueCon +
            "\nDefense: " + player.GetComponent<PlayerController>().rogueDefense + "\t\t\t\tIntellect: " + player.GetComponent<PlayerController>().rogueInt +
            "\nAttack: " + player.GetComponent<PlayerController>().rogueAttack + "\t\t\t\tAttribute Points: " + player.GetComponent<PlayerController>().rogueAttributePoints +
            "\nCrit rate: " + player.GetComponent<PlayerController>().rogueCrRate +
            "\nCrit Damage " + player.GetComponent<PlayerController>().rogueCrDmg +
            "\nDodge: " + player.GetComponent<PlayerController>().rogueDodge +
            "\n\nUnspent Skill Points: " + player.GetComponent<PlayerController>().rogueSkillPoints;

        warriorStats2.text =
            "Warrior Stats:" +
            "\nLevel: " + player.GetComponent<PlayerController>().warriorCurrLvl + "\t\t\t\tStrength: " + player.GetComponent<PlayerController>().warriorStr +
            "\nHealth: " + player.GetComponent<PlayerController>().warriorCurrHp + "/" + player.GetComponent<PlayerController>().warriorMaxHp + "\t\t\tDexterity: " + player.GetComponent<PlayerController>().warriorDex +
            "\nMana: " + player.GetComponent<PlayerController>().warriorCurrMp + "/" + player.GetComponent<PlayerController>().warriorMaxMp + "\t\t\tConstitution: " + player.GetComponent<PlayerController>().warriorCon +
            "\nDefense: " + player.GetComponent<PlayerController>().warriorDefense + "\t\t\t\tIntellect: " + player.GetComponent<PlayerController>().warriorInt +
            "\nAttack: " + player.GetComponent<PlayerController>().warriorAttack + "\t\t\t\tAttribute Points: " + player.GetComponent<PlayerController>().warriorAttributePoints +
            "\nCrit rate: " + player.GetComponent<PlayerController>().warriorCrRate +
            "\nCrit Damage " + player.GetComponent<PlayerController>().warriorCrDmg +
            "\nDodge: " + player.GetComponent<PlayerController>().warriorDodge +
            "\n\nUnspent Skill Points: " + player.GetComponent<PlayerController>().warriorSkillPoints;

        rangerStats2.text =
            "Ranger Stats:" +
            "\nLevel: " + player.GetComponent<PlayerController>().rangerCurrLvl + "\t\t\t\tStrength: " + player.GetComponent<PlayerController>().rangerStr +
            "\nHealth: " + player.GetComponent<PlayerController>().rangerCurrHp + "/" + player.GetComponent<PlayerController>().rangerMaxHp + "\t\t\tDexterity: " + player.GetComponent<PlayerController>().rangerDex +
            "\nMana: " + player.GetComponent<PlayerController>().rangerCurrMp + "/" + player.GetComponent<PlayerController>().rangerMaxMp + "\t\t\tConstitution: " + player.GetComponent<PlayerController>().rangerCon +
            "\nDefense: " + player.GetComponent<PlayerController>().rangerDefense + "\t\t\t\tIntellect: " + player.GetComponent<PlayerController>().rangerInt +
            "\nAttack: " + player.GetComponent<PlayerController>().rangerAttack + "\t\t\t\tAttribute Points: " + player.GetComponent<PlayerController>().rangerAttributePoints +
            "\nCrit rate: " + player.GetComponent<PlayerController>().rangerCrRate +
            "\nCrit Damage " + player.GetComponent<PlayerController>().rangerCrDmg +
            "\nDodge: " + player.GetComponent<PlayerController>().rangerDodge +
            "\n\nUnspent Skill Points: " + player.GetComponent<PlayerController>().rangerSkillPoints;
        
        clericStats2.text =
            "Ranger Stats:" +
            "\nLevel: " + player.GetComponent<PlayerController>().clericCurrLvl + "\t\t\t\tStrength: " + player.GetComponent<PlayerController>().clericStr +
            "\nHealth: " + player.GetComponent<PlayerController>().clericCurrHp + "/" + player.GetComponent<PlayerController>().clericMaxHp + "\t\t\tDexterity: " + player.GetComponent<PlayerController>().clericDex +
            "\nMana: " + player.GetComponent<PlayerController>().clericCurrMp + "/" + player.GetComponent<PlayerController>().clericMaxMp + "\t\t\tConstitution: " + player.GetComponent<PlayerController>().clericCon +
            "\nDefense: " + player.GetComponent<PlayerController>().clericDefense + "\t\t\t\tIntellect: " + player.GetComponent<PlayerController>().clericInt +
            "\nAttack: " + player.GetComponent<PlayerController>().clericAttack + "\t\t\t\tAttribute Points: " + player.GetComponent<PlayerController>().clericAttributePoints +
            "\nCrit rate: " + player.GetComponent<PlayerController>().clericCrRate +
            "\nCrit Damage " + player.GetComponent<PlayerController>().clericCrDmg +
            "\nDodge: " + player.GetComponent<PlayerController>().clericDodge +
            "\n\nUnspent Skill Points: " + player.GetComponent<PlayerController>().clericSkillPoints;

        //Debug.Log(rogueAttributePoints);
    }

    public void Resume()
    {
        StateController.paused = false;
    }


    //Rogue
    public void RogueStrUpgrade()
    {
        if (rogueAttributePoints > 0)
        {
            rogueAttributePoints--;
            rogueStr++;
            rogueCurrHp += 10;
            rogueMaxHp += 10;
            rogueDefense += 4;
            rogueAttack += 10;
            rogueCrRate += 2;
            rogueCrDmg += 0.05f;
            //Update stats first
            rogueStats2.text =
                "Rogue Stats:" +
                "\nLevel: " + player.GetComponent<PlayerController>().rogueCurrLvl + "\t\t\t\tStrength: " + rogueStr +
                "\nHealth: " + rogueCurrHp + "/" + rogueMaxHp + "\t\t\tDexterity: " + rogueDex +
                "\nMana: " + rogueCurrMp + "/" + rogueMaxMp + "\t\t\tConstitution: " + rogueCon +
                "\nDefense: " + rogueDefense + "\t\t\t\tIntellect: " + rogueInt +
                "\nAttack: " + rogueAttack + "\t\t\t\tAttribute Points: " + rogueAttributePoints +
                "\nCrit rate: " + rogueCrRate +
                "\nCrit Damage " + rogueCrDmg +
                "\nDodge: " + rogueDodge +
                "\n\nUnspent Skill Points: " + rogueSkillPoints;
        }
    }

    public void RogueDexUpgrade()
    {
        if (rogueAttributePoints > 0)
        {
            rogueAttributePoints--;
            rogueDex++;
            rogueDefense += 2;
            rogueAttack += 10;
            rogueCrRate += 4;
            rogueCrDmg += 0.1f;
            //Update stats first
            rogueStats2.text =
                "Rogue Stats:" +
                "\nLevel: " + player.GetComponent<PlayerController>().rogueCurrLvl + "\t\t\t\tStrength: " + rogueStr +
                "\nHealth: " + rogueCurrHp + "/" + rogueMaxHp + "\t\t\tDexterity: " + rogueDex +
                "\nMana: " + rogueCurrMp + "/" + rogueMaxMp + "\t\t\tConstitution: " + rogueCon +
                "\nDefense: " + rogueDefense + "\t\t\t\tIntellect: " + rogueInt +
                "\nAttack: " + rogueAttack + "\t\t\t\tAttribute Points: " + rogueAttributePoints +
                "\nCrit rate: " + rogueCrRate +
                "\nCrit Damage " + rogueCrDmg +
                "\nDodge: " + rogueDodge +
                "\n\nUnspent Skill Points: " + rogueSkillPoints;
        }
    }

    public void RogueConUpgrade()
    {
        if (rogueAttributePoints > 0)
        {
            rogueAttributePoints--;
            rogueCon++;
            rogueCurrHp += 30;
            rogueMaxHp += 30;
            rogueDefense += 4;
            rogueCurrMp += 10;
            rogueMaxMp += 10;
            rogueDodge += 0.025f;
            //Update stats first
            rogueStats2.text =
                "Rogue Stats:" +
                "\nLevel: " + player.GetComponent<PlayerController>().rogueCurrLvl + "\t\t\t\tStrength: " + rogueStr +
                "\nHealth: " + rogueCurrHp + "/" + rogueMaxHp + "\t\t\tDexterity: " + rogueDex +
                "\nMana: " + rogueCurrMp + "/" + rogueMaxMp + "\t\t\tConstitution: " + rogueCon +
                "\nDefense: " + rogueDefense + "\t\t\t\tIntellect: " + rogueInt +
                "\nAttack: " + rogueAttack + "\t\t\t\tAttribute Points: " + rogueAttributePoints +
                "\nCrit rate: " + rogueCrRate +
                "\nCrit Damage " + rogueCrDmg +
                "\nDodge: " + rogueDodge +
                "\n\nUnspent Skill Points: " + rogueSkillPoints;
        }
    }

    public void RogueIntUpgrade()
    {
        if (rogueAttributePoints > 0)
        {
            rogueAttributePoints--;
            rogueInt++;
            rogueCurrHp += 10;
            rogueMaxHp += 10;
            rogueCurrMp += 30;
            rogueMaxMp += 30;
            rogueDodge += 0.05f;
            //Update stats first
            rogueStats2.text =
                "Rogue Stats:" +
                "\nLevel: " + player.GetComponent<PlayerController>().rogueCurrLvl + "\t\t\t\tStrength: " + rogueStr +
                "\nHealth: " + rogueCurrHp + "/" + rogueMaxHp + "\t\t\tDexterity: " + rogueDex +
                "\nMana: " + rogueCurrMp + "/" + rogueMaxMp + "\t\t\tConstitution: " + rogueCon +
                "\nDefense: " + rogueDefense + "\t\t\t\tIntellect: " + rogueInt +
                "\nAttack: " + rogueAttack + "\t\t\t\tAttribute Points: " + rogueAttributePoints +
                "\nCrit rate: " + rogueCrRate +
                "\nCrit Damage " + rogueCrDmg +
                "\nDodge: " + rogueDodge +
                "\n\nUnspent Skill Points: " + rogueSkillPoints;
        }
    }

    public void RogueAcceptStats()
    {
        player.GetComponent<PlayerController>().rogueMaxHp = rogueMaxHp;
        player.GetComponent<PlayerController>().rogueCurrHp = rogueCurrHp;
        player.GetComponent<PlayerController>().rogueDefense = rogueDefense;
        player.GetComponent<PlayerController>().rogueAttack = rogueAttack;
        player.GetComponent<PlayerController>().rogueCrRate = rogueCrRate;
        player.GetComponent<PlayerController>().rogueCrDmg = rogueCrDmg;
        player.GetComponent<PlayerController>().rogueDodge = rogueDodge;
        player.GetComponent<PlayerController>().rogueMaxMp = rogueMaxMp;
        player.GetComponent<PlayerController>().rogueCurrMp = rogueCurrMp;
        player.GetComponent<PlayerController>().rogueSkillPoints = rogueSkillPoints;
        player.GetComponent<PlayerController>().rogueAttributePoints = rogueAttributePoints;
        player.GetComponent<PlayerController>().rogueStr = rogueStr;
        player.GetComponent<PlayerController>().rogueDex = rogueDex;
        player.GetComponent<PlayerController>().rogueCon = rogueCon;
        player.GetComponent<PlayerController>().rogueInt = rogueInt;

        player.GetComponent<PlayerController>().rogueStealthLvl = Skill_Stealth;
        player.GetComponent<PlayerController>().rogueExecuteLvl = Skill_Execute;
        player.GetComponent<PlayerController>().rogueBombLvl = Skill_Bomb;

    }

    public void RogueCancelStats()
    {
        //Reset temp vars
        rogueMaxHp = player.GetComponent<PlayerController>().rogueMaxHp;
        rogueCurrHp = player.GetComponent<PlayerController>().rogueCurrHp;
        rogueDefense = player.GetComponent<PlayerController>().rogueDefense;
        rogueAttack = player.GetComponent<PlayerController>().rogueAttack;
        rogueCrRate = player.GetComponent<PlayerController>().rogueCrRate;
        rogueCrDmg = player.GetComponent<PlayerController>().rogueCrDmg;
        rogueDodge = player.GetComponent<PlayerController>().rogueDodge;
        rogueMaxMp = player.GetComponent<PlayerController>().rogueMaxMp;
        rogueCurrMp = player.GetComponent<PlayerController>().rogueCurrMp;
        rogueSkillPoints = player.GetComponent<PlayerController>().rogueSkillPoints;
        rogueAttributePoints = player.GetComponent<PlayerController>().rogueAttributePoints;
        rogueStr = player.GetComponent<PlayerController>().rogueStr;
        rogueDex = player.GetComponent<PlayerController>().rogueDex;
        rogueCon = player.GetComponent<PlayerController>().rogueCon;
        rogueInt = player.GetComponent<PlayerController>().rogueInt;

        Skill_Stealth = player.GetComponent<PlayerController>().rogueStealthLvl;
        Skill_Execute = player.GetComponent<PlayerController>().rogueExecuteLvl;
        Skill_Bomb = player.GetComponent<PlayerController>().rogueBombLvl;

    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////
    ///

    //Warrior
    public void WarriorStrUpgrade()
    {
        if (warriorAttributePoints > 0)
        {
            warriorAttributePoints--;
            warriorStr++;
            warriorCurrHp += 10;
            warriorMaxHp += 10;
            warriorDefense += 4;
            warriorAttack += 10;
            warriorCrRate += 2;
            warriorCrDmg += 0.05f;
            //Update stats first
            warriorStats2.text =
                "Warrior Stats:" +
                "\nLevel: " + player.GetComponent<PlayerController>().warriorCurrLvl + "\t\t\t\tStrength: " + warriorStr +
                "\nHealth: " + warriorCurrHp + "/" + warriorMaxHp + "\t\t\tDexterity: " + warriorDex +
                "\nMana: " + warriorCurrMp + "/" + warriorMaxMp + "\t\t\tConstitution: " + warriorCon +
                "\nDefense: " + warriorDefense + "\t\t\t\tIntellect: " + warriorInt +
                "\nAttack: " + warriorAttack + "\t\t\t\tAttribute Points: " + warriorAttributePoints +
                "\nCrit rate: " + warriorCrRate +
                "\nCrit Damage " + warriorCrDmg +
                "\nDodge: " + warriorDodge +
                "\n\nUnspent Skill Points: " + warriorSkillPoints;
        }
    }

    public void WarriorDexUpgrade()
    {
        if (warriorAttributePoints > 0)
        {
            warriorAttributePoints--;
            warriorDex++;
            warriorDefense += 2;
            warriorAttack += 10;
            warriorCrRate += 4;
            warriorCrDmg += 0.1f;
            //Update stats first
            warriorStats2.text =
                "Warrior Stats:" +
                "\nLevel: " + player.GetComponent<PlayerController>().warriorCurrLvl + "\t\t\t\tStrength: " + warriorStr +
                "\nHealth: " + warriorCurrHp + "/" + warriorMaxHp + "\t\t\tDexterity: " + warriorDex +
                "\nMana: " + warriorCurrMp + "/" + warriorMaxMp + "\t\t\tConstitution: " + warriorCon +
                "\nDefense: " + warriorDefense + "\t\t\t\tIntellect: " + warriorInt +
                "\nAttack: " + warriorAttack + "\t\t\t\tAttribute Points: " + warriorAttributePoints +
                "\nCrit rate: " + warriorCrRate +
                "\nCrit Damage " + warriorCrDmg +
                "\nDodge: " + warriorDodge +
                "\n\nUnspent Skill Points: " + warriorSkillPoints;
        }
    }

    public void WarriorConUpgrade()
    {
        if (warriorAttributePoints > 0)
        {
            warriorAttributePoints--;
            warriorCon++;
            warriorCurrHp += 30;
            warriorMaxHp += 30;
            warriorDefense += 4;
            warriorCurrMp += 10;
            warriorMaxMp += 10;
            warriorDodge += 0.025f;
            //Update stats first
            warriorStats2.text =
                "Warrior Stats:" +
                "\nLevel: " + player.GetComponent<PlayerController>().warriorCurrLvl + "\t\t\t\tStrength: " + warriorStr +
                "\nHealth: " + warriorCurrHp + "/" + warriorMaxHp + "\t\t\tDexterity: " + warriorDex +
                "\nMana: " + warriorCurrMp + "/" + warriorMaxMp + "\t\t\tConstitution: " + warriorCon +
                "\nDefense: " + warriorDefense + "\t\t\t\tIntellect: " + warriorInt +
                "\nAttack: " + warriorAttack + "\t\t\t\tAttribute Points: " + warriorAttributePoints +
                "\nCrit rate: " + warriorCrRate +
                "\nCrit Damage " + warriorCrDmg +
                "\nDodge: " + warriorDodge +
                "\n\nUnspent Skill Points: " + warriorSkillPoints;
        }
    }

    public void WarriorIntUpgrade()
    {
        if (warriorAttributePoints > 0)
        {
            warriorAttributePoints--;
            warriorInt++;
            warriorCurrHp += 10;
            warriorMaxHp += 10;
            warriorCurrMp += 30;
            warriorMaxMp += 30;
            warriorDodge += 0.05f;
            //Update stats first
            warriorStats2.text =
                "Warrior Stats:" +
                "\nLevel: " + player.GetComponent<PlayerController>().warriorCurrLvl + "\t\t\t\tStrength: " + warriorStr +
                "\nHealth: " + warriorCurrHp + "/" + warriorMaxHp + "\t\t\tDexterity: " + warriorDex +
                "\nMana: " + warriorCurrMp + "/" + warriorMaxMp + "\t\t\tConstitution: " + warriorCon +
                "\nDefense: " + warriorDefense + "\t\t\t\tIntellect: " + warriorInt +
                "\nAttack: " + warriorAttack + "\t\t\t\tAttribute Points: " + warriorAttributePoints +
                "\nCrit rate: " + warriorCrRate +
                "\nCrit Damage " + warriorCrDmg +
                "\nDodge: " + warriorDodge +
                "\n\nUnspent Skill Points: " + warriorSkillPoints;
        }
    }

    public void WarriorAcceptStats()
    {
        player.GetComponent<PlayerController>().warriorMaxHp = warriorMaxHp;
        player.GetComponent<PlayerController>().warriorCurrHp = warriorCurrHp;
        player.GetComponent<PlayerController>().warriorDefense = warriorDefense;
        player.GetComponent<PlayerController>().warriorAttack = warriorAttack;
        player.GetComponent<PlayerController>().warriorCrRate = warriorCrRate;
        player.GetComponent<PlayerController>().warriorCrDmg = warriorCrDmg;
        player.GetComponent<PlayerController>().warriorDodge = warriorDodge;
        player.GetComponent<PlayerController>().warriorMaxMp = warriorMaxMp;
        player.GetComponent<PlayerController>().warriorCurrMp = warriorCurrMp;
        player.GetComponent<PlayerController>().warriorSkillPoints = warriorSkillPoints;
        player.GetComponent<PlayerController>().warriorAttributePoints = warriorAttributePoints;
        player.GetComponent<PlayerController>().warriorStr = warriorStr;
        player.GetComponent<PlayerController>().warriorDex = warriorDex;
        player.GetComponent<PlayerController>().warriorCon = warriorCon;
        player.GetComponent<PlayerController>().warriorInt = warriorInt;

        player.GetComponent<PlayerController>().warriorIronheartLvl = Skill_Ironheart;
        player.GetComponent<PlayerController>().warriorRevengeLvl = Skill_Revenge;
        player.GetComponent<PlayerController>().warriorSacrificeLvl = Skill_Sacrifice;
    }

    public void WarriorCancelStats()
    {
        warriorMaxHp = player.GetComponent<PlayerController>().warriorMaxHp;
        warriorCurrHp = player.GetComponent<PlayerController>().warriorCurrHp;
        warriorDefense = player.GetComponent<PlayerController>().warriorDefense;
        warriorAttack = player.GetComponent<PlayerController>().warriorAttack;
        warriorCrRate = player.GetComponent<PlayerController>().warriorCrRate;
        warriorCrDmg = player.GetComponent<PlayerController>().warriorCrDmg;
        warriorDodge = player.GetComponent<PlayerController>().warriorDodge;
        warriorMaxMp = player.GetComponent<PlayerController>().warriorMaxMp;
        warriorCurrMp = player.GetComponent<PlayerController>().warriorCurrMp;
        warriorSkillPoints = player.GetComponent<PlayerController>().warriorSkillPoints;
        warriorAttributePoints = player.GetComponent<PlayerController>().warriorAttributePoints;
        warriorStr = player.GetComponent<PlayerController>().warriorStr;
        warriorDex = player.GetComponent<PlayerController>().warriorDex;
        warriorCon = player.GetComponent<PlayerController>().warriorCon;
        warriorInt = player.GetComponent<PlayerController>().warriorInt;

        Skill_Ironheart = player.GetComponent<PlayerController>().warriorIronheartLvl;
        Skill_Revenge = player.GetComponent<PlayerController>().warriorRevengeLvl;
        Skill_Sacrifice = player.GetComponent<PlayerController>().warriorSacrificeLvl;
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////
    ///
    //Ranger
    public void RangerStrUpgrade()
    {
        if (rangerAttributePoints > 0)
        {
            rangerAttributePoints--;
            rangerStr++;
            rangerCurrHp += 10;
            rangerMaxHp += 10;
            rangerDefense += 4;
            rangerAttack += 10;
            rangerCrRate += 2;
            rangerCrDmg += 0.05f;
            //Update stats first
            rangerStats2.text =
                "Ranger Stats:" +
                "\nLevel: " + player.GetComponent<PlayerController>().rangerCurrLvl + "\t\t\t\tStrength: " + rangerStr +
                "\nHealth: " + rangerCurrHp + "/" + rangerMaxHp + "\t\t\tDexterity: " + rangerDex +
                "\nMana: " + rangerCurrMp + "/" + rangerMaxMp + "\t\t\tConstitution: " + rangerCon +
                "\nDefense: " + rangerDefense + "\t\t\t\tIntellect: " + rangerInt +
                "\nAttack: " + rangerAttack + "\t\t\t\tAttribute Points: " + rangerAttributePoints +
                "\nCrit rate: " + rangerCrRate +
                "\nCrit Damage " + rangerCrDmg +
                "\nDodge: " + rangerDodge +
                "\n\nUnspent Skill Points: " + rangerSkillPoints;
        }
    }

    public void RangerDexUpgrade()
    {
        if (rangerAttributePoints > 0)
        {
            rangerAttributePoints--;
            rangerDex++;
            rangerDefense += 2;
            rangerAttack += 10;
            rangerCrRate += 4;
            rangerCrDmg += 0.1f;
            //Update stats first
            rangerStats2.text =
                "Ranger Stats:" +
                "\nLevel: " + player.GetComponent<PlayerController>().rangerCurrLvl + "\t\t\t\tStrength: " + rangerStr +
                "\nHealth: " + rangerCurrHp + "/" + rangerMaxHp + "\t\t\tDexterity: " + rangerDex +
                "\nMana: " + rangerCurrMp + "/" + rangerMaxMp + "\t\t\tConstitution: " + rangerCon +
                "\nDefense: " + rangerDefense + "\t\t\t\tIntellect: " + rangerInt +
                "\nAttack: " + rangerAttack + "\t\t\t\tAttribute Points: " + rangerAttributePoints +
                "\nCrit rate: " + rangerCrRate +
                "\nCrit Damage " + rangerCrDmg +
                "\nDodge: " + rangerDodge +
                "\n\nUnspent Skill Points: " + rangerSkillPoints;
        }
    }

    public void RangerConUpgrade()
    {
        if (rangerAttributePoints > 0)
        {
            rangerAttributePoints--;
            rangerCon++;
            rangerCurrHp += 30;
            rangerMaxHp += 30;
            rangerDefense += 4;
            rangerCurrMp += 10;
            rangerMaxMp += 10;
            rangerDodge += 0.025f;
            //Update stats first
            rangerStats2.text =
                "Ranger Stats:" +
                "\nLevel: " + player.GetComponent<PlayerController>().rangerCurrLvl + "\t\t\t\tStrength: " + rangerStr +
                "\nHealth: " + rangerCurrHp + "/" + rangerMaxHp + "\t\t\tDexterity: " + rangerDex +
                "\nMana: " + rangerCurrMp + "/" + rangerMaxMp + "\t\t\tConstitution: " + rangerCon +
                "\nDefense: " + rangerDefense + "\t\t\t\tIntellect: " + rangerInt +
                "\nAttack: " + rangerAttack + "\t\t\t\tAttribute Points: " + rangerAttributePoints +
                "\nCrit rate: " + rangerCrRate +
                "\nCrit Damage " + rangerCrDmg +
                "\nDodge: " + rangerDodge +
                "\n\nUnspent Skill Points: " + rangerSkillPoints;
        }
    }

    public void RangerIntUpgrade()
    {
        if (rangerAttributePoints > 0)
        {
            rangerAttributePoints--;
            rangerInt++;
            rangerCurrHp += 10;
            rangerMaxHp += 10;
            rangerCurrMp += 30;
            rangerMaxMp += 30;
            rangerDodge += 0.05f;
            //Update stats first
            rangerStats2.text =
                "Ranger Stats:" +
                "\nLevel: " + player.GetComponent<PlayerController>().rangerCurrLvl + "\t\t\t\tStrength: " + rangerStr +
                "\nHealth: " + rangerCurrHp + "/" + rangerMaxHp + "\t\t\tDexterity: " + rangerDex +
                "\nMana: " + rangerCurrMp + "/" + rangerMaxMp + "\t\t\tConstitution: " + rangerCon +
                "\nDefense: " + rangerDefense + "\t\t\t\tIntellect: " + rangerInt +
                "\nAttack: " + rangerAttack + "\t\t\t\tAttribute Points: " + rangerAttributePoints +
                "\nCrit rate: " + rangerCrRate +
                "\nCrit Damage " + rangerCrDmg +
                "\nDodge: " + rangerDodge +
                "\n\nUnspent Skill Points: " + rangerSkillPoints;
        }
    }

    public void RangerAcceptStats()
    {
        player.GetComponent<PlayerController>().rangerMaxHp = rangerMaxHp;
        player.GetComponent<PlayerController>().rangerCurrHp = rangerCurrHp;
        player.GetComponent<PlayerController>().rangerDefense = rangerDefense;
        player.GetComponent<PlayerController>().rangerAttack = rangerAttack;
        player.GetComponent<PlayerController>().rangerCrRate = rangerCrRate;
        player.GetComponent<PlayerController>().rangerCrDmg = rangerCrDmg;
        player.GetComponent<PlayerController>().rangerDodge = rangerDodge;
        player.GetComponent<PlayerController>().rangerMaxMp = rangerMaxMp;
        player.GetComponent<PlayerController>().rangerCurrMp = rangerCurrMp;
        player.GetComponent<PlayerController>().rangerSkillPoints = rangerSkillPoints;
        player.GetComponent<PlayerController>().rangerAttributePoints = rangerAttributePoints;
        player.GetComponent<PlayerController>().rangerStr = rangerStr;
        player.GetComponent<PlayerController>().rangerDex = rangerDex;
        player.GetComponent<PlayerController>().rangerCon = rangerCon;
        player.GetComponent<PlayerController>().rangerInt = rangerInt;

        player.GetComponent<PlayerController>().rangerTrapLvl = Skill_Trap;
        player.GetComponent<PlayerController>().rangerFocusShotLvl = Skill_FocusShot;
        player.GetComponent<PlayerController>().rangerCripplingShotLvl = Skill_CripplingShot;
    }

    public void RangerCancelStats()
    {
        //Reset temp vars
        rangerMaxHp = player.GetComponent<PlayerController>().rangerMaxHp;
        rangerCurrHp = player.GetComponent<PlayerController>().rangerCurrHp;
        rangerDefense = player.GetComponent<PlayerController>().rangerDefense;
        rangerAttack = player.GetComponent<PlayerController>().rangerAttack;
        rangerCrRate = player.GetComponent<PlayerController>().rangerCrRate;
        rangerCrDmg = player.GetComponent<PlayerController>().rangerCrDmg;
        rangerDodge = player.GetComponent<PlayerController>().rangerDodge;
        rangerMaxMp = player.GetComponent<PlayerController>().rangerMaxMp;
        rangerCurrMp = player.GetComponent<PlayerController>().rangerCurrMp;
        rangerSkillPoints = player.GetComponent<PlayerController>().rangerSkillPoints;
        rangerAttributePoints = player.GetComponent<PlayerController>().rangerAttributePoints;
        rangerStr = player.GetComponent<PlayerController>().rangerStr;
        rangerDex = player.GetComponent<PlayerController>().rangerDex;
        rangerCon = player.GetComponent<PlayerController>().rangerCon;
        rangerInt = player.GetComponent<PlayerController>().rangerInt;

        Skill_Trap = player.GetComponent<PlayerController>().rangerTrapLvl;
        Skill_FocusShot = player.GetComponent<PlayerController>().rangerFocusShotLvl;
        Skill_CripplingShot = player.GetComponent<PlayerController>().rangerCripplingShotLvl;

    }


    //Cleric
    public void ClericStrUpgrade()
    {
        if (clericAttributePoints > 0)
        {
            clericAttributePoints--;
            clericStr++;
            clericCurrHp += 10;
            clericMaxHp += 10;
            clericDefense += 4;
            clericAttack += 10;
            clericCrRate += 2;
            clericCrDmg += 0.05f;
            //Update stats first
            clericStats2.text =
                "Cleric Stats:" +
                "\nLevel: " + player.GetComponent<PlayerController>().clericCurrLvl + "\t\t\t\tStrength: " + clericStr +
                "\nHealth: " + clericCurrHp + "/" + clericMaxHp + "\t\t\tDexterity: " + clericDex +
                "\nMana: " + clericCurrMp + "/" + clericMaxMp + "\t\t\tConstitution: " + clericCon +
                "\nDefense: " + clericDefense + "\t\t\t\tIntellect: " + clericInt +
                "\nAttack: " + clericAttack + "\t\t\t\tAttribute Points: " + clericAttributePoints +
                "\nCrit rate: " + clericCrRate +
                "\nCrit Damage " + clericCrDmg +
                "\n\nUnspent Skill Points: " + clericSkillPoints;
        }
    }

    public void ClericDexUpgrade()
    {
        if (clericAttributePoints > 0)
        {
            clericAttributePoints--;
            clericDex++;
            clericDefense += 2;
            clericAttack += 10;
            clericCrRate += 4;
            clericCrDmg += 0.1f;
            //Update stats first
            clericStats2.text =
                "Cleric Stats:" +
                "\nLevel: " + player.GetComponent<PlayerController>().clericCurrLvl + "\t\t\t\tStrength: " + clericStr +
                "\nHealth: " + clericCurrHp + "/" + clericMaxHp + "\t\t\tDexterity: " + clericDex +
                "\nMana: " + clericCurrMp + "/" + clericMaxMp + "\t\t\tConstitution: " + clericCon +
                "\nDefense: " + clericDefense + "\t\t\t\tIntellect: " + clericInt +
                "\nAttack: " + clericAttack + "\t\t\t\tAttribute Points: " + clericAttributePoints +
                "\nCrit rate: " + clericCrRate +
                "\nCrit Damage " + clericCrDmg +
                "\n\nUnspent Skill Points: " + clericSkillPoints;
        }
    }

    public void ClericConUpgrade()
    {
        if (clericAttributePoints > 0)
        {
            clericAttributePoints--;
            clericCon++;
            clericCurrHp += 30;
            clericMaxHp += 30;
            clericDefense += 4;
            clericDodge += 0.025f;
            clericCurrMp += 10;
            clericMaxMp += 10;
            //Update stats first
            clericStats2.text =
                "Cleric Stats:" +
                "\nLevel: " + player.GetComponent<PlayerController>().clericCurrLvl + "\t\t\t\tStrength: " + clericStr +
                "\nHealth: " + clericCurrHp + "/" + clericMaxHp + "\t\t\tDexterity: " + clericDex +
                "\nMana: " + clericCurrMp + "/" + clericMaxMp + "\t\t\tConstitution: " + clericCon +
                "\nDefense: " + clericDefense + "\t\t\t\tIntellect: " + clericInt +
                "\nAttack: " + clericAttack + "\t\t\t\tAttribute Points: " + clericAttributePoints +
                "\nCrit rate: " + clericCrRate +
                "\nCrit Damage " + clericCrDmg +
                "\n\nUnspent Skill Points: " + clericSkillPoints;
        }
    }

    public void ClericIntUpgrade()
    {
        if (clericAttributePoints > 0)
        {
            clericAttributePoints--;
            clericInt++;
            clericCurrHp += 10;
            clericMaxHp += 10;
            clericDodge += 0.05f;
            clericCurrMp += 30;
            clericMaxMp += 30;
            //Update stats first
            clericStats2.text =
                "Cleric Stats:" +
                "\nLevel: " + player.GetComponent<PlayerController>().clericCurrLvl + "\t\t\t\tStrength: " + clericStr +
                "\nHealth: " + clericCurrHp + "/" + clericMaxHp + "\t\t\tDexterity: " + clericDex +
                "\nMana: " + clericCurrMp + "/" + clericMaxMp + "\t\t\tConstitution: " + clericCon +
                "\nDefense: " + clericDefense + "\t\t\t\tIntellect: " + clericInt +
                "\nAttack: " + clericAttack + "\t\t\t\tAttribute Points: " + clericAttributePoints +
                "\nCrit rate: " + clericCrRate +
                "\nCrit Damage " + clericCrDmg +
                "\n\nUnspent Skill Points: " + clericSkillPoints;
        }
    }

    public void ClericAcceptStats()
    {
        player.GetComponent<PlayerController>().clericMaxHp = clericMaxHp;
        player.GetComponent<PlayerController>().clericCurrHp = clericCurrHp;
        player.GetComponent<PlayerController>().clericDefense = clericDefense;
        player.GetComponent<PlayerController>().clericAttack = clericAttack;
        player.GetComponent<PlayerController>().clericCrRate = clericCrRate;
        player.GetComponent<PlayerController>().clericCrDmg = clericCrDmg;
        player.GetComponent<PlayerController>().clericDodge = clericDodge;
        player.GetComponent<PlayerController>().clericMaxMp = clericMaxMp;
        player.GetComponent<PlayerController>().clericCurrMp = clericCurrMp;
        player.GetComponent<PlayerController>().clericSkillPoints = clericSkillPoints;
        player.GetComponent<PlayerController>().clericAttributePoints = clericAttributePoints;
        player.GetComponent<PlayerController>().clericStr = clericStr;
        player.GetComponent<PlayerController>().clericDex = clericDex;
        player.GetComponent<PlayerController>().clericCon = clericCon;
        player.GetComponent<PlayerController>().clericInt = clericInt;

        player.GetComponent<PlayerController>().clericHealLvl = Skill_Heal;
        player.GetComponent<PlayerController>().clericResurrectionLvl = Skill_Resurrection;
        player.GetComponent<PlayerController>().clericRaiseTheDeadLvl = Skill_RaiseTheDead;
    }

    public void ClericCancelStats()
    {
        //Reset temp vars
        clericMaxHp = player.GetComponent<PlayerController>().clericMaxHp;
        clericCurrHp = player.GetComponent<PlayerController>().clericCurrHp;
        clericDefense = player.GetComponent<PlayerController>().clericDefense;
        clericAttack = player.GetComponent<PlayerController>().clericAttack;
        clericCrRate = player.GetComponent<PlayerController>().clericCrRate;
        clericCrDmg = player.GetComponent<PlayerController>().clericCrDmg;
        clericDodge = player.GetComponent<PlayerController>().clericDodge;
        clericMaxMp = player.GetComponent<PlayerController>().clericMaxMp;
        clericCurrMp = player.GetComponent<PlayerController>().clericCurrMp;
        clericSkillPoints = player.GetComponent<PlayerController>().clericSkillPoints;
        clericAttributePoints = player.GetComponent<PlayerController>().clericAttributePoints;
        clericStr = player.GetComponent<PlayerController>().clericStr;
        clericDex = player.GetComponent<PlayerController>().clericDex;
        clericCon = player.GetComponent<PlayerController>().clericCon;
        clericInt = player.GetComponent<PlayerController>().clericInt;

        Skill_Heal = player.GetComponent<PlayerController>().clericHealLvl;
        Skill_Resurrection = player.GetComponent<PlayerController>().clericResurrectionLvl;
        Skill_RaiseTheDead = player.GetComponent<PlayerController>().clericRaiseTheDeadLvl;

    }

    /*
     * Skills
     * 
     */

    public void Skill_Stealth_Upgrade()
    { //Make previous skill btns uninteractable
        //By default second one is only interactable
        //Debug.Log(Skill_Stealth);
        Image image;
        if (rogueSkillPoints > 0 && Skill_Stealth < 3)
        {
            rogueSkillPoints -= 1;
            Skill_Stealth += 1;
        }

        //This for loop on update as well
        for(int i = 1; i < Stealth.Length-2; i++)
        {
            if(Skill_Stealth == i)
            {
                StealthBtns[i+1].interactable = true;
                StealthBtns[i].interactable = false;
            }
            else
            {
                StealthBtns[i + 1].interactable = false;
            }
        }
        
        for (int i = 1; i <= Stealth.Length-1; i++)
        {
            if (Skill_Stealth >= i)
            {
                image = Stealth[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = Stealth[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }

    }

    public void Skill_Execute_Upgrade()
    {
        Image image;
        if (rogueSkillPoints > 0 && Skill_Execute < 3)
        {
            rogueSkillPoints -= 1;
            Skill_Execute += 1;
        }

        //This for loop on update as well
        for (int i = 1; i < Execute.Length - 2; i++)
        {
            if (Skill_Execute == i)
            {
                ExecuteBtns[i + 1].interactable = true;
                ExecuteBtns[i].interactable = false;
            }
            else
            {
                ExecuteBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= Execute.Length - 1; i++)
        {
            if (Skill_Execute >= i)
            {
                image = Execute[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = Execute[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }
    }

    public void Skill_Bomb_Upgrade()
    {
        Image image;
        if (rogueSkillPoints > 0 && Skill_Bomb < 3)
        {
            rogueSkillPoints -= 1;
            Skill_Bomb += 1;
        }

        //This for loop on update as well
        for (int i = 1; i < Bomb.Length - 2; i++)
        {
            if (Skill_Bomb == i)
            {
                BombBtns[i + 1].interactable = true;
                BombBtns[i].interactable = false;
            }
            else
            {
                BombBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= Bomb.Length - 1; i++)
        {
            if (Skill_Bomb >= i)
            {
                image = Bomb[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = Bomb[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }
    }

    public void Skill_Ironheart_Upgrade()
    {
        Image image;
        if (warriorSkillPoints > 0 && Skill_Ironheart < 3)
        {
            warriorSkillPoints -= 1;
            Skill_Ironheart += 1;
        }

        //This for loop on update as well
        for (int i = 1; i < Ironheart.Length - 2; i++)
        {
            if (Skill_Ironheart == i)
            {
                IronheartBtns[i + 1].interactable = true;
                IronheartBtns[i].interactable = false;
            }
            else
            {
                IronheartBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= Ironheart.Length - 1; i++)
        {
            if (Skill_Ironheart >= i)
            {
                image = Ironheart[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = Ironheart[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }
    }

    public void Skill_Revenge_Upgrade()
    {
        Image image;
        if (warriorSkillPoints > 0 && Skill_Revenge < 3)
        {
            warriorSkillPoints -= 1;
            Skill_Revenge += 1;
        }

        //This for loop on update as well
        for (int i = 1; i < Revenge.Length - 2; i++)
        {
            if (Skill_Revenge == i)
            {
                RevengeBtns[i + 1].interactable = true;
                RevengeBtns[i].interactable = false;
            }
            else
            {
                RevengeBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= Revenge.Length - 1; i++)
        {
            if (Skill_Revenge >= i)
            {
                image = Revenge[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = Revenge[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }
    }

    public void Skill_Sacrifice_Upgrade()
    {
        Image image;
        if (warriorSkillPoints > 0 && Skill_Sacrifice < 3)
        {
            warriorSkillPoints -= 1;
            Skill_Sacrifice += 1;
        }

        //This for loop on update as well
        for (int i = 1; i < Sacrifice.Length - 2; i++)
        {
            if (Skill_Sacrifice == i)
            {
                SacrificeBtns[i + 1].interactable = true;
                SacrificeBtns[i].interactable = false;
            }
            else
            {
                SacrificeBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= Sacrifice.Length - 1; i++)
        {
            if (Skill_Sacrifice >= i)
            {
                image = Sacrifice[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = Sacrifice[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }
    }

    public void Skill_Trap_Upgrade()
    {
        Image image;
        if (rangerSkillPoints > 0 && Skill_Trap < 3)
        {
            rangerSkillPoints -= 1;
            Skill_Trap += 1;
        }

        //This for loop on update as well
        for (int i = 1; i < Trap.Length - 2; i++)
        {
            if (Skill_Trap == i)
            {
                TrapBtns[i + 1].interactable = true;
                TrapBtns[i].interactable = false;
            }
            else
            {
                TrapBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= Trap.Length - 1; i++)
        {
            if (Skill_Trap >= i)
            {
                image = Trap[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = Trap[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }
    }

    public void Skill_FocusShot_Upgrade()
    {
        Image image;
        if (rangerSkillPoints > 0 && Skill_FocusShot < 3)
        {
            rangerSkillPoints -= 1;
            Skill_FocusShot += 1;
        }

        //This for loop on update as well
        for (int i = 1; i < FocusShot.Length - 2; i++)
        {
            if (Skill_FocusShot == i)
            {
                
                FocusShotBtns[i + 1].interactable = true;
                
                FocusShotBtns[i].interactable = false;
            }
            else
            {
                FocusShotBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= FocusShot.Length - 1; i++)
        {
            if (Skill_FocusShot >= i)
            {
                image = FocusShot[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = FocusShot[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }
        //Debug.Log(Skill_FocusShot);
    }

    public void Skill_CripplingShot_Upgrade()
    {
        Image image;
        if (rangerSkillPoints > 0 && Skill_CripplingShot < 3)
        {
            rangerSkillPoints -= 1;
            Skill_CripplingShot += 1;
        }

        //This for loop on update as well
        for (int i = 1; i < CripplingShot.Length - 2; i++)
        {
            if (Skill_CripplingShot == i)
            {
                CripplingShotBtns[i + 1].interactable = true;
                CripplingShotBtns[i].interactable = false;
            }
            else
            {
                CripplingShotBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= CripplingShot.Length - 1; i++)
        {
            if (Skill_CripplingShot >= i)
            {
                image = CripplingShot[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = CripplingShot[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }
    }


    public void Skill_Heal_Upgrade()
    {
        Image image;
        if (clericSkillPoints > 0 && Skill_Heal < 3)
        {
            clericSkillPoints -= 1;
            Skill_Heal += 1;
        }

        //This for loop on update as well
        for (int i = 1; i < Heal.Length - 2; i++)
        {
            if (Skill_Heal == i)
            {
                HealBtns[i + 1].interactable = true;
                HealBtns[i].interactable = false;
            }
            else
            {
                HealBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= Heal.Length - 1; i++)
        {
            if (Skill_Heal >= i)
            {
                image = Heal[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = Heal[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }
    }

    public void Skill_Resurrection_Upgrade()
    {
        Image image;
        if (clericSkillPoints > 0 && Skill_Resurrection < 3)
        {
            clericSkillPoints -= 1;
            Skill_Resurrection += 1;
        }

        //This for loop on update as well
        for (int i = 1; i < Resurrection.Length - 2; i++)
        {
            if (Skill_Resurrection == i)
            {
                ResurrectionBtns[i + 1].interactable = true;
                ResurrectionBtns[i].interactable = false;
            }
            else
            {
                ResurrectionBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= Resurrection.Length - 1; i++)
        {
            if (Skill_Resurrection >= i)
            {
                image = Resurrection[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = Resurrection[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }
    }

    public void Skill_RaiseTheDead_Upgrade()
    {
        Image image;
        if (rangerSkillPoints > 0 && Skill_RaiseTheDead < 3)
        {
            rogueSkillPoints -= 1;
            Skill_RaiseTheDead += 1;
        }

        //This for loop on update as well
        for (int i = 1; i < RaiseTheDead.Length - 2; i++)
        {
            if (Skill_RaiseTheDead == i)
            {
                RaiseTheDeadBtns[i + 1].interactable = true;
                RaiseTheDeadBtns[i].interactable = false;
            }
            else
            {
                RaiseTheDeadBtns[i + 1].interactable = false;
            }
        }

        for (int i = 1; i <= RaiseTheDead.Length - 1; i++)
        {
            if (Skill_RaiseTheDead >= i)
            {
                image = RaiseTheDead[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
            }
            else
            {
                image = RaiseTheDead[i].GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.5f;
                image.color = tempColor;
            }
        }
    }








    public void test()
    {
        Debug.Log(0);
    }


}
