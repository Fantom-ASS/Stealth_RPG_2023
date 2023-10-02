using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Ability_Data : MonoBehaviour
{
    public GameObject caster;
    public Character_Stats casterStats;
    public GameObject target;
    public GameObject buff;

    //basic parameters
    public string name;
    public string type;
    public int level;
    public int charges;
    public int difficult;
    public float cooldown;
    public float manacost;
    public float speed;
    public float effect;
    public float time;
    public float aoe;

    //total parameters
    public float cooldown_total;
    public float manacost_total;
    public float speed_total;
    public float effect_total;
    public float time_total;
    public float aoe_total;
    public int diff_total;
    public int ch_total;

    //available runes
    public bool ch;
    public bool cd;
    public bool mp;
    public bool sp;
    public bool eff;
    public bool ti;
    public bool ae;

    //available targets
    public bool friends;
    public bool enemies;
    public bool alive;
    public bool self;

    //list of added runes
    public string[] runes = new string[5];
    //runelist: ch+ ch++ ch+++ cd- cd-- cd--- mp- mp-- mp--- sp+ sp++ sp+++ eff+ eff++ eff+++ ti+ ti++ ti+++ ae+ ae++ ae+++ di- di-- di---



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StrongStrike()
    {
        name = "StrongStrike";
        type = "passive";
        effect = 0.02f;
        difficult = 5;


        float eff_bonus = 0;
        for (int i = 0; i < runes.Length; i++)
        {
            if (runes[i] == "eff+")
            {
                eff_bonus += effect;
            }
        }
        effect_total = (effect * (float)level) + eff_bonus;
    }

    void Insane()
    {
        name = "Insane";
        type = "autocast";
        effect = 0.03f;
        difficult = 10;
        cooldown = 3;
        manacost = 2;
        effect= 0.03f;


    float eff_bonus = 0;
    float dif_bonus = 0;
    float cd_bonus = 0;
    float mp_bonus = 0;
        for (int i = 0; i < runes.Length; i++)
        {
            if (runes[i] == "eff+")
            {
                eff_bonus += effect;
                dif_bonus += 5;
                mp_bonus += 2;
            }
            if (runes[i] == "cd-")
            {
                cd_bonus += 0.1f;
                dif_bonus += 5;
                mp_bonus += 1;
            }
            if (runes[i] == "di-")
            {
                dif_bonus -= 5;
            }
            if (runes[i] == "mp-")
            {
                mp_bonus -= 3f;
            }
        }
        effect_total = (effect * (float)level) + eff_bonus;

        diff_total = (int)difficult + (int)dif_bonus;
        if (diff_total < difficult) { diff_total = difficult; }

        cooldown_total = cooldown - cd_bonus;
        if(cooldown < 0) {cooldown= 0;}

        manacost_total = manacost + mp_bonus;
        if (manacost_total < manacost) { manacost_total = manacost; }

    }

    void Blessing()
    {
        name = "Blessing";
        type = "autocast";
        effect = 0.05f;
        difficult = 15;
        cooldown = 5;
        manacost = 7;
        time = 5f;


        float eff_bonus = 0;
        float dif_bonus = 0;
        float cd_bonus = 0;
        float mp_bonus = 0;
        float ti_bonus = 0;
        for (int i = 0; i < runes.Length; i++)
        {
            if (runes[i] == "eff+")
            {
                eff_bonus += effect;
                dif_bonus += 5;
                mp_bonus += 2;
            }
            if (runes[i] == "cd-")
            {
                cd_bonus += 0.1f;
                dif_bonus += 5;
                mp_bonus += 1;
            }
            if (runes[i] == "di-")
            {
                dif_bonus -= 5;
            }
            if (runes[i] == "mp-")
            {
                mp_bonus -= 3f;
            }
            if (runes[i] == "ti+")
            {
                ti_bonus += 5f;
            }
        }
        time_total = time + ti_bonus;
        effect_total = (effect * (float)level) + eff_bonus;

        diff_total = (int)difficult + (int)dif_bonus;
        if (diff_total < difficult) { diff_total = difficult; }

        cooldown_total = cooldown - cd_bonus;
        if (cooldown < 0) { cooldown = 0; }

        manacost_total = manacost + mp_bonus;
        if (manacost_total < manacost) { manacost_total = manacost; }
    }



    void Rage()
    {
        name = "Rage";
        type = "pasoffence";
        effect = 0.01f;
        difficult = 5;
        time = 3f;

        float eff_bonus = 0;
        float dif_bonus = 0;
        float ti_bonus = 0;
        for (int i = 0; i < runes.Length; i++)
        {
            if (runes[i] == "eff+")
            {
                eff_bonus += effect;
                dif_bonus += 5;
            }
            if (runes[i] == "di-")
            {
                dif_bonus -= 5;
            }
            if (runes[i] == "ti+")
            {
                ti_bonus += 5f;
            }
        }
        time_total = time + ti_bonus;
        effect_total = (effect * (float)level) + eff_bonus;

        diff_total = (int)difficult + (int)dif_bonus;
        if (diff_total < difficult) { diff_total = difficult; }
    }

  





}
