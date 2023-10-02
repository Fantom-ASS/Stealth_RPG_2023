using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Abilities_Data : MonoBehaviour
{
    public string skillDefpas;
    public string skillOffpas;
    public string[] skillFree = new string[2];
    public string[] skillPerk = new string[26];
    public string[] skillStd = new string[3];

    // public string skillLow;
    // public string skillMid;
    // public string skillHigh;
    public string skillUlt;

    public string[] runesdef = new string[5];
    public string[] runesoff = new string[5];
    public string[] runesfree1 = new string[5];
    public string[] runesfree2 = new string[5];

    public string[] runesstd1 = new string[5];
    public string[] runesstd2 = new string[5];
    public string[] runesstd3 = new string[5];
    public string[] runesult = new string[5];

    public string typedef;
    public string typeoff;
    public string[] typefree = new string[2];
    public string[] typestd = new string[3];
    public string typeult;

    //  public string typelow;
    //  public string typemid;
    //  public string typehigh;


    public int lvl_def;
    public int lvl_off;
    public int[] lvl_free = new int[2];
    public int[] lvl_std = new int[3];
    public int lvl_ult;

    //  public int lvl_low;
    //  public int lvl_mid;
    //  public int lvl_high;


    public float[] std_basecd = new float[3];
    public float[] std_totalcd = new float[3];
    public float[] free_basecd = new float[2];
    public float[] free_totalcd = new float[2];

    
    public float off_basecd;
    public float off_totalcd;
    public float def_basecd;
    public float def_totalcd;
    public float ult_basecd;
    public float ult_totalcd;


    public float reload_def;
    public float reload_off;
    public float reload_ult;
    public float[] reload_std = new float[3];
    public float[] reload_free = new float[2];
    // public float reload_low;
    // public float reload_mid;
    // public float reload_high;

    public float def_effbase;
    public float def_efftotal;
    public int def_tgtbase;
    public int def_tgttotal;
    public float def_aoebase;
    public float def_aoetotal;
    public float def_timebase;
    public float def_timetotal;
    public float def_difbase;
    public float def_diftotal;

    public float off_effbase;
    public float off_efftotal;
    public int off_tgtbase;
    public int off_tgttotal;
    public float off_aoebase;
    public float off_aoetotal;
    public float off_timebase;
    public float off_timetotal;
    public float off_difbase;
    public float off_diftotal;

    public float[] free_effbase = new float[2];
    public float[] free_efftotal = new float[2];
    public int[] free_tgtbase = new int[2];
    public int[] free_tgttotal = new int[2];
    public float[] free_aoebase = new float[2];
    public float[] free_aoetotal = new float[2];
    public float[] free_timebase = new float[2];
    public float[] free_timetotal = new float[2];
    public float[] free_spbase = new float[2];
    public float[] free_sptotal = new float[2];
    public float[] free_difbase = new float[2];
    public float[] free_diftotal = new float[2];

    public float[] std_effbase = new float[3];
    public float[] std_efftotal = new float[3];
    public int[] std_tgtbase = new int[3];
    public int[] std_tgttotal = new int[3];
    public float[] std_aoebase = new float[3];
    public float[] std_aoetotal = new float[3];
    public float[] std_timebase = new float[3];
    public float[] std_timetotal = new float[3];
    public float[] std_spbase = new float[3];
    public float[] std_sptotal = new float[3];
    public float[] std_mpbase = new float[3];
    public float[] std_mptotal = new float[3];
    public int[] std_difbase = new int[3];
    public int[] std_diftotal = new int[3];
    public float[] std_cdbase = new float[3];
    public float[] std_cdtotal = new float[3];

    public float ult_effbase;
    public float ult_efftotal;
    public float ult_tgtbase;
    public float ult_tgttotal;
    public float ult_aoebase;
    public float ult_aoetotal;
    public float ult_timebase;
    public float ult_timetotal;
    public float ult_spbase;
    public float ult_sptotal;
    public float ult_mpbase;
    public float ult_mptotal;
    public float ult_difbase;
    public float ult_diftotal;

    //runelist: ch+ ch++ ch+++ cd- cd-- cd--- mp- mp-- mp--- sp+ sp++ sp+++ eff+ eff++ eff+++ ti+ ti++ ti+++ ae+ ae++ ae+++ di- di-- di---
    //skilllist: defpas offpas auto_cast target point aoe channel aoetime wave around around_time perk attack auto_attack self

    // Start is called before the first frame update
    void Start()
    {
        //std_diftotal[0] = 4;
       // Debug.Log(std_difbase[0]);
        //Debug.Log(std_diftotal[0]);
    }

    // Update is called once per frame
    void Update()
    {
        for (int a = 0; a < 3; a++)
        {
            if (reload_std[a] > 0) { reload_std[a] -= Time.deltaTime; }
            if (reload_std[a] < 0) { reload_std[a] = 0; }
        }
        if (reload_ult > 0) { reload_ult -= Time.deltaTime; }
        if (reload_ult < 0) { reload_ult = 0; }
        if (reload_def > 0) { reload_def -= Time.deltaTime; }
        if (reload_def < 0) { reload_def = 0; }
        if (reload_off > 0) { reload_off -= Time.deltaTime; }
        if (reload_off < 0) { reload_off = 0; }


        //Free attacks/ñasts
        //Gives bonus damage on attack
        for (int u = 0; u < 2; u++)
        {
            if (skillFree[u] == "StrongStrike")
            {
                typefree[u] = "attack";
                free_effbase[u] = 0.02f;
                float eff_bonus = 0;
                if (u == 0)
                {
                    for (int i = 0; i < runesfree1.Length; i++)
                    { if (runesfree1[i] == "eff+") { eff_bonus += free_effbase[u]; } }
                }
                if (u == 1)
                {
                    for (int i = 0; i < runesfree2.Length; i++)
                    { if (runesfree2[i] == "eff+") { eff_bonus += free_effbase[u]; } }
                }
                free_efftotal[u] = (free_effbase[u] * lvl_free[u]) + eff_bonus;
            }
            //Two attacks instead of one with attack and ias bonus
            if (skillFree[u] == "DoubleSwing")
            {
                typefree[u] = "attack";
                free_effbase[u] = 0.02f;
                float eff_bonus = 0;
                if (u == 0)
                {
                    for (int i = 0; i < runesfree1.Length; i++)
                    { if (runesfree1[i] == "eff+") { eff_bonus += free_effbase[u]; } }
                }
                if (u == 1)
                {
                    for (int i = 0; i < runesfree2.Length; i++)
                    { if (runesfree2[i] == "eff+") { eff_bonus += free_effbase[u]; } }
                }
                free_efftotal[u] = (free_effbase[u] * lvl_free[u]) + eff_bonus;
            }
            //Gives bonus defence, block and evade on attack
            if (skillFree[u] == "Concentration")
            {
                typefree[u] = "attack";
                free_effbase[u] = 0.02f;
                float eff_bonus = 0;
                if (u == 0)
                {
                    for (int i = 0; i < runesfree1.Length; i++)
                    { if (runesfree1[i] == "eff+") { eff_bonus += free_effbase[u]; } }
                }
                if (u == 1)
                {
                    for (int i = 0; i < runesfree2.Length; i++)
                    { if (runesfree2[i] == "eff+") { eff_bonus += free_effbase[u]; } }
                }
                free_efftotal[u] = (free_effbase[u] * lvl_free[u]) + eff_bonus;
            }
            //Ignores armor and gives ability po pierce through multiple enemies when using range weapons except potions
            if (skillFree[u] == "ArmorPiercing")
            {
                typefree[u] = "attack";
                free_effbase[u] = 0.01f;
                free_tgtbase[u] = 1;
                float eff_bonus = 0;
                int tgt_bonus = 0;
                if (u == 0)
                {
                    for (int i = 0; i < runesfree1.Length; i++)
                    {
                        if (runesfree1[i] == "eff+") { eff_bonus += free_effbase[u]; }
                        if (runesfree1[i] == "tgt+") { tgt_bonus += 1; }
                    }
                }
                if (u == 1)
                {
                    for (int i = 0; i < runesfree2.Length; i++)
                    {
                        if (runesfree2[i] == "eff+") { eff_bonus += free_effbase[u]; }
                        if (runesfree2[i] == "tgt+") { tgt_bonus += 1; }
                    }
                }
                free_efftotal[u] = (free_effbase[u] * lvl_free[u]) + eff_bonus;
                free_tgttotal[u] = (free_tgtbase[u] * lvl_free[u]) + tgt_bonus;
            }
            //Missiles ricochet enemies when using throwing knives, axes and potions
            if (skillFree[u] == "Ricochet")
            {
                typefree[u] = "attack";
                free_effbase[u] = 0.01f;
                free_tgtbase[u] = 1;
                free_basecd[u] = 6f;
                float eff_bonus = 0;
                int tgt_bonus = 0;
                if (u == 0)
                {
                    for (int i = 0; i < runesfree1.Length; i++)
                    {
                        if (runesfree1[i] == "eff+") { eff_bonus += free_effbase[u]; }
                        if (runesfree1[i] == "tgt+") { tgt_bonus += 1; }
                    }
                }
                if (u == 1)
                {
                    for (int i = 0; i < runesfree2.Length; i++)
                    {
                        if (runesfree2[i] == "eff+") { eff_bonus += free_effbase[u]; }
                        if (runesfree2[i] == "tgt+") { tgt_bonus += 1; }
                    }
                }
                free_efftotal[u] = (free_effbase[u] * lvl_free[u]) + eff_bonus;
                free_tgttotal[u] = (free_tgtbase[u] * lvl_free[u]) + tgt_bonus;
            }
            //Throwing two missiles each in hand when using throwing weapons
            if (skillFree[u] == "DoubleThrow")
            {
                typefree[u] = "attack";
                free_effbase[u] = 0.01f;
                free_tgtbase[u] = 1;
                free_basecd[u] = 6f;
                float eff_bonus = 0;
                int tgt_bonus = 0;
                if (u == 0)
                {
                    for (int i = 0; i < runesfree1.Length; i++)
                    {
                        if (runesfree1[i] == "eff+") { eff_bonus += free_effbase[u]; }
                        if (runesfree1[i] == "tgt+") { tgt_bonus += 1; }
                    }
                }
                if (u == 1)
                {
                    for (int i = 0; i < runesfree2.Length; i++)
                    {
                        if (runesfree2[i] == "eff+") { eff_bonus += free_effbase[u]; }
                        if (runesfree2[i] == "tgt+") { tgt_bonus += 1; }
                    }
                }
                free_efftotal[u] = (free_effbase[u] * lvl_free[u]) + eff_bonus;
                free_tgttotal[u] = (free_tgtbase[u] * lvl_free[u]) + tgt_bonus;
            }
            //Every next shot to same target increases attack
            if (skillFree[u] == "Tracking")
            {
                typefree[u] = "attack";
                free_effbase[u] = 0.02f;
                float eff_bonus = 0;
                if (u == 0)
                {
                    for (int i = 0; i < runesfree1.Length; i++)
                    { if (runesfree1[i] == "eff+") { eff_bonus += free_effbase[u]; } }
                }
                if (u == 1)
                {
                    for (int i = 0; i < runesfree2.Length; i++)
                    { if (runesfree2[i] == "eff+") { eff_bonus += free_effbase[u]; } }
                }
                free_efftotal[u] = (free_effbase[u] * lvl_free[u]) + eff_bonus;
            }
            //Casts a missile that flies deals fire damage to enemy
            if (skillFree[u] == "FireBolt")
            {
                typefree[u] = "attack";
                free_effbase[u] = 0.02f;
                float eff_bonus = 0;
                if (u == 0)
                {
                    for (int i = 0; i < runesfree1.Length; i++)
                    { if (runesfree1[i] == "eff+") { eff_bonus += free_effbase[u]; } }
                }
                if (u == 1)
                {
                    for (int i = 0; i < runesfree2.Length; i++)
                    { if (runesfree2[i] == "eff+") { eff_bonus += free_effbase[u]; } }
                }
                free_efftotal[u] = (free_effbase[u] * lvl_free[u]) + eff_bonus;
            }
            //creates a missile that damages enemy with storm
            if (skillFree[u] == "Vortex")
            {
                typefree[u] = "attack";
                free_effbase[u] = 0.02f;
                float eff_bonus = 0;
                if (u == 0)
                {
                    for (int i = 0; i < runesfree1.Length; i++)
                    { if (runesfree1[i] == "eff+") { eff_bonus += free_effbase[u]; } }
                }
                if (u == 1)
                {
                    for (int i = 0; i < runesfree2.Length; i++)
                    { if (runesfree2[i] == "eff+") { eff_bonus += free_effbase[u]; } }
                }
                free_efftotal[u] = (free_effbase[u] * lvl_free[u]) + eff_bonus;
            }
            //roots appear from the ground damaging enemy
            if (skillFree[u] == "TreeRoots")
            {
                typefree[u] = "attack";
                free_effbase[u] = 0.02f;
                float eff_bonus = 0;
                if (u == 0)
                {
                    for (int i = 0; i < runesfree1.Length; i++)
                    { if (runesfree1[i] == "eff+") { eff_bonus += free_effbase[u]; } }
                }
                if (u == 1)
                {
                    for (int i = 0; i < runesfree2.Length; i++)
                    { if (runesfree2[i] == "eff+") { eff_bonus += free_effbase[u]; } }
                }
                free_efftotal[u] = (free_effbase[u] * lvl_free[u]) + eff_bonus;
            }
            //a stone missile damages and stuns enemy
            if (skillFree[u] == "StoneFist")
            {
                typefree[u] = "attack";
                free_tgtbase[u] = 1;
                free_effbase[u] = 0.02f;
                float eff_bonus = 0;
                float time_bonus = 0;
                if (u == 0)
                {
                    for (int i = 0; i < runesfree1.Length; i++)
                    {
                        if (runesfree1[i] == "eff+") { eff_bonus += free_effbase[u]; }
                        if (runesfree1[i] == "tgt+") { time_bonus += free_timebase[u]; }
                    }
                }
                if (u == 1)
                {
                    for (int i = 0; i < runesfree2.Length; i++)
                    {
                        if (runesfree2[i] == "eff+") { eff_bonus += free_effbase[u]; }
                        if (runesfree2[i] == "tgt+") { time_bonus += free_timebase[u]; }
                    }
                }
                free_efftotal[u] = (free_effbase[u] * lvl_free[u]) + eff_bonus;
            }
            //magic attack with fire damage, also sets the target on fire
            if (skillFree[u] == "Flamebolt")
            {
                typefree[u] = "attack";
                free_tgtbase[u] = 1;
                free_effbase[u] = 0.02f;
                float eff_bonus = 0;
                float time_bonus = 0;
                if (u == 0)
                {
                    for (int i = 0; i < runesfree1.Length; i++)
                    {
                        if (runesfree1[i] == "eff+") { eff_bonus += free_effbase[u]; }
                        if (runesfree1[i] == "tgt+") { time_bonus += free_timebase[u]; }
                    }
                }
                if (u == 1)
                {
                    for (int i = 0; i < runesfree2.Length; i++)
                    {
                        if (runesfree2[i] == "eff+") { eff_bonus += free_effbase[u]; }
                        if (runesfree2[i] == "tgt+") { time_bonus += free_timebase[u]; }
                    }
                }
                free_efftotal[u] = (free_effbase[u] * lvl_free[u]) + eff_bonus;
            }
            //magic attack that deals fire and storm damage
            if (skillFree[u] == "AcidClot")
            {
                typefree[u] = "attack";
                free_tgtbase[u] = 1;
                free_effbase[u] = 0.02f;
                float eff_bonus = 0;
                float time_bonus = 0;
                if (u == 0)
                {
                    for (int i = 0; i < runesfree1.Length; i++)
                    {
                        if (runesfree1[i] == "eff+") { eff_bonus += free_effbase[u]; }
                        if (runesfree1[i] == "tgt+") { time_bonus += free_timebase[u]; }
                    }
                }
                if (u == 1)
                {
                    for (int i = 0; i < runesfree2.Length; i++)
                    {
                        if (runesfree2[i] == "eff+") { eff_bonus += free_effbase[u]; }
                        if (runesfree2[i] == "tgt+") { time_bonus += free_timebase[u]; }
                    }
                }
                free_efftotal[u] = (free_effbase[u] * lvl_free[u]) + eff_bonus;
            }
            //magic attack that damages with storm and earth and slows enemy
            if (skillFree[u] == "Gush")
            {
                typefree[u] = "attack";
                free_tgtbase[u] = 1;
                free_effbase[u] = 0.02f;
                float eff_bonus = 0;
                float time_bonus = 0;
                if (u == 0)
                {
                    for (int i = 0; i < runesfree1.Length; i++)
                    {
                        if (runesfree1[i] == "eff+") { eff_bonus += free_effbase[u]; }
                        if (runesfree1[i] == "tgt+") { time_bonus += free_timebase[u]; }
                    }
                }
                if (u == 1)
                {
                    for (int i = 0; i < runesfree2.Length; i++)
                    {
                        if (runesfree2[i] == "eff+") { eff_bonus += free_effbase[u]; }
                        if (runesfree2[i] == "tgt+") { time_bonus += free_timebase[u]; }
                    }
                }
                free_efftotal[u] = (free_effbase[u] * lvl_free[u]) + eff_bonus;
            }
            //magic attack that damages with storm and earth and freezes enemy
            if (skillFree[u] == "IceSpike")
            {
                typefree[u] = "attack";
                free_tgtbase[u] = 1;
                free_effbase[u] = 0.02f;
                float eff_bonus = 0;
                float time_bonus = 0;
                if (u == 0)
                {
                    for (int i = 0; i < runesfree1.Length; i++)
                    {
                        if (runesfree1[i] == "eff+") { eff_bonus += free_effbase[u]; }
                        if (runesfree1[i] == "tgt+") { time_bonus += free_timebase[u]; }
                    }
                }
                if (u == 1)
                {
                    for (int i = 0; i < runesfree2.Length; i++)
                    {
                        if (runesfree2[i] == "eff+") { eff_bonus += free_effbase[u]; }
                        if (runesfree2[i] == "tgt+") { time_bonus += free_timebase[u]; }
                    }
                }
                free_efftotal[u] = (free_effbase[u] * lvl_free[u]) + eff_bonus;
                free_timetotal[u] = (free_timebase[u] * lvl_free[u]) + time_bonus;
            }
            //magic attack that ricochets from enemy to enemy
            if (skillFree[u] == "Pulsar")
            {
                typefree[u] = "attack";
                free_tgtbase[u] = 1;
                free_effbase[u] = 0.02f;
                float eff_bonus = 0;
                int tgt_bonus = 0;
                if (u == 0)
                {
                    for (int i = 0; i < runesfree1.Length; i++)
                    {
                        if (runesfree1[i] == "eff+") { eff_bonus += free_effbase[u]; }
                        if (runesfree1[i] == "tgt+") { tgt_bonus += 1; }
                    }
                }
                if (u == 1)
                {
                    for (int i = 0; i < runesfree2.Length; i++)
                    {
                        if (runesfree2[i] == "eff+") { eff_bonus += free_effbase[u]; }
                        if (runesfree2[i] == "tgt+") { tgt_bonus += 1; }
                    }
                }
                free_efftotal[u] = (free_effbase[u] * lvl_free[u]) + eff_bonus;
                free_tgttotal[u] = (free_tgtbase[u] * lvl_free[u]) + tgt_bonus;
            }
            //magic attack that damages with storm and fire multiple enemies on its way
            if (skillFree[u] == "Lighting")
            {
                typefree[u] = "attack";
                free_tgtbase[u] = 1;
                free_effbase[u] = 0.02f;
                float eff_bonus = 0;
                int tgt_bonus = 0;
                if (u == 0)
                {
                    for (int i = 0; i < runesfree1.Length; i++)
                    {
                        if (runesfree1[i] == "eff+") { eff_bonus += free_effbase[u]; }
                        if (runesfree1[i] == "tgt+") { tgt_bonus += 1; }
                    }
                }
                if (u == 1)
                {
                    for (int i = 0; i < runesfree2.Length; i++)
                    {
                        if (runesfree2[i] == "eff+") { eff_bonus += free_effbase[u]; }
                        if (runesfree2[i] == "tgt+") { tgt_bonus += 1; }
                    }
                }
                free_efftotal[u] = (free_effbase[u] * lvl_free[u]) + eff_bonus;
                free_tgttotal[u] = (free_tgtbase[u] * lvl_free[u]) + tgt_bonus;
            }
            //magic flow of positive energy that heals alive allies and damages undead enemies
            if (skillFree[u] == "HolyLight")
            {
                typefree[u] = "damage/heal";
                free_tgtbase[u] = 1;
                free_effbase[u] = 0.02f;
                float eff_bonus = 0;
                if (u == 0)
                {
                    for (int i = 0; i < runesfree1.Length; i++)
                    { if (runesfree1[i] == "eff+") { eff_bonus += free_effbase[u]; } }
                }
                if (u == 1)
                {
                    for (int i = 0; i < runesfree2.Length; i++)
                    { if (runesfree2[i] == "eff+") { eff_bonus += free_effbase[u]; } }
                }
                free_efftotal[u] = (free_effbase[u] * lvl_free[u]) + eff_bonus;
            }
            //magic flow of negative energy that heals dead allies and damages alive enemies
            if (skillFree[u] == "DeathCoil")
            {
                typefree[u] = "damage/heal";
                free_tgtbase[u] = 1;
                free_effbase[u] = 0.02f;
                float eff_bonus = 0;
                if (u == 0)
                {
                    for (int i = 0; i < runesfree1.Length; i++)
                    { if (runesfree1[i] == "eff+") { eff_bonus += free_effbase[u]; } }
                }
                if (u == 1)
                {
                    for (int i = 0; i < runesfree2.Length; i++)
                    { if (runesfree2[i] == "eff+") { eff_bonus += free_effbase[u]; } }
                }
                free_efftotal[u] = (free_effbase[u] * lvl_free[u]) + eff_bonus;
            }
        }

        //List of perks
        for (int v = 0; v < 26; v++)
        {
            //bonus attack for all melee weapons
            if (skillPerk[v] == "WeaponMastery")
            {
                typeoff = "perk";
                float eff_bonus = 0;
            }
            //Increases faster block rate and hit recovery
            if (skillPerk[v] == "Stockiness")
            {
                typeoff = "perk";
                float eff_bonus = 10f;
            }
            //Permanent bonus to maximum health and regen
            if (skillPerk[v] == "Healthful")
            {
                typedef = "perk";
                float eff_bonus = 0;
            }
            //Permanent bonus for chance to evade attack
            if (skillPerk[v] == "Evasion")
            {
                typedef = "perk";
                float eff_bonus = 0;
            }
            //Permanent bonus to block chance and speed of blocking
            if (skillPerk[v] == "ShieldMastery")
            {
                typedef = "perk";
                float eff_bonus = 10f;
            }
            //Increases attack and damage when using slicing weapons
            if (skillPerk[v] == "SlashMastery")
            {
                typedef = "perk";
                float eff_bonus = 0;
            }
            //Increases attack and damage when using blunding weapons
            if (skillPerk[v] == "BlundMastery")
            {
                typedef = "perk";
                float eff_bonus = 0;
            }
            //Increases crit damage when using blunding weapons
            if (skillPerk[v] == "SkullCrusher")
            {
                typedef = "perk";
                float eff_bonus = 0;
            }
            //Stunning enemy on crit when using blunding weapons
            if (skillPerk[v] == "Stun")
            {
                typedef = "perk";
                float eff_bonus = 0;
            }
            //Increases attack and damage when using piercing weapons
            if (skillPerk[v] == "PierceMastery")
            {
                typedef = "perk";
                float eff_bonus = 0;
            }
            //Ability to penerate enemies hitting several of them when using piercing weapons
            if (skillPerk[v] == "Penetrate")
            {
                typedef = "perk";
                float eff_bonus = 0;
            }
            //Increase attack distance when using piercing weapons
            if (skillPerk[v] == "Distance")
            {
                typedef = "perk";
                float eff_bonus = 0;
            }
            //Increase crit damage chance when using piercing weapons
            if (skillPerk[v] == "DeadlyStrike")
            {
                typedef = "perk";
                float eff_bonus = 0;
            }
            //Permanent bonus to attack and damage for range attacks
            if (skillPerk[v] == "Marksmanship")
            {
                typedef = "perk";
                float eff_bonus = 0;
            }
            //Standing on same place increases attack
            if (skillPerk[v] == "Sighting")
            {
                typedef = "perk";
                float eff_bonus = 0;
            }
            //Permanent bonus to secrecy at night or dungeons
            if (skillPerk[v] == "Shadowmeld")
            {
                typedef = "perk";
                float eff_bonus = 0;
            }
            //Increases ability to see stealth enemies
            if (skillPerk[v] == "Vision")
            {
                typedef = "perk";
                float eff_bonus = 0;
            }
            //Increases ability to hack locked chests
            if (skillPerk[v] == "Hack")
            {
                typedef = "perk";
                float eff_bonus = 0;
            }
            //Increases ability to steal items
            if (skillPerk[v] == "Steal")
            {
                typedef = "perk";
                float eff_bonus = 0;
            }
            //Increases ability to disarm traps
            if (skillPerk[v] == "Disarm")
            {
                typedef = "perk";
                float eff_bonus = 0;
            }
            //Increases ability to see trap effective area
            if (skillPerk[v] == "TrapArea")
            {
                typedef = "perk";
                float eff_bonus = 0;
            }
            //Increases accuracy and damage when using potion weapons
            if (skillPerk[v] == "PotionMastery")
            {
                typedef = "perk";
                float eff_bonus = 0;
            }
            //Increases backstab damage
            if (skillPerk[v] == "Sudden")
            {
                typedef = "perk";
                float eff_bonus = 0;
            }
            //Increases chance to crit at backstab
            if (skillPerk[v] == "WeakPoint")
            {
                typedef = "perk";
                float eff_bonus = 0;
            }
            //Decrease noise during killing
            if (skillPerk[v] == "SilentKill")
            {
                typedef = "perk";
                float eff_bonus = 0;
            }
            //increases mana regeneration at night
            if (skillPerk[v] == "NighMage")
            {
                typeoff = "perk";
                float eff_bonus = 0;
            }
            //increases ability of target to see enemy traps, ambushs, etc
            if (skillPerk[v] == "EagleEye")
            {
                typeoff = "perk";
                float eff_bonus = 0;
            }
        }















        //Offpas
        //lifeleech on attack
        if (skillOffpas == "BattleLust")
        {
            typeoff = "offpas";
            off_effbase = 0.02f;
            float eff_bonus = 0;
            for (int i = 0; i < runesoff.Length; i++)
            { if (runesoff[i] == "eff+") { eff_bonus += off_effbase; } }
            off_efftotal = (off_effbase * (float)lvl_off) + eff_bonus;
        }
        //ignoring part of defence on attack
        if (skillOffpas == "DefenceIgnore")
        {
            typeoff = "offpas";
            off_effbase = 0.02f;
            float eff_bonus = 0;
            for (int i = 0; i < runesoff.Length; i++)
            { if (runesoff[i] == "eff+") { eff_bonus += off_effbase; } }
            off_efftotal = (off_effbase * (float)lvl_off) + eff_bonus;
        }
        //bonus ias and damage for every missing % of life
        if (skillOffpas == "Rage")
        {
            typeoff = "offpas";
            off_effbase = 0.01f;
            off_tgtbase = 1;
            float eff_bonus = 0;
            int tgt_bonus = 0;
            for (int i = 0; i < runesoff.Length; i++)
            {
                if (runesoff[i] == "eff+") { eff_bonus += off_effbase; }
                if (runesoff[i] == "tgt+") { eff_bonus += off_tgtbase; }
            }
            off_efftotal = (off_effbase * (float)lvl_off) + eff_bonus;
            off_tgttotal = (off_tgtbase * lvl_off) + tgt_bonus;
        }
        //Passive splash damage bonus for slicing weapons
        if (skillOffpas == "SlicingAttack")
        {
            typeoff = "offpas";
            off_effbase = 0.01f;
            off_aoebase = 1f;
            float eff_bonus = 0;
            float aoe_bonus = 0;
            for (int i = 0; i < runesoff.Length; i++)
            {
                if (runesoff[i] == "eff+") { eff_bonus += off_effbase; }
            }
            off_efftotal = (off_effbase * (float)lvl_off) + eff_bonus;
            off_aoetotal = (off_aoebase * lvl_off) + aoe_bonus;
        }
        //Passive bleed damage bonus for slicing weapons
        if (skillOffpas == "OpenWounds")
        {
            typeoff = "offpas";
            off_effbase = 0.01f;
            off_timebase = 1f;
            float eff_bonus = 0;
            float time_bonus = 0;
            for (int i = 0; i < runesoff.Length; i++)
            {
                if (runesoff[i] == "eff+") { eff_bonus += off_effbase; }
            }
            off_efftotal = (off_effbase * (float)lvl_off) + eff_bonus;
            off_timetotal = (off_timebase * lvl_off) + time_bonus;
        }
        //Passive ignore of enemy armor
        if (skillOffpas == "SharpBlade")
        {
            typeoff = "offpas";
            off_effbase = 0.01f;
            float eff_bonus = 0;
            for (int i = 0; i < runesoff.Length; i++)
            {
                if (runesoff[i] == "eff+") { eff_bonus += off_effbase; }
            }
            off_efftotal = (off_effbase * (float)lvl_off) + eff_bonus;
        }
        //Bonus damage for every strike with cooldown when using blunding weapons
        if (skillOffpas == "RisingStrength")
        {
            typeoff = "offpas";
            off_effbase = 0.01f;
            off_basecd = 6f;
            float eff_bonus = 0;
            float cd_bonus = 0;
            for (int i = 0; i < runesoff.Length; i++)
            {
                if (runesoff[i] == "eff+") { eff_bonus += off_effbase; }
                if (runesoff[i] == "cd-") { cd_bonus -= 1; }
            }
            off_efftotal = (off_effbase * (float)lvl_off) + eff_bonus;
            off_totalcd = (off_basecd * lvl_off) + cd_bonus;
        }
        //Increases attack and movespeed at night or dungeons
        if (skillOffpas == "Nightstalker")
        {
            typeoff = "offpas";
            off_effbase = 0.01f;
            float eff_bonus = 0;
            for (int i = 0; i < runesoff.Length; i++)
            {
                if (runesoff[i] == "eff+") { eff_bonus += off_effbase; }
            }
            off_efftotal = (off_effbase * (float)lvl_off) + eff_bonus;
        }
        //Decreases attack rate of enemy when attacking him
        if (skillOffpas == "Nictophobia")
        {
            typeoff = "offpas";
            off_effbase = 0.01f;
            off_timebase = 1;
            off_basecd = 6f;
            float eff_bonus = 0;
            float time_bonus = 0;
            float cd_bonus = 0;
            for (int i = 0; i < runesoff.Length; i++)
            {
                if (runesoff[i] == "eff+") { eff_bonus += off_effbase; }
                if (runesoff[i] == "ti+") { time_bonus += off_timebase; }
                if (runesoff[i] == "cd-") { cd_bonus -= 1; }
            }
            off_efftotal = (off_effbase * (float)lvl_off) + eff_bonus;
            off_timetotal = (off_timebase * (float)lvl_off) + time_bonus;
            off_totalcd = (off_basecd * (float)lvl_off) + cd_bonus;
        }
        //Increases corpse secrecy after kill
        if (skillOffpas == "CorpseHiding")
        {
            typeoff = "offpas";
            off_effbase = 0.01f;
            off_timebase = 1;
            off_basecd = 6f;
            float eff_bonus = 0;
            float time_bonus = 0;
            float cd_bonus = 0;
            for (int i = 0; i < runesoff.Length; i++)
            {
                if (runesoff[i] == "eff+") { eff_bonus += off_effbase; }
                if (runesoff[i] == "ti+") { time_bonus += off_timebase; }
                if (runesoff[i] == "cd-") { cd_bonus -= 1; }
            }
            off_efftotal = (off_effbase * (float)lvl_off) + eff_bonus;
            off_timetotal = (off_timebase * (float)lvl_off) + time_bonus;
            off_totalcd = (off_basecd * (float)lvl_off) + cd_bonus;
        }
        //makes target burn
        if (skillOffpas == "Burn")
        {
            typeoff = "offpas";
            off_effbase = 0.02f;
            float eff_bonus = 0;
            for (int i = 0; i < runesoff.Length; i++)
            { if (runesoff[i] == "eff+") { eff_bonus += off_effbase; } }
            off_efftotal = (off_effbase * (float)lvl_off) + eff_bonus;
        }
        //chance to dispell buffs on attacked enemies, additional damage to summons
        if (skillOffpas == "Purification")
        {
            typeoff = "offpas";
            off_effbase = 0.02f;
            float eff_bonus = 0;
            for (int i = 0; i < runesoff.Length; i++)
            { if (runesoff[i] == "eff+") { eff_bonus += off_effbase; } }
            off_efftotal = (off_effbase * (float)lvl_off) + eff_bonus;
        }
        //standing on one place and taking damage increases your earth magic strength
        if (skillOffpas == "Awaiting")
        {
            typeoff = "offpas";
            off_effbase = 0.02f;
            float eff_bonus = 0;
            for (int i = 0; i < runesoff.Length; i++)
            { if (runesoff[i] == "eff+") { eff_bonus += off_effbase; } }
            off_efftotal = (off_effbase * (float)lvl_off) + eff_bonus;
        }
        //every successful acid attack reduces resists of target
        if (skillOffpas == "Oxidation")
        {
            typeoff = "offpas";
            off_effbase = 0.02f;
            float eff_bonus = 0;
            float time_bonus = 0;
            int tgt_bonus = 0;
            for (int i = 0; i < runesoff.Length; i++)
            {
                if (runesoff[i] == "eff+") { eff_bonus += off_effbase; }
                if (runesoff[i] == "eff+") { eff_bonus += off_effbase; }
            }
            off_efftotal = (off_effbase * (float)lvl_off) + eff_bonus;
            off_timetotal = (off_timebase * (float)lvl_off) + time_bonus;
            off_tgttotal = (off_tgtbase * lvl_off) + tgt_bonus;
        }
        //adds cold damage to attacks, increases freeze time
        if (skillOffpas == "ColdAttack")
        {
            typeoff = "offpas";
            off_effbase = 0.02f;
            float eff_bonus = 0;
            for (int i = 0; i < runesoff.Length; i++)
            { if (runesoff[i] == "eff+") { eff_bonus += off_effbase; } }
            off_efftotal = (off_effbase * (float)lvl_off) + eff_bonus;
        }
        //attacks deal additional damage to enemy by burning his mana
        if (skillOffpas == "Manaburn")
        {
            typeoff = "offpas";
            off_effbase = 1;
            float eff_bonus = 0;
            for (int i = 0; i < runesoff.Length; i++)
            {
                if (runesoff[i] == "eff+") { eff_bonus += off_effbase; }
            }
            off_efftotal = (off_effbase * (float)lvl_off) + eff_bonus;
        }
        //probability to make enemy flee after being hit
        if (skillOffpas == "Fear")
        {
            typeoff = "offpas";
            off_effbase = 1;
            off_timebase = 1;
            float eff_bonus = 0;
            float time_bonus = 0;
            for (int i = 0; i < runesoff.Length; i++)
            {
                if (runesoff[i] == "eff+") { eff_bonus += off_effbase; }
                if (runesoff[i] == "ti+") { time_bonus += off_timebase; }
            }
            off_efftotal = (off_effbase * (float)lvl_off) + eff_bonus;
            off_timetotal = (off_timebase * (float)lvl_off) + time_bonus;
        }
        //chance to decrease target life when it takes damage
        if (skillOffpas == "Hopeless")
        {
            typeoff = "offpas";
            off_effbase = 1;
            off_timebase = 1;
            float eff_bonus = 0;
            float time_bonus = 0;
            for (int i = 0; i < runesoff.Length; i++)
            {
                if (runesoff[i] == "eff+") { eff_bonus += off_effbase; }
                if (runesoff[i] == "ti+") { time_bonus += off_timebase; }
            }
            off_efftotal = (off_effbase * (float)lvl_off) + eff_bonus;
            off_timetotal = (off_timebase * (float)lvl_off) + time_bonus;
        }
        //Bonus damage when using range weapons except potions
        if (skillOffpas == "Jagged")
        {
            typeoff = "offpas";
            off_effbase = 0.01f;
            off_tgtbase = 1;
            float eff_bonus = 0;
            float time_bonus = 0;
            for (int i = 0; i < runesoff.Length; i++)
            {
                if (runesoff[i] == "eff+") { eff_bonus += off_effbase; }
                if (runesoff[i] == "ti+") { time_bonus += off_timebase; }
            }
            off_efftotal = (off_effbase * (float)lvl_off) + eff_bonus;
            off_timetotal = (off_timebase * (float)lvl_off) + time_bonus;
        }
        //Charge bonuses
        //Increases damage and attack when there are charges
        if (skillOffpas == "Might")
        {
            typeoff = "chbonus";
            off_effbase = 0.05f;
            int charged = 0;
            float eff_bonus = 0;
            for (int i = 0; i < runesoff.Length; i++)
            {
                if (runesoff[i] == "eff+") { eff_bonus += off_effbase; }
            }
            off_efftotal = ((off_effbase * (float)lvl_off) + eff_bonus) * (charged + 1);
        }
        //Increases attackspeed,castspeed and walkspeed when there are charges
        if (skillOffpas == "Speed")
        {
            typeoff = "chbonus";
            off_effbase = 0.05f;
            int charged = 0;
            float eff_bonus = 0;
            for (int i = 0; i < runesoff.Length; i++)
            {
                if (runesoff[i] == "eff+") { eff_bonus += off_effbase; }
            }
            off_efftotal = ((off_effbase * (float)lvl_off) + eff_bonus) * (charged + 1);
        }





        //Defpas
        //Temporary increases defence after successful evasion
        if (skillDefpas == "DefenciveMoves")
        {
            typedef = "defpas";
            def_effbase = 0.01f;
            def_tgtbase = 2;
            float eff_bonus = 0;
            int tgt_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            {
                if (runesdef[i] == "eff+") { eff_bonus += def_effbase; }
                if (runesdef[i] == "tgt+") { tgt_bonus += def_tgtbase; }
            }
            def_efftotal = (def_effbase * (float)lvl_def) + eff_bonus;
            def_efftotal = (def_tgtbase * lvl_def) + tgt_bonus + 4;
        }
        //Temporary increases maximum hp after being hit
        if (skillDefpas == "Unbreakable")
        {
            typedef = "defpas";
            def_effbase = 0.01f;
            def_tgtbase = 2;
            float eff_bonus = 0;
            int tgt_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            {
                if (runesdef[i] == "eff+") { eff_bonus += def_effbase; }
                if (runesdef[i] == "tgt+") { tgt_bonus += def_tgtbase; }
            }
            def_efftotal = (def_effbase * (float)lvl_def) + eff_bonus;
            def_efftotal = (def_tgtbase * lvl_def) + tgt_bonus + 4;
        }
        //Chance to hit immediately the attacker
        if (skillDefpas == "Counterattack")
        {
            typedef = "defpas";
            def_effbase = 0.01f;
            def_tgtbase = 2;
            float eff_bonus = 0;
            int tgt_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            {
                if (runesdef[i] == "eff+") { eff_bonus += def_effbase; }
                if (runesdef[i] == "tgt+") { tgt_bonus += def_tgtbase; }
            }
            def_efftotal = (def_effbase * (float)lvl_def) + eff_bonus;
            def_efftotal = (def_tgtbase * lvl_def) + tgt_bonus + 4;
        }
        //Using landscape objects to uncrease defence against ranged attacks when using range weapons
        if (skillDefpas == "Covering")
        {
            typedef = "defpas";
            def_effbase = 0.01f;
            def_tgtbase = 1;
            def_basecd = 6f;
            float eff_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            {
                if (runesoff[i] == "eff+") { eff_bonus += def_effbase; }
            }
            def_efftotal = (def_effbase * (float)lvl_def) + eff_bonus;
        }
        //Increase secrecy when doesn't move
        if (skillDefpas == "Stealth")
        {
            typeoff = "defpas";
            def_effbase = 0.01f;
            def_timebase = 1;
            def_basecd = 6f;
            float eff_bonus = 0;
            float time_bonus = 0;
            float cd_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            {
                if (runesdef[i] == "eff+") { eff_bonus += def_effbase; }
                if (runesdef[i] == "ti+") { time_bonus += def_timebase; }
                if (runesdef[i] == "cd-") { cd_bonus -= 1; }
            }
            def_efftotal = (def_effbase * (float)lvl_def) + eff_bonus;
            def_timetotal = (def_timebase * (float)lvl_def) + time_bonus;
            def_totalcd = (def_basecd * lvl_def) + cd_bonus;
        }
        //Increases secrecy and regeneration when life drops low
        if (skillDefpas == "Sanctuary")
        {
            typedef = "defpas";
            def_effbase = 0.01f;
            def_timebase = 1;
            def_basecd = 6f;
            float eff_bonus = 0;
            float time_bonus = 0;
            float cd_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            {
                if (runesdef[i] == "eff+") { eff_bonus += def_effbase; }
                if (runesdef[i] == "ti+") { time_bonus += def_timebase; }
                if (runesdef[i] == "cd-") { cd_bonus -= 1; }
            }
            def_efftotal = (def_effbase * (float)lvl_def) + eff_bonus;
            def_timetotal = (def_timebase * (float)lvl_def) + time_bonus;
            def_totalcd = (def_basecd * (float)lvl_def) + cd_bonus;
        }
        //increase mana regeneration for every abcent % of mana
        if (skillDefpas == "InnerWarmth")
        {
            typedef = "defpas";
            def_effbase = 0.02f;
            float eff_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            { if (runesdef[i] == "eff+") { eff_bonus += def_effbase; } }
            def_efftotal = (def_effbase * (float)lvl_def) + eff_bonus;
        }
        //increase movespeed, attackspeed and castspeed when moving
        if (skillDefpas == "Lightness")
        {
            typedef = "defpas";
            def_effbase = 0.02f;
            float eff_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            { if (runesdef[i] == "eff+") { eff_bonus += def_effbase; } }
            def_efftotal = (def_effbase * (float)lvl_def) + eff_bonus;
        }
        //chance to hit nearby attackers with lighting
        if (skillDefpas == "StaticField")
        {
            typedef = "defpas";
            def_effbase = 0.02f;
            float eff_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            { if (runesdef[i] == "eff+") { eff_bonus += def_effbase; } }
            def_efftotal = (def_effbase * (float)lvl_def) + eff_bonus;
        }
        //increasing armor and resists
        if (skillDefpas == "StoneSkin")
        {
            typedef = "defpas";
            def_effbase = 0.02f;
            float eff_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            { if (runesdef[i] == "eff+") { eff_bonus += def_effbase; } }
            def_efftotal = (def_effbase * (float)lvl_def) + eff_bonus;
        }
        //Increases defence at night or dungeons 
        if (skillDefpas == "Blur")
        {
            typedef = "defpas";
            def_effbase = 0.01f;
            float eff_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            {
                if (runesdef[i] == "eff+") { eff_bonus += def_effbase; }
            }
            def_efftotal = (def_effbase * (float)lvl_def) + eff_bonus;
        }
        //all enemies that use spell near hero take astral damage in size of % for spent mana
        if (skillDefpas == "MagicSuppressor")
        {
            typedef = "defpas";
            def_effbase = 1;
            float eff_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            {
                if (runesdef[i] == "eff+") { eff_bonus += def_effbase; }
            }
            def_efftotal = (def_effbase * (float)lvl_def) + eff_bonus;
        }
        //increases attack speed and cast rate of ally for any buff cast on it
        if (skillDefpas == "Inspire")
        {
            typedef = "defpas";
            def_effbase = 1;
            def_timebase = 1;
            float eff_bonus = 0;
            float time_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            {
                if (runesdef[i] == "eff+") { eff_bonus += def_effbase; }
                if (runesdef[i] == "ti+") { time_bonus += def_timebase; }
            }
            def_efftotal = (def_effbase * (float)lvl_def) + eff_bonus;
            def_timetotal = (def_timebase * (float)lvl_def) + time_bonus;
        }

        //Increases attack rate, speed and damage for allies
        if (skillDefpas == "Fanaticism")
        {
            typedef = "aura";
            def_effbase = 0.01f;
            def_timebase = 1;
            def_aoebase = 1;
            float eff_bonus = 0;
            float time_bonus = 0;
            float aoe_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            {
                if (runesdef[i] == "eff+") { eff_bonus += def_effbase; }
                if (runesdef[i] == "ti+") { time_bonus += def_timebase; }
                if (runesdef[i] == "aoe+") { aoe_bonus += def_timebase; }
            }
            def_efftotal = (def_effbase * (float)lvl_def) + eff_bonus;
            def_timetotal = (def_timebase * (float)lvl_def) + time_bonus;
            def_aoetotal = (def_aoebase * (float)lvl_def) + aoe_bonus;
        }
        //Increases maximum mana and mana regeneration for allies
        if (skillDefpas == "Nobility")
        {
            typedef = "aura";
            def_effbase = 0.01f;
            def_timebase = 1;
            def_aoebase = 1;
            float eff_bonus = 0;
            float time_bonus = 0;
            float aoe_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            {
                if (runesdef[i] == "eff+") { eff_bonus += def_effbase; }
                if (runesdef[i] == "ti+") { time_bonus += def_timebase; }
                if (runesdef[i] == "aoe+") { aoe_bonus += def_timebase; }
            }
            def_efftotal = (def_effbase * (float)lvl_def) + eff_bonus;
            def_timetotal = (def_timebase * (float)lvl_def) + time_bonus;
            def_aoetotal = (def_aoebase * (float)lvl_def) + aoe_bonus;
        }
        //Increases maximum health and health regeneration for allies
        if (skillDefpas == "Vitality")
        {
            typedef = "aura";
            def_effbase = 0.01f;
            def_timebase = 1;
            def_aoebase = 1;
            float eff_bonus = 0;
            float time_bonus = 0;
            float aoe_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            {
                if (runesdef[i] == "eff+") { eff_bonus += def_effbase; }
                if (runesdef[i] == "ti+") { time_bonus += def_timebase; }
                if (runesdef[i] == "aoe+") { aoe_bonus += def_timebase; }
            }
            def_efftotal = (def_effbase * (float)lvl_def) + eff_bonus;
            def_timetotal = (def_timebase * (float)lvl_def) + time_bonus;
            def_aoetotal = (def_aoebase * (float)lvl_def) + aoe_bonus;
        }
        //Increases defence and resists, decrease debuff time for allies
        if (skillDefpas == "Guard")
        {
            typedef = "aura";
            def_effbase = 0.01f;
            def_timebase = 1;
            def_aoebase = 1;
            float eff_bonus = 0;
            float time_bonus = 0;
            float aoe_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            {
                if (runesdef[i] == "eff+") { eff_bonus += def_effbase; }
                if (runesdef[i] == "ti+") { time_bonus += def_timebase; }
                if (runesdef[i] == "aoe+") { aoe_bonus += def_timebase; }
            }
            def_efftotal = (def_effbase * (float)lvl_def) + eff_bonus;
            def_timetotal = (def_timebase * (float)lvl_def) + time_bonus;
            def_aoetotal = (def_aoebase * (float)lvl_def) + aoe_bonus;
        }
        //Decrease attack rate, speed and damage for enemies
        if (skillDefpas == "Suppression")
        {
            typedef = "aura";
            def_effbase = 0.01f;
            def_timebase = 1;
            def_aoebase = 1;
            float eff_bonus = 0;
            float time_bonus = 0;
            float aoe_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            {
                if (runesdef[i] == "eff+") { eff_bonus += def_effbase; }
                if (runesdef[i] == "ti+") { time_bonus += def_timebase; }
                if (runesdef[i] == "aoe+") { aoe_bonus += def_timebase; }
            }
            def_efftotal = (def_effbase * (float)lvl_def) + eff_bonus;
            def_timetotal = (def_timebase * (float)lvl_def) + time_bonus;
            def_aoetotal = (def_aoebase * (float)lvl_def) + aoe_bonus;
        }
        //Reflect part of taken damage to enemies
        if (skillDefpas == "Reflect")
        {
            typedef = "aura";
            def_effbase = 0.01f;
            def_timebase = 1;
            def_aoebase = 1;
            float eff_bonus = 0;
            float time_bonus = 0;
            float aoe_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            {
                if (runesdef[i] == "eff+") { eff_bonus += def_effbase; }
                if (runesdef[i] == "ti+") { time_bonus += def_timebase; }
                if (runesdef[i] == "aoe+") { aoe_bonus += def_timebase; }
            }
            def_efftotal = (def_effbase * (float)lvl_def) + eff_bonus;
            def_timetotal = (def_timebase * (float)lvl_def) + time_bonus;
            def_aoetotal = (def_aoebase * (float)lvl_def) + aoe_bonus;
        }
        //Decrease current health for every abcent % of it to enemies
        if (skillDefpas == "Torture")
        {
            typedef = "aura";
            def_effbase = 0.01f;
            def_timebase = 1;
            def_aoebase = 1;
            float eff_bonus = 0;
            float time_bonus = 0;
            float aoe_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            {
                if (runesdef[i] == "eff+") { eff_bonus += def_effbase; }
                if (runesdef[i] == "ti+") { time_bonus += def_timebase; }
                if (runesdef[i] == "aoe+") { aoe_bonus += def_timebase; }
            }
            def_efftotal = (def_effbase * (float)lvl_def) + eff_bonus;
            def_timetotal = (def_timebase * (float)lvl_def) + time_bonus;
            def_aoetotal = (def_aoebase * (float)lvl_def) + aoe_bonus;
        }
        //Increase lifeleech for allies
        if (skillDefpas == "Vampirism")
        {
            typedef = "aura";
            def_effbase = 0.01f;
            def_timebase = 1;
            def_aoebase = 1;
            float eff_bonus = 0;
            float time_bonus = 0;
            float aoe_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            {
                if (runesdef[i] == "eff+") { eff_bonus += def_effbase; }
                if (runesdef[i] == "ti+") { time_bonus += def_timebase; }
                if (runesdef[i] == "aoe+") { aoe_bonus += def_timebase; }
            }
            def_efftotal = (def_effbase * (float)lvl_def) + eff_bonus;
            def_timetotal = (def_timebase * (float)lvl_def) + time_bonus;
            def_aoetotal = (def_aoebase * (float)lvl_def) + aoe_bonus;
        }
        //Chargebonuses
        //Return damage to enemies when there are charges
        if (skillDefpas == "Bramble")
        {
            typedef = "chbonus";
            def_effbase = 0.05f;
            int charged = 0;
            float eff_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            {
                if (runesdef[i] == "eff+") { eff_bonus += def_effbase; }
            }
            def_efftotal = ((def_effbase * (float)lvl_def) + eff_bonus) * (charged + 1);
        }
        //Increases defence, blockspeed and evadespeed when there are charges
        if (skillDefpas == "Reflexes")
        {
            typedef = "chbonus";
            def_effbase = 0.05f;
            int charged = 0;
            float eff_bonus = 0;
            for (int i = 0; i < runesdef.Length; i++)
            {
                if (runesdef[i] == "eff+") { eff_bonus += def_effbase; }
            }
            def_efftotal = ((def_effbase * (float)lvl_def) + eff_bonus) * (charged + 1);
        }









        for (int w = 0; w < 3; w++)
        {
            //Skills that don't require cooldown
            //Gives temporary bonus damage on attack for every successful attack
            if (skillStd[w] == "Insane")
            {
                typestd[w] = "auto_attack";
                std_effbase[w] = 0.03f;
                std_tgtbase[w] = 1;
                std_mpbase[w] = 2;
                float mp_bonus = 0;
                float eff_bonus = 0;
                int tgt_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += std_tgtbase[w]; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "tgt+") { tgt_bonus += std_tgtbase[w]; }
                        if (runesstd2[i] == "mp-") { mp_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "tgt+") { tgt_bonus += std_tgtbase[w]; }
                        if (runesstd3[i] == "mp-") { mp_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                if (std_mptotal[w] <= 1) { std_mptotal[w] = 1; }
            }
            //Gives bonus damage on attack in cost of life
            if (skillStd[w] == "Sacrifice")
            {
                typestd[w] = "auto_attack";
                std_effbase[w] = 0.04f;
                float eff_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
            }
            //Bonus ias for every successful attack
            if (skillStd[w] == "Fervor")
            {
                typestd[w] = "auto_attack";
                std_effbase[w] = 0.03f;
                std_tgtbase[w] = 1;
                std_mpbase[w] = 2;

                float mp_bonus = 0;
                float eff_bonus = 0;
                int tgt_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += std_tgtbase[w]; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "tgt+") { tgt_bonus += std_tgtbase[w]; }
                        if (runesstd2[i] == "mp-") { mp_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "tgt+") { tgt_bonus += std_tgtbase[w]; }
                        if (runesstd3[i] == "mp-") { mp_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                if (std_mptotal[w] <= 1) { std_mptotal[w] = 1; }
            }
            //Every successful hit decreases enemy attack and move speed
            if (skillStd[w] == "Exhaustion")
            {
                typestd[w] = "auto_attack";
                std_effbase[w] = 0.01f;
                std_tgtbase[w] = 2;
                std_timebase[w] = 1;
                std_mpbase[w] = 4;
                float eff_bonus = 0;
                float time_bonus = 0;
                int tgt_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += std_tgtbase[w]; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "tgt+") { tgt_bonus += std_tgtbase[w]; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "tgt+") { tgt_bonus += std_tgtbase[w]; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
            }
            //Hits enemies near target on attack dealing half damage
            if (skillStd[w] == "Harvest")
            {
                typestd[w] = "auto_attack";
                std_effbase[w] = 0.03f;
                std_aoebase[w] = 1;
                std_mpbase[w] = 2;

                float mp_bonus = 0;
                float aoe_bonus = 0;
                float eff_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus += std_tgtbase[w]; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus += std_tgtbase[w]; }
                        if (runesstd2[i] == "mp-") { mp_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus += std_tgtbase[w]; }
                        if (runesstd3[i] == "mp-") { mp_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                if (std_mptotal[w] <= 1) { std_mptotal[w] = 1; }
            }
            //Attack deals additional damage and hits enemy when using blunding weapons
            if (skillStd[w] == "Bash")
            {
                typestd[w] = "auto_attack";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_mpbase[w] = 4;
                float eff_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
            }
            //Attack deals additional damage, stun and knocks enemies back when using blunding weapons
            if (skillStd[w] == "Knockback")
            {
                typestd[w] = "auto_attack";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_timebase[w] = 0.1f;
                std_mpbase[w] = 4;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }

                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
            }
            //Fast attack with bonus attack speed and rate when using piercing weapons
            if (skillStd[w] == "Jab")
            {
                typestd[w] = "auto_attack";
                std_effbase[w] = 0.04f;
                std_mpbase[w] = 4;
                float eff_bonus = 0;
                float mp_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
            }
            //Shooting to possible future target position according to its speed and distance when using range weapons except potions
            if (skillStd[w] == "Precision")
            {
                typestd[w] = "auto_attack";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_mpbase[w] = 4;
                float eff_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
            }
            //Bonus attack and magic damage when using range weapons
            if (skillStd[w] == "MagicArrows")
            {
                typestd[w] = "auto_attack";
                std_effbase[w] = 0.04f;
                std_mpbase[w] = 4;
                float eff_bonus = 0;
                float mp_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
            }
            //Decreases enemy attack and movespeed on successful range attack
            if (skillStd[w] == "SlowingPoison")
            {
                typestd[w] = "auto_attack";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_mpbase[w] = 4;
                float eff_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
            }
            //creates multiple missiles that damages enemies with storm
            if (skillStd[w] == "Gust")
            {
                typestd[w] = "auto_attack";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 0.1f;
                std_mpbase[w] = 4;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }

                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
            }
            //every successful acid attack deals splash damage to nearby enemies
            if (skillStd[w] == "SplashDamage")
            {
                typestd[w] = "auto_attack";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_mpbase[w] = 4;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float mp_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }

                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
            }
            //magic attack that damages with storm and earth and freezes multiple enemies
            if (skillStd[w] == "IceFist")
            {
                typestd[w] = "auto_attack";
                std_effbase[w] = 0.01f;
                std_aoebase[w] = 2;
                std_mpbase[w] = 4;
                float eff_bonus = 0;
                float mp_bonus = 0;
                float aoe_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "tgt+") { aoe_bonus += std_aoebase[w]; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "tgt+") { aoe_bonus += std_aoebase[w]; }
                        if (runesstd2[i] == "mp-") { mp_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "tgt+") { aoe_bonus += std_aoebase[w]; }
                        if (runesstd3[i] == "mp-") { mp_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
            }
            //magic attack that damages with storm and fire multiple nearby enemies
            if (skillStd[w] == "ChainLighting")
            {
                typestd[w] = "auto_attack";
                std_effbase[w] = 0.01f;
                std_tgtbase[w] = 2;
                std_mpbase[w] = 4;
                float eff_bonus = 0;
                float mp_bonus = 0;
                int tgt_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += std_tgtbase[w]; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "tgt+") { tgt_bonus += std_tgtbase[w]; }
                        if (runesstd2[i] == "mp-") { mp_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "tgt+") { tgt_bonus += std_tgtbase[w]; }
                        if (runesstd3[i] == "mp-") { mp_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
            }
            //magic attack that breaks into pieces hitting multiple enemies
            if (skillStd[w] == "StarChipped")
            {
                typestd[w] = "auto_attack";
                std_effbase[w] = 0.01f;
                std_tgtbase[w] = 2;
                std_mpbase[w] = 4;
                float eff_bonus = 0;
                float mp_bonus = 0;
                int tgt_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += std_tgtbase[w]; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "tgt+") { tgt_bonus += std_tgtbase[w]; }
                        if (runesstd2[i] == "mp-") { mp_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "tgt+") { tgt_bonus += std_tgtbase[w]; }
                        if (runesstd3[i] == "mp-") { mp_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
            }
            //drains mana from enemy and gives it to ally
            if (skillStd[w] == "Manasteal")
            {
                typestd[w] = "channel";
                std_effbase[w] = 0.04f;
                std_mpbase[w] = 4;
                float eff_bonus = 0;
                float mp_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
            }
            //drains life from enemy and gives it to ally
            if (skillStd[w] == "Lifesteal")
            {
                typestd[w] = "channel";
                std_effbase[w] = 0.04f;
                std_mpbase[w] = 4;
                float eff_bonus = 0;
                float mp_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
            }
            //Increases regeneration of health when active
            if (skillStd[w] == "Meditation")
            {
                typestd[w] = "on/off";
                std_effbase[w] = 0.04f;
                std_mpbase[w] = 4;
                float eff_bonus = 0;
                float mp_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
            }
            //Gives bonus damage and attack speed when active
            if (skillStd[w] == "Power")
            {
                typestd[w] = "on/off";
                std_effbase[w] = 0.04f;
                std_mpbase[w] = 4;
                float eff_bonus = 0;
                float mp_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
            }
            //Returns damage to nearby enemies when active
            if (skillStd[w] == "BladeArmor")
            {
                typestd[w] = "on/off";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_mpbase[w] = 4;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float mp_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }

                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
            }
            //Decrease attack of nearby enemies when active
            if (skillStd[w] == "ShadowDancer")
            {
                typestd[w] = "on/off";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_mpbase[w] = 4;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float mp_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }

                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
            }
            //fire damage to all enemies around when active
            if (skillStd[w] == "Immolation")
            {
                typestd[w] = "on/off";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_mpbase[w] = 4;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float mp_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }

                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
            }
            //increases nearby allies secrecy when active
            if (skillStd[w] == "StealthCloak")
            {
                typestd[w] = "on/off";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_mpbase[w] = 4;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float mp_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }

                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "mp+") { mp_bonus += 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
            }

