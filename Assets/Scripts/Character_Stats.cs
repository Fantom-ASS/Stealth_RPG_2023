using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Character_Stats : MonoBehaviour
{
 

public string unit_name;
public string unit_race;
public string unit_class;
public int unit_id;
public int unit_clan;
public int unit_level;
public bool unit_alive;
public bool unit_organic;
public float exp_cur;
public float exp_next;

//unit current states
public bool unit_flee;
public bool unit_hit;
public bool unit_block;
public bool unit_attack;
public bool unit_spell;

public float attack_range;
public string attack_type;
public string move_type;
public float vision_angle;



//primary stats
public int strength;
public int dexterity;
public int energy;

//secondary stats
public float dmg_min;
public float dmg_max;
public float crit_mult;
public string dmg_type;

public float visionlength_base;
public float ias_base;
public float fcr_base;
public float ardef_base;
public float ar_base;
public float def_base;
public string defend_type;
public float armor_total;


public float hp_maxbase;
public float hp_cur;
public float hp_regen;
public float mp_maxbase;
public float mp_cur;
public float mp_regen_base;
public float absorb_base;
public float respierce_base;
public float resslice_base;
public float resblund_base;
public float resstorm_base;
public float resfire_base;
public float researth_base;


public float magic_reflect_base;
public float arrow_reflect_base;
public float magic_block_base;
public float curse_reduce_base;
public float defend_block_base;
public float defend_evade_base;
public float defend_blockdmg_base;



//modifiers
public float visionlength_mod;
public float hp_maxmod;
public float mp_maxmod;
public float hp_regenmod;
public float mp_regenmod;
public float absorb_mod;
public float respierce_mod;
public float resslice_mod;
public float resblund_mod;
public float resstorm_mod;
public float resfire_mod;
public float researth_mod;

public float magic_reflectmod;
public float arrow_reflectmod;
public float magic_blockmod;
public float curse_reducemod;
public float defend_blockmod;
public float defend_evademod;
public float defend_blockdmg_mod;
public float ar_mod;
public float def_mod;
public float dmg_mod;
public float ias_mod;
public float fcr_mod;

//total
public float visionlength_total;
public float hp_maxtotal;
public float mp_maxtotal;
public float hp_regentotal;
public float mp_regentotal;
public float absorb_total;
public float respierce_total;
public float resslice_total;
public float resblund_total;
public float resstorm_total;
public float resfire_total;
public float researth_total;

public float magic_reflecttotal;
public float arrow_reflecttotal;
public float magic_blocktotal;
public float curse_reducetotal;
public float defend_blocktotal;
public float defend_evadetotal;
public float defend_blockdmg_total;
public float ar_total;
public float def_total;
public float dmg_total;
public float ias_total;
public float fcr_total;

//perks
public int melee_mastery;
public int throw_mastery;
public int shoot_mastery;
public int stealth_mastery;

public int storm_mastery;
public int fire_mastery;
public int earth_mastery;
public int astral_mastery;
public int sencory_mastery;

//active abilities
public string nameBase;
public string nameSpec;
public string nameDef;
public string nameOff;
public string nameOne;
public string nameTwo;
public string nameThree;
public string nameUlt;

public int lvlBase;
public int lvlSpec;
public int lvlDef;
public int lvlOff;
public int lvlOne;
public int lvlTwo;
public int lvlThree;
public int lvlUlt;

public string[] runebase = new string[5];
public string[] runespec = new string[5];
public string[] runedef = new string[5];
public string[] runeoff = new string[5];
public string[] runeone = new string[5];
public string[] runetwo = new string[5];
public string[] runethree = new string[5];
public string[] runeult = new string[5];

public float effBase;
public float timeBase;
public float aoeBase;
public float tgtBase;
public float difBase;

public float effSpec;
public float timeSpec;
public float aoeSpec;
public float tgtSpec;
public float mpSpec;
public float difSpec;

public float effDef;
public float timeDef;
public float aoeDef;
public float tgtDef;
public float cdDef;
public float difDef;

public float effOff;
public float timeOff;
public float aoeOff;
public float tgtOff;
public float cdOff;
public float difOff;

public float effOne;
public float timeOne;
public float aoeOne;
public float tgtOne;
public float mpOne;
public float cdOne;
public float difOne;

public float effTwo;
public float timeTwo;
public float aoeTwo;
public float tgtTwo;
public float mpTwo;
public float cdTwo;
public float difTwo;

public float effThree;
public float timeThree;
public float aoeThree;
public float tgtThree;
public float mpThree;
public float cdThree;
public float difThree;

public float effUlt;
public float timeUlt;
public float aoeUlt;
public float tgtUlt;
public float mpUlt; 
public float cdUlt;
public float difUlt;



//buff list
public List<GameObject> buffList = new List<GameObject>();
public List<ParticleSystem> particleList = new List<ParticleSystem>();
//public List<string> buffName = new List<string>();
//public GameObject buffBase;
//public Buff_Base currentBuff;


//ability list
public GameObject baseability;
public GameObject offability;
public GameObject defability;
public GameObject abilityLight;
public GameObject abilityMid;
public GameObject abilityHigh;
public GameObject abilityUlt;



    // Start is called before the first frame update
    void Start()
    {
        hp_maxbase = (strength * 4) + ((strength - 10) * (unit_level - 1));
        mp_maxbase = (energy * 4) + ((energy - 10) * (unit_level - 1));
        ardef_base = dexterity - 10;
        hp_cur = hp_maxbase;
        AbilitiesCheck();
    }

    // Update is called once per frame
    void Update()
    {
        hp_maxbase = (strength * 4) + ((strength-10) * (unit_level - 1));
        mp_maxbase = (energy * 4) + ((energy-10) * (unit_level - 1));
        ardef_base = dexterity-10;
        if(hp_cur > 0) { unit_alive = true; }

        for(int i = 0; i<buffList.Count; i++)
        {
            if (buffList[i] == null) {buffList.RemoveAt(i);}
        }
    }

    void AbilitiesCheck()
    {
        //review spell characteristics
        GameObject allAbilities = GameObject.Find("AbilitiesDictionary");
        AbilitiesBaseData dataAbilities = allAbilities.GetComponent<AbilitiesBaseData>();
        for(int i = 0; i < dataAbilities.abilitiesName.Length; i++)
        {
            if(nameBase == dataAbilities.abilitiesName[i]) 
            {
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float tgt_bonus = 0;
                float dif_bonus = 0;
                for (int j = 0; j < runebase.Length; j++)
                {
                    if (runebase[j] == "eff+") { eff_bonus += dataAbilities.abilitiesEffectStep[i]; }
                    if (runebase[j] == "aoe+") { aoe_bonus -= dataAbilities.abilitiesAoEStep[i]; }
                    if (runebase[j] == "ti+") { time_bonus += dataAbilities.abilitiesTimeStep[i]; }
                    if (runebase[j] == "tgt+") { tgt_bonus += dataAbilities.abilitiesTargetStep[i]; }
                    if (runebase[j] == "di-") { dif_bonus -= dataAbilities.abilitiesDifficultStep[i]; }
                }
                effBase = dataAbilities.abilitiesEffectBase[i] + ((lvlBase - 1) * dataAbilities.abilitiesEffectStep[i]) + eff_bonus;
                aoeBase = dataAbilities.abilitiesAoEBase[i] + ((lvlBase - 1) * dataAbilities.abilitiesAoEStep[i]) + aoe_bonus;
                timeBase = dataAbilities.abilitiesTimeBase[i] + ((lvlBase - 1) * dataAbilities.abilitiesTimeStep[i]) + time_bonus;
                tgtBase = dataAbilities.abilitiesTargetBase[i] + ((lvlBase - 1) * dataAbilities.abilitiesTargetStep[i]) + tgt_bonus;
                difBase = dataAbilities.abilitiesDifficultBase[i] + ((lvlBase - 1) * dataAbilities.abilitiesDifficultStep[i]) + dif_bonus;
                Debug.Log(nameBase); 
            }
            if (nameSpec == dataAbilities.abilitiesName[i])
            {
                    float eff_bonus = 0;
                    float aoe_bonus = 0;
                    float time_bonus = 0;
                    float mp_bonus = 0;
                    float tgt_bonus = 0;
                    float dif_bonus = 0;
                    for (int j = 0; j < runespec.Length; j++)
                    {
                        if (runespec[j] == "eff+") { eff_bonus += dataAbilities.abilitiesEffectStep[i]; }
                        if (runespec[j] == "aoe+") { aoe_bonus -= dataAbilities.abilitiesAoEStep[i]; }
                        if (runespec[j] == "ti+") { time_bonus += dataAbilities.abilitiesTimeStep[i]; }
                        if (runespec[j] == "mp-") { mp_bonus -= dataAbilities.abilitiesManaStep[i]; }
                        if (runespec[j] == "tgt+") { tgt_bonus += dataAbilities.abilitiesTargetStep[i]; }
                        if (runespec[j] == "di-") { dif_bonus -= dataAbilities.abilitiesDifficultStep[i]; }
                    }
                    effSpec = dataAbilities.abilitiesEffectBase[i] + ((lvlSpec - 1) * dataAbilities.abilitiesEffectStep[i]) + eff_bonus;
                    aoeSpec = dataAbilities.abilitiesAoEBase[i] + ((lvlSpec - 1) * dataAbilities.abilitiesAoEStep[i]) + aoe_bonus;
                    timeSpec = dataAbilities.abilitiesTimeBase[i] + ((lvlSpec - 1) * dataAbilities.abilitiesTimeStep[i]) + time_bonus;
                    mpSpec = dataAbilities.abilitiesManaBase[i] + ((lvlSpec - 1) * dataAbilities.abilitiesManaStep[i]) + mp_bonus;
                    tgtSpec = dataAbilities.abilitiesTargetBase[i] + ((lvlSpec - 1) * dataAbilities.abilitiesTargetStep[i]) + tgt_bonus;
                    difSpec = dataAbilities.abilitiesDifficultBase[i] + ((lvlSpec - 1) * dataAbilities.abilitiesDifficultStep[i]) + dif_bonus;
                    Debug.Log(nameSpec);
            }
            if (nameDef == dataAbilities.abilitiesName[i])
            {
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float cd_bonus = 0;
                float tgt_bonus = 0;
                float dif_bonus = 0;
                for (int j = 0; j < runedef.Length; j++)
                {
                    if (runedef[j] == "eff+") { eff_bonus += dataAbilities.abilitiesEffectStep[i]; }
                    if (runedef[j] == "aoe+") { aoe_bonus -= dataAbilities.abilitiesAoEStep[i]; }
                    if (runedef[j] == "ti+") { time_bonus += dataAbilities.abilitiesTimeStep[i]; }
                    if (runedef[j] == "cd-") { cd_bonus -= dataAbilities.abilitiesCooldownStep[i]; }
                    if (runedef[j] == "tgt+") { tgt_bonus += dataAbilities.abilitiesTargetStep[i]; }
                    if (runedef[j] == "di-") { dif_bonus -= dataAbilities.abilitiesDifficultStep[i]; }
                }
                effDef = dataAbilities.abilitiesEffectBase[i] + ((lvlDef - 1) * dataAbilities.abilitiesEffectStep[i]) + eff_bonus;
                aoeDef = dataAbilities.abilitiesAoEBase[i] + ((lvlDef - 1) * dataAbilities.abilitiesAoEStep[i]) + aoe_bonus;
                timeDef = dataAbilities.abilitiesTimeBase[i] + ((lvlDef - 1) * dataAbilities.abilitiesTimeStep[i]) + time_bonus;
                cdDef = dataAbilities.abilitiesCooldownBase[i] + ((lvlDef - 1) * dataAbilities.abilitiesCooldownStep[i]) + cd_bonus;
                tgtDef = dataAbilities.abilitiesTargetBase[i] + ((lvlDef - 1) * dataAbilities.abilitiesTargetStep[i]) + tgt_bonus;
                difDef = dataAbilities.abilitiesDifficultBase[i] + ((lvlDef - 1) * dataAbilities.abilitiesDifficultStep[i]) + dif_bonus;
                Debug.Log(nameDef);
            }
            if (nameOff == dataAbilities.abilitiesName[i])
            {
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float cd_bonus = 0;
                float tgt_bonus = 0;
                float dif_bonus = 0;
                for (int j = 0; j < runeoff.Length; j++)
                {
                    if (runeoff[j] == "eff+") { eff_bonus += dataAbilities.abilitiesEffectStep[i]; }
                    if (runeoff[j] == "aoe+") { aoe_bonus -= dataAbilities.abilitiesAoEStep[i]; }
                    if (runeoff[j] == "ti+") { time_bonus += dataAbilities.abilitiesTimeStep[i]; }
                    if (runeoff[j] == "cd-") { cd_bonus -= dataAbilities.abilitiesCooldownStep[i]; }
                    if (runeoff[j] == "tgt+") { tgt_bonus += dataAbilities.abilitiesTargetStep[i]; }
                    if (runeoff[j] == "di-") { dif_bonus -= dataAbilities.abilitiesDifficultStep[i]; }
                }
                effOff = dataAbilities.abilitiesEffectBase[i] + ((lvlOff - 1) * dataAbilities.abilitiesEffectStep[i]) + eff_bonus;
                aoeOff = dataAbilities.abilitiesAoEBase[i] + ((lvlOff - 1) * dataAbilities.abilitiesAoEStep[i]) + aoe_bonus;
                timeOff = dataAbilities.abilitiesTimeBase[i] + ((lvlOff - 1) * dataAbilities.abilitiesTimeStep[i]) + time_bonus;
                cdOff = dataAbilities.abilitiesCooldownBase[i] + ((lvlOff - 1) * dataAbilities.abilitiesCooldownStep[i]) + cd_bonus;
                tgtOff = dataAbilities.abilitiesTargetBase[i] + ((lvlOff - 1) * dataAbilities.abilitiesTargetStep[i]) + tgt_bonus;
                difOff = dataAbilities.abilitiesDifficultBase[i] + ((lvlOff - 1) * dataAbilities.abilitiesDifficultStep[i]) + dif_bonus;
                Debug.Log(nameOff);
            }
            if (nameOne == dataAbilities.abilitiesName[i])
            {
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                float tgt_bonus = 0;
                float dif_bonus = 0;
                for (int j = 0; j < runeone.Length; j++)
                {
                    if (runeone[j] == "eff+") { eff_bonus += dataAbilities.abilitiesEffectStep[i]; }
                    if (runeone[j] == "aoe+") { aoe_bonus -= dataAbilities.abilitiesAoEStep[i]; }
                    if (runeone[j] == "ti+") { time_bonus += dataAbilities.abilitiesTimeStep[i]; }
                    if (runeone[j] == "mp-") { mp_bonus -= dataAbilities.abilitiesManaStep[i]; }
                    if (runeone[j] == "cd-") { cd_bonus -= dataAbilities.abilitiesCooldownStep[i]; }
                    if (runeone[j] == "tgt+") { tgt_bonus += dataAbilities.abilitiesTargetStep[i]; }
                    if (runeone[j] == "di-") { dif_bonus -= dataAbilities.abilitiesDifficultStep[i]; }
                }
                effOne = dataAbilities.abilitiesEffectBase[i] + ((lvlOne - 1) * dataAbilities.abilitiesEffectStep[i]) + eff_bonus;
                aoeOne = dataAbilities.abilitiesAoEBase[i] + ((lvlOne - 1) * dataAbilities.abilitiesAoEStep[i]) + aoe_bonus;
                timeOne = dataAbilities.abilitiesTimeBase[i] + ((lvlOne - 1) * dataAbilities.abilitiesTimeStep[i]) + time_bonus;
                mpOne = dataAbilities.abilitiesManaBase[i] + ((lvlOne - 1) * dataAbilities.abilitiesManaStep[i]) + mp_bonus;
                cdOne = dataAbilities.abilitiesCooldownBase[i] + ((lvlOne - 1) * dataAbilities.abilitiesCooldownStep[i]) + cd_bonus;
                tgtOne = dataAbilities.abilitiesTargetBase[i] + ((lvlOne - 1) * dataAbilities.abilitiesTargetStep[i]) + tgt_bonus;
                difOne = dataAbilities.abilitiesDifficultBase[i] + ((lvlOne - 1) * dataAbilities.abilitiesDifficultStep[i]) + dif_bonus;
                Debug.Log(nameOne);
            }
            if (nameTwo == dataAbilities.abilitiesName[i])
            {
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                float tgt_bonus = 0;
                float dif_bonus = 0;
                for (int j = 0; j < runetwo.Length; j++)
                {
                    if (runetwo[j] == "eff+") { eff_bonus += dataAbilities.abilitiesEffectStep[i]; }
                    if (runetwo[j] == "aoe+") { aoe_bonus -= dataAbilities.abilitiesAoEStep[i]; }
                    if (runetwo[j] == "ti+") { time_bonus += dataAbilities.abilitiesTimeStep[i]; }
                    if (runetwo[j] == "mp-") { mp_bonus -= dataAbilities.abilitiesManaStep[i]; }
                    if (runetwo[j] == "cd-") { cd_bonus -= dataAbilities.abilitiesCooldownStep[i]; }
                    if (runetwo[j] == "tgt+") { tgt_bonus += dataAbilities.abilitiesTargetStep[i]; }
                    if (runetwo[j] == "di-") { dif_bonus -= dataAbilities.abilitiesDifficultStep[i]; }
                }
                effTwo = dataAbilities.abilitiesEffectBase[i] + ((lvlTwo - 1) * dataAbilities.abilitiesEffectStep[i]) + eff_bonus;
                aoeTwo = dataAbilities.abilitiesAoEBase[i] + ((lvlTwo - 1) * dataAbilities.abilitiesAoEStep[i]) + aoe_bonus;
                timeTwo = dataAbilities.abilitiesTimeBase[i] + ((lvlTwo - 1) * dataAbilities.abilitiesTimeStep[i]) + time_bonus;
                mpTwo = dataAbilities.abilitiesManaBase[i] + ((lvlTwo - 1) * dataAbilities.abilitiesManaStep[i]) + mp_bonus;
                cdTwo = dataAbilities.abilitiesCooldownBase[i] + ((lvlTwo - 1) * dataAbilities.abilitiesCooldownStep[i]) + cd_bonus;
                tgtTwo = dataAbilities.abilitiesTargetBase[i] + ((lvlTwo - 1) * dataAbilities.abilitiesTargetStep[i]) + tgt_bonus;
                difTwo = dataAbilities.abilitiesDifficultBase[i] + ((lvlTwo - 1) * dataAbilities.abilitiesDifficultStep[i]) + dif_bonus;
                Debug.Log(nameTwo);
            }
            if (nameThree == dataAbilities.abilitiesName[i])
            {
                float eff_bonus = 0;
                float aoe_bonus = 0;
                float time_bonus = 0;
                float mp_bonus = 0;
                float cd_bonus = 0;
                float tgt_bonus = 0;
                float dif_bonus = 0;
                for (int j = 0; j < runethree.Length; j++)
                {
                    if (runethree[j] == "eff+") { eff_bonus += dataAbilities.abilitiesEffectStep[i]; }
                    if (runethree[j] == "aoe+") { aoe_bonus -= dataAbilities.abilitiesAoEStep[i]; }
                    if (runethree[j] == "ti+") { time_bonus += dataAbilities.abilitiesTimeStep[i]; }
                    if (runethree[j] == "mp-") { mp_bonus -= dataAbilities.abilitiesManaStep[i]; }
                    if (runethree[j] == "cd-") { cd_bonus -= dataAbilities.abilitiesCooldownStep[i]; }
                    if (runethree[j] == "tgt+") { tgt_bonus += dataAbilities.abilitiesTargetStep[i]; }
                    if (runethree[j] == "di-") { dif_bonus -= dataAbilities.abilitiesDifficultStep[i]; }
                }
                effThree = dataAbilities.abilitiesEffectBase[i] + ((lvlThree - 1) * dataAbilities.abilitiesEffectStep[i]) + eff_bonus;
                aoeThree = dataAbilities.abilitiesAoEBase[i] + ((lvlThree - 1) * dataAbilities.abilitiesAoEStep[i]) + aoe_bonus;
                timeThree = dataAbilities.abilitiesTimeBase[i] + ((lvlThree - 1) * dataAbilities.abilitiesTimeStep[i]) + time_bonus;
                mpThree = dataAbilities.abilitiesManaBase[i] + ((lvlThree - 1) * dataAbilities.abilitiesManaStep[i]) + mp_bonus;
                cdThree = dataAbilities.abilitiesCooldownBase[i] + ((lvlThree - 1) * dataAbilities.abilitiesCooldownStep[i]) + cd_bonus;
                tgtThree = dataAbilities.abilitiesTargetBase[i] + ((lvlThree - 1) * dataAbilities.abilitiesTargetStep[i]) + tgt_bonus;
                difThree = dataAbilities.abilitiesDifficultBase[i] + ((lvlThree - 1) * dataAbilities.abilitiesDifficultStep[i]) + dif_bonus;
                Debug.Log(nameThree);
            }
            if (nameUlt == dataAbilities.abilitiesName[i])
            {
                Debug.Log(nameUlt);
            }
        }
    }




}
