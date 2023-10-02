using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    public GameObject unit1;
    public GameObject unit2;
    public Character_Stats stats1;
    public Character_Stats stats2;
    public float hit_chance;
    public float crit_chance;
    public float evade_chance;
    public float block_chance;
    public float res_type;

    public float ehp;
    public float dps;
    public float ttk;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (unit1 != null && unit2 != null)
        {
            stats1 = unit1.GetComponent<Character_Stats>();
            stats2 = unit2.GetComponent<Character_Stats>();
        }


        if (stats2.dmg_type == "pierce") res_type = stats1.respierce_total;
        if (stats2.dmg_type == "slice") res_type = stats1.resslice_total;
        if (stats2.dmg_type == "blund") res_type = stats1.resblund_total;
        if (stats2.dmg_type == "storm") res_type = stats1.resstorm_total;
        if (stats2.dmg_type == "fire") res_type = stats1.resfire_total;
        if (stats2.dmg_type == "earth") res_type = stats1.researth_total;
        if (stats2.dmg_type == "physic") res_type = (stats1.respierce_total + stats1.resslice_total + stats1.resblund_total) / 3;
        if (stats2.dmg_type == "astral") res_type = (stats1.resfire_total+stats1.researth_total+stats1.researth_total)/3;
        if (stats2.dmg_type == "lava" || stats2.dmg_type == "star") res_type = (stats1.resfire_total + stats1.researth_total) / 2;
        if (stats2.dmg_type == "water" || stats2.dmg_type == "cold") res_type = (stats1.resstorm_total + stats1.researth_total) / 2;
        if (stats2.dmg_type == "lighting" || stats2.dmg_type == "acid") res_type = (stats1.resstorm_total + stats1.resfire_total) / 2;


        hit_chance = (((stats1.ar_total - stats2.def_total) / (1 + ((stats1.unit_level + stats2.unit_level) / 20))) + 50)/100;
        if(hit_chance < 0.05) { hit_chance = 0.05f; } if (hit_chance > 0.95) { hit_chance = 0.95f; }

        crit_chance = (((stats1.ar_total - stats2.def_total) / (2 + ((stats1.unit_level + stats2.unit_level) / 10))) + 15)/100;
        if(crit_chance < 0.05) { crit_chance = 0.05f; } if (crit_chance > 0.75) { crit_chance = 0.75f; }

        evade_chance = (((stats1.ar_total - stats2.def_total) / (1 + ((stats1.unit_level + stats2.unit_level) / 20))) + 30)/100;
        if(evade_chance < 0.05) { evade_chance = 0.05f; } if (evade_chance > 0.75) { evade_chance = 0.75f; }

        block_chance = (((stats1.ar_total - stats2.def_total) / (1 + ((stats1.unit_level + stats2.unit_level) / 20))) + 30)/100;
        if(block_chance < 0.05) { block_chance = 0.05f; } if (block_chance > 0.75) { block_chance = 0.75f; }

        //ehp = stats1.hp_maxtotal/(100 - evade_chance)/(100 - res_type);
        //ehp = stats1.hp_maxtotal / (100 - evade_chance);

        ehp = stats1.hp_maxtotal/(1 - res_type)/(1 - evade_chance);
        dps = (((stats1.dmg_min + stats1.dmg_max) / 2) - (stats2.armor_total + (stats2.defend_blocktotal * stats2.defend_blockdmg_total)))*(hit_chance * (1 + (crit_chance * 2)) * stats2.ias_total) - stats2.hp_regentotal;
        ttk = ehp / dps;


    }
}
