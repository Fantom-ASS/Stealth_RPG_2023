using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBonuses : MonoBehaviour
{
    //character
    public GameObject hero;
    public Character_Stats heroStats;
    public WeaponStats weapon1Stats;

    //items weared
    public GameObject armor_head;
    public GameObject armor_gloves;
    public GameObject armor_boots;
    public GameObject armor_pants;
    public GameObject armor_shirt;
    public GameObject armor_body;
    public GameObject armor_leggings;

    public GameObject weapon_right;
    public GameObject weapon_left;
    public GameObject shield;

// Start is called before the first frame update
    void Start()
    {
        heroStats = hero.GetComponent<Character_Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (weapon_right != null)
        {
            weapon1Stats = weapon_right.GetComponent<WeaponStats>();
            heroStats.dmg_min = weapon1Stats.wpn_dmg_min + 1;
            heroStats.dmg_max = weapon1Stats.wpn_dmg_max + 2;
            heroStats.ar_total = (heroStats.ardef_base + heroStats.unit_level + heroStats.melee_mastery) + weapon1Stats.wpn_attack;
            heroStats.def_total = (heroStats.ardef_base + heroStats.unit_level + heroStats.melee_mastery) + weapon1Stats.wpn_defence;
        }
        else
        {
            weapon_right = null;
            weapon1Stats = null;
            heroStats.dmg_min =  1;
            heroStats.dmg_max =  2;
            heroStats.ar_total = 0;
            heroStats.def_total = 0;
        }




    }
}
