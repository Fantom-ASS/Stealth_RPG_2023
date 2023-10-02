using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public UnitParameters targetOfAttack;
    public float attack;
    public float damage_max;
    public float damage_min;
    public string damage_type;
    public bool aimable;
    public int bodypart; //0 - body, 1 - head, 2 - leftarm, 3 - rightarm, 4 - leftfoot, 5 - rightfoot, 6 - any
    public float hitchance; //probability of successful attack
    public int bodytarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (bodypart == 6)
            {
                bodytarget = UnityEngine.Random.Range(0, targetOfAttack.bodyparts_name.Length);
                if (bodytarget == 0) { hitchance = (attack / targetOfAttack.defence) / 2; }
                if (bodytarget == 1) { hitchance = (attack / targetOfAttack.defence) / 8; }
                if (bodytarget == 2 | bodytarget == 3 | bodytarget == 4 | bodytarget == 5) { hitchance = (attack / targetOfAttack.defence) / 2.5f; }
                float hitcheck = UnityEngine.Random.Range(0, 1);
                if (hitcheck < hitchance)
                {
                    float damagecheck = UnityEngine.Random.Range(damage_min, damage_max);
                    float healthdiff = targetOfAttack.bodyparts_health[bodytarget];
                    targetOfAttack.bodyparts_health[bodytarget] -= (damagecheck - (damagecheck * targetOfAttack.absorb_physic));
                    if (targetOfAttack.bodyparts_health[bodytarget] < 0) { targetOfAttack.bodyparts_health[bodytarget] = 0; }
                    targetOfAttack.health_cur -= healthdiff - targetOfAttack.bodyparts_health[bodytarget];
                }

            }

        }


        
        
        
    }
}
