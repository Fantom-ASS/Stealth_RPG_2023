using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHeroStats : MonoBehaviour
{
    public int score;

    // Basic
    public string charName;
    public int clan;
    public string race;

    //Data
    public float totalExp;
    public float freeExp;
    

    public float maxHP;
    public float curHP;
    public float maxMP;
    public float curMP;
    public int strength;
    public int agility;
    public int intelligence;

    public float damage;
    public string typedamage;
    public string attackType;

    public float actionstat;
    public int attack;
    public int defence;
    public int blockrate;
    public float blockdamage;

    public int weight;
    public int maxweight;

    public float healthregen;
    public float manaregen;
    public float attackspeed;
    public float castrate;
    public float stunspeed;
    public float stunchance;

    public float walkspeed;
    public string movemod;

    public bool alive;
    public bool safe;
    public bool run;

    public int melee;
    public int shoot;
    public int theft;

    public int elemental;
    public int sencory;
    public int astral;

    public float curmaxHPdiff;
    public float curmaxMPdiff;


    //perks
    public int strg;
    public int agil;
    public int intel;

    public int sword;
    public int axe;
    public int mace;
    public int spear;
    public int dagger;

    public int bow;
    public int crossbow;
    public int thr;

    public int firemagic;
    public int lightmagic;
    public int acidmagic;
    public int coldmagic;
    public int sencemagic;
    public int astralmagic;

    public int inhealth;
    public int inmana;
    public int reghealth;
    public int regmana;

    public int nightvision;
    public int hack;
    public int backstab;
    public int actions;
    public int runspeed;
    public int liftweight;

    //simple ablilities
    public bool stronghit;
    public bool deadlyhit;
    public bool slashhit;
    public bool doublehit;

    public bool doublethrow;
    public bool strongthrow;
    public bool bunchthrow;

    public bool arrowrain;
    public bool magicarrow;
    public bool homingarrow;

    public bool firebolt;
    public bool pyrocynesis;
    public bool fireball;

    public bool lighting;
    public bool chainlighting;
    public bool lightcharges;

    public bool acidclot;
    public bool deathbreath;
    public bool acidball;

    public bool coldarrow;
    public bool coldspike;
    public bool glacialtrap;

    public bool mentalstrike;
    public bool mentalpain;
    public bool telekinesis;

    public bool astralseal;
    public bool astralhole;
    public bool astralspirit;

    //complex abilities
    public bool charge;
    public bool jump;
    public bool rage;
    public bool backhit;
    public bool vulner;
    public bool smite;

    public bool magicalswarm;
    public bool magicaltraps;
    public bool webarrow;

    public bool magicalmissile;
    public bool bunchthrowing;
    public bool splitthrowing;

    public bool firedef;
    public bool lightdef;
    public bool aciddef;
    public bool colddef;
    public bool magicdef;

    public bool dimvision;
    public bool insanity;
    public bool hypnos;
    public bool silence;
    public bool invisibility;
    public bool magicvision;

    public bool vampirism;
    public bool decrepify;
    public bool anathem;
    public bool might;
    public bool regenhp;
    public bool regenmp;

    public bool teleport;
    public bool magicshield;

    public bool firebreath;
    public bool firewall;
    public bool firespirit;

    public bool skylighting;
    public bool lightorb;
    public bool lightarc;

    public bool acidfountain;
    public bool acidfog;
    public bool acidnova;

    public bool blizzard;
    public bool frozenorb;
    public bool iceblast;

    public bool lethargy;
    public bool paralize;
    public bool heartattack;

    public bool astralrip;
    public bool manaleach;
    public bool astralmode;

    public Curses curses;

    


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curmaxHPdiff = curHP / maxHP;
        curmaxMPdiff = curMP / maxMP;

     //   maxHP = (strength * 10) - (curses.weakness_effect * 10);
     //   maxMP = (intelligence * 10) - (curses.weakness_effect * 10);


        if (curHP < maxHP && alive)
        {
            curHP = maxHP * curmaxHPdiff;
            curHP += (healthregen + curses.regenHP_effect) / 300;
        }

        if (curMP < maxMP)
        {
            curHP = maxHP * curmaxMPdiff;
            curMP += (manaregen + curses.regenMP_effect) / 300;
        }

    }

    private void FixedUpdate()
    {
        if (curHP > maxHP)
        {
            curHP = maxHP;
        }
        if (curHP < 0)
        {
            curHP = 0;
            alive = false;
        }



        if (curMP > maxMP)
        {
            curMP = maxMP;
        }
        if (curMP < 0)
        {
            curMP = 0;
        }


    }



}

