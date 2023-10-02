using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculators : MonoBehaviour
{
    public float dps;
    public float ehp;
    public float ttk;

    float dmgmod;
    float armod;
    float iasmod;

    public int a_lvl;
    public int d_lvl;

    public float attack;
    public float dmg_max;
    public float dmg_min;
    public float ias;

    public float hp_max;
    public float hp_cur;
    public float defence;
    public float armor;
    public float block;
    public float resist;
    public float hpregen;

    public float hitchance;
    public float critchance;
    public float blockchance;
    public float evadechance;
    public bool shield;
    public float blockperk;
    public float evadeperk;
    public float critperk;


    // Start is called before the first frame update
    void Start()
    {
        hp_cur = hp_max;
    }

    // Update is called once per frame
    void Update()
    {
        hitchance = (((attack - defence) / (1 + ((a_lvl + d_lvl) / 20))) + 50) / 100;
        if (hitchance < 0.05) { hitchance = 0.05f; }
        if (hitchance > 0.95) { hitchance = 0.95f; }

        critchance = ((((attack - defence) / (2 + ((a_lvl + d_lvl) / 10))) + 15) + critperk) / 100;
        if (critchance < 0.05) { critchance = 0.05f; }
        if (critchance > 0.75) { critchance = 0.75f; }

        evadechance = ((((defence - attack) / (2 + ((a_lvl + d_lvl) / 10))) + 15) + evadeperk) / 100;
        if (evadechance < 0.05) { evadechance = 0.05f; }
        if (evadechance > 0.75) { evadechance = 0.75f; }

        blockchance = ((((defence - attack) / (2 + ((a_lvl + d_lvl) / 10))) + 30)+blockperk) / 100;
        if (blockchance < 0.05) { blockchance = 0.05f; }
        if (blockchance > 0.75) { blockchance = 0.75f; }

        if(resist > 100) { resist = 100; }
        ehp = 1 / (1 - (resist/100));

        if (!shield)
        { 
            
            dps = ((((((((dmg_min + dmg_max) / 2) - armor) * (1 - evadechance)))*hitchance)*(1+(critchance))) - hpregen)*ias;
        }
        else
        {
            if (block + armor < dmg_min)
            {
                dps = ((((((((dmg_min + dmg_max) / 2) - armor) * (1 - blockchance)) + ((((dmg_min + dmg_max) / 2) - (armor + block)) * blockchance))*hitchance) * (1 + critchance)) - hpregen)*ias;
            }
            if (block + armor >= dmg_min && block + armor < dmg_max)
            {
                float percentage = 0;
                float border = (block + armor) - dmg_min;
                if(border < 0) { border *= -1; }

                float maximum = dmg_max - dmg_min;
                percentage = border / maximum;
                float average = (maximum / 2) * percentage;
                float dps1;
                float dps2;
                dps1 = ((((dmg_min + dmg_max) / 2) - armor) * (1 - blockchance));
                dps2 = average * blockchance;

               // dps = ((((((((dmg_min + dmg_max) / 2) * ias) - armor) * (1 - blockchance)) + (((((dmg_min + dmg_max) / 2) * ias) * percentage) * blockchance))*hitchance) * (1 + (critchance * 2))) - hpregen;
                dps = (((dps1+ dps2)*hitchance)*(1+critchance))*ias;

            }
            if (block + armor >= dmg_max)
            {
                dps = ((((((((dmg_min + dmg_max) / 2) - armor) * (1 - blockchance)))*hitchance) * (1 + critchance))-hpregen)*ias;
            }
        }
        
        ttk = (hp_max*ehp) / dps;



    }
}
