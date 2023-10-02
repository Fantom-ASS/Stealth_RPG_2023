using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class SpellDamage : MonoBehaviour
{
    public float dmg_min;
    public float dmg_max;
    public float armor;
    public float resist;
    public float time;
    public float reflect;
    public float fcr;
    public int targets;

    public float totaldmg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(reflect<0) { reflect = 0; }
        if (reflect > 1) { reflect = 1; }
        if (resist < 0) { resist = 0; }
        if (resist > 1) { resist = 1; }
        if (armor < 0) { armor= 0; }
        if (armor < dmg_min)
        {
            totaldmg = (((dmg_min + dmg_max) / 2)-armor) * (1-resist) * (1 - reflect)*fcr*targets;
        }
        if (armor >= dmg_min && armor < dmg_max)
        {
            float percentage = 0;
            float border = armor - dmg_min;
            if (border < 0) { border *= -1; }

            float maximum = dmg_max - dmg_min;
            percentage = border / maximum;
            float average = (maximum / 2) *(1-percentage);
            totaldmg = average * (1 - resist) * (1 - reflect) * fcr * targets;
        }
        if(armor >= dmg_max)
        {
            totaldmg = 0;
        }


    }
}