//remove brackets
        


            //Skills that require cooldown
            //Powerful strike that gives a big bonus to damage and attack
            if (skillStd[w] == "Fatality")
            {
                typestd[w] = "specattack";
                std_effbase[w] = 0.15f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "LeapAttack")
            {
                typestd[w] = "point";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "LeapCrush")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Ram")
            {
                typestd[w] = "point";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "SeriesAttack")
            {
                typestd[w] = "self";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "DeathDance")
            {
                typestd[w] = "around_time";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Block")
            {
                typestd[w] = "self";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Defence")
            {
                typestd[w] = "self";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Protection")
            {
                typestd[w] = "self";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Smite")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Reflect")
            {
                typestd[w] = "selfmod";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Knockout")
            {
                typestd[w] = "selfmod";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Revenge")
            {
                typestd[w] = "self";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Charge")
            {
                typestd[w] = "charger";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "TigerAttack")
            {
                typestd[w] = "discharge";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "SnakeBite")
            {
                typestd[w] = "discharge";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "VampireKiss")
            {
                typestd[w] = "discharge";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Undercut")
            {
                typestd[w] = "discharge";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Intercept")
            {
                typestd[w] = "discharge";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Petrify")
            {
                typestd[w] = "discharge";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "RoundStrike")
            {
                typestd[w] = "around";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Bladestorm")
            {
                typestd[w] = "around_time";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Greatercrush")
            {
                typestd[w] = "wave";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Spiking")
            {
                typestd[w] = "specattack";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Impale")
            {
                typestd[w] = "specattack";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Accelerated")
            {
                typestd[w] = "point";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Guided")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "SplitArrows")
            {
                typestd[w] = "point";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "ArrowRain")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "QuickThrow")
            {
                typestd[w] = "self";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "SlowingMissiles")
            {
                typestd[w] = "self";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "InnerSight")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Ambush")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "PlagueArrow")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Lurker")
            {
                typestd[w] = "self";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Backstab")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "EnemySight")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Echolot")
            {
                typestd[w] = "around";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Shadow")
            {
                typestd[w] = "point";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Hiding")
            {
                typestd[w] = "point";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Prediction")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Camouflage")
            {
                typestd[w] = "self";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "TwilightArea")
            {
                typestd[w] = "around";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "HealingPotion")
            {
                typestd[w] = "self";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "ManaPotion")
            {
                typestd[w] = "self";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "RejunevationPotion")
            {
                typestd[w] = "self";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "ExplodingPotion")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "PoisonousPotion")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "ParalizingPotion")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "ImpalingTrap")
            {
                typestd[w] = "point";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "SpikeTrap")
            {
                typestd[w] = "point";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "ShootingTrap")
            {
                typestd[w] = "point";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Fireblast")
            {
                typestd[w] = "point";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Fireball")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "FireRain")
            {
                typestd[w] = "aoe_time";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Pyrokninesis")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "FireWall")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "ScorchedEarth")
            {
                typestd[w] = "aoe_time";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Bloodlust")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "FireSpirits")
            {
                typestd[w] = "self";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Enchant")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "FireCarusel")
            {
                typestd[w] = "self";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Phoenix")
            {
                typestd[w] = "place";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Tornado")
            {
                typestd[w] = "wave";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Hurricane")
            {
                typestd[w] = "aoe_time";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Push")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Telekinesis")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Sandstorm")
            {
                typestd[w] = "around_time";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Haste")
            {
                typestd[w] = "self";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Levitation")
            {
                typestd[w] = "self";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Teleport")
            {
                typestd[w] = "self";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Dispell")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "CycloneArmor")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "ReflectMagic")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "TreeRage")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "PiercingRoots")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "ForestWrath")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Tremor")
            {
                typestd[w] = "around";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Shockwave")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Earthquake")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "ForestDefence")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "NatureHelp")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "StoneArmor")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "NatureWall")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Inquisition")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "LiguidFire")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Meteor")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Hydra")
            {
                typestd[w] = "point";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Infernal")
            {
                typestd[w] = "point";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Fructure")
            {
                typestd[w] = "aoe_time";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "BreathOfDeath")
            {
                typestd[w] = "wave";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "AcidFountain")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "AcidFog")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "SerpentGuard")
            {
                typestd[w] = "specattack";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Washup")
            {
                typestd[w] = "chain";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Torrent")
            {
                typestd[w] = "chain";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Wave")
            {
                typestd[w] = "wave";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Rejunevation")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "HealingWave")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Tranquily")
            {
                typestd[w] = "rain";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "FrozenOrb")
            {
                typestd[w] = "point";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Blizzard")
            {
                typestd[w] = "rain";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "FrostArmor")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Sarcophagus")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "StaticBolts")
            {
                typestd[w] = "point";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "SkyThunder")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "ElectricalShield")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "LightingOrb")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "StarBlast")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Starfall")
            {
                typestd[w] = "rain";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Obscuration")
            {
                typestd[w] = "self";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Blessing")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Salvation")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "GuardianAngel")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Resurrection")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "RaiseDead")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Anathem")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "IronMaiden")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Immortality")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Devastation")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "AstralRupture")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "BuffSteal")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "SpellDevour")
            {
                typestd[w] = "aoe";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "ControlInterception")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "LastWord")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Dimvision")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Sleepiness")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Lethargy")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Apathy")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Nightmares")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Dimentia")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Pain")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Agony")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Empathy")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Determinity")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "NoPain")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "FaithShield")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "NightVision")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "SilentStep")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Invisibility")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }
            if (skillStd[w] == "Illision")
            {
                typestd[w] = "target";
                std_effbase[w] = 0.01f;
                std_timebase[w] = 0.1f;
                std_aoebase[w] = 0.1f;
                std_basecd[w] = 5f;
                std_mpbase[w] = 4;
                std_cdbase[w] = 4;
                std_tgtbase[w] = 1;
                std_difbase[w] = 1;
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                int tgt_bonus = 0;
                int dif_bonus = 0;
                if (w == 0)
                {
                    for (int i = 0; i < runesstd1.Length; i++)
                    {
                        if (runesstd1[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd1[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd1[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 1)
                {
                    for (int i = 0; i < runesstd2.Length; i++)
                    {
                        if (runesstd2[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd2[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd2[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                if (w == 2)
                {
                    for (int i = 0; i < runesstd3.Length; i++)
                    {
                        if (runesstd3[i] == "eff+") { eff_bonus += std_effbase[w]; }
                        if (runesstd3[i] == "aoe+") { aoe_bonus -= 1; }
                        if (runesstd3[i] == "ti+") { time_bonus += 1; }
                        if (runesstd1[i] == "mp-") { mp_bonus -= 1; }
                        if (runesstd1[i] == "cd-") { cd_bonus -= 1; }
                        if (runesstd1[i] == "tgt+") { tgt_bonus += 1; }
                        if (runesstd1[i] == "di-") { dif_bonus -= 1; }
                    }
                }
                std_efftotal[w] = (std_effbase[w] * lvl_std[w]) + eff_bonus;
                std_timetotal[w] = (std_timebase[w] * lvl_std[w]) + time_bonus;
                std_aoetotal[w] = (std_aoebase[w] * lvl_std[w]) + aoe_bonus;
                std_mptotal[w] = (std_mpbase[w] * lvl_std[w]) + mp_bonus;
                std_cdtotal[w] = (std_cdbase[w] * lvl_std[w]) + cd_bonus;
                std_tgttotal[w] = (std_tgtbase[w] * lvl_std[w]) + tgt_bonus;
                std_diftotal[w] = (std_difbase[w] * lvl_std[w]) + dif_bonus;
            }




        }




        



    }
}
