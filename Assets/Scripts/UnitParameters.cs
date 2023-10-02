using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitParameters : MonoBehaviour
{
    //basic
    public string unitname; //displayable name of unit
    public string race; //race of unit
    public int clan; //unit of the same clan is ally, any another clan for a safe of clan 0 is hostile
    public bool alive; //unit is alive
    

    //visual stats
    public int pow; // visual strength
    public int dex; // visual agility
    public int imagic; // visual intelligence

    public float health_max;
    public float health_cur;
    //each unit has different bodyparts, that can be damaged by melee and ranged units
    public int bodytype; //0 - humanoid, 1 - quadruped, 2 - creature, 3 - bodyhead, 4 - amorphous
    public string[] bodyparts_name;
    public float[] bodyparts_health;

    public string[] abilities_name = new string[4];
    public float[] abilities_cd_max = new float[4];
    public float[] abilities_cd_cur = new float[4];

    public float regen_base;
    public float mana_max;
    public float mana_cur;
    public float recover_base;
    public float hearing_range_base;
    public float hearing_range_bonus;
    public float vision_range_base;
    public float vision_range_bonus;
    public float vision_angle;
    public float noise_radius;
    public float speed_crouch;
    public float speed_walk;
    public float speed_run;

    public string attack_type;
    public float attack_distance;
    public string damage_type;
    public float attack_speed;
    public float cast_speed;
    public float damage_min;
    public float damage_max;
    public float attack;
    public float defence;
    public float block_melee;
    public float block_range;
    public float evade_melee;
    public float evade_range;
    public float repel_cast;
    public float curse_resist;
    public float absorb_physic;
    public float absorb_magic;
    public float resist_pierce;
    public float resist_slash;
    public float resist_blunt;
    public float resist_storm;
    public float resist_earth;
    public float resist_fire;

    //according to all unit abilities they have a string name and array of their parameters, which are in such order: effect, range, AoE, duration, charges, mana, cooldown
    public string move_name;
    public float[] move;
    public string attackbase_name;
    public float[] attackbase;
    public string attackspec_name;
    public float[] attackspec;
    public string ability1_name;
    public float[] ability1;
    public string ability2_name;
    public float[] ability2;
    public string ability3_name;
    public float[] ability3;
    public string ability4_name;
    public float[] ability4;

    //arrays with parameters of abilities: charges left, cooldown left, priorities. Abilities with higher priority preferable
    public float[] charges;
    public float[] cooldowns;
    public float[] priorities;

    public List<GameObject> buffName; //names of all buffs that unit has
    public List<GameObject> buffEffect; //strength of all buffs that unit has
    public List<GameObject> buffTime; //time left of all buffs that unit has

    public Transform point; //a point which unit will try to reach
    public Animator animator; //animator of character
    public NavMeshAgent agent;

    private StateMachine _SM;
    private CalmState _calmState;
    public string unitstate;

    public bool crouched; //unit's movement type, if true, unit moves crouched, if false, he walks or runs depends on location and path type;
    public bool aggressive; //unit's reaction on enemies, if true, unit attacks all enemies who attacks him or his allies, if false he only defends himself;
    public int distance; //distance that unit keeps to player,if 0, unit stay closer, if 1, unit stands behind player, if 2, unit doesn't foloow player and waits in place he is now
    public int priority; //target priority, 0 - the weakest enemy, 1 - strongest, 2 - closest, 3 - farthest, 4 - central (best target for AoE abilities)
    public int bodypart; //part of enemy body to aim in, 0 - body, 1 - head, 2 - hands, 3 - legs, 4 - random, not actual for magic-type damage

    public bool fear; //if it's true, when unit will see the enemy he will run away instead of fighting
    public bool alert; //happens if unit spot an enemy of hear suspicious noise
    public int behaviour; //0 - calm, 1 - suspence, 2 - flee, 3 - chase, 4 - attack, 5 - spell, 6 - lookaround
    public int movetype; //0 - crouch, 1 - walk, 2 - run

    public List<GameObject> unitsAround; //all units that are near the character
    public List<GameObject> unitsAttackable; //units which can be attacked by character
    public List<GameObject> unitsEnemies; //hostile visible units
    public List<GameObject> unitsAllies; //allied visible units
    public GameObject enemyClosest;
    public GameObject enemyFurthest;
    public GameObject enemyCentral;
    public GameObject enemyWeakest;
    public GameObject enemyStrongest;


    // Start is called before the first frame update
    void Start()
    {
        health_cur = health_max;

        if(bodytype == 0) 
        { 
        bodyparts_name = new string[] { "body", "head", "armleft", "armright", "legleft", "legright" };
        bodyparts_health = new float[6] { health_max, health_max, health_max/3, health_max / 3, health_max / 3, health_max / 3 };
        } else if (bodytype == 1)
        {
        bodyparts_name = new string[] { "body", "head", "armleft", "armright", "legleft", "legright" };
        bodyparts_health = new float[6] { health_max, health_max, health_max / 3, health_max / 3, health_max / 3, health_max / 3 };
        } else if (bodytype == 2)
        {
        bodyparts_name = new string[] { "body", "head", "armleft", "armright", "legleft", "legright" };
        bodyparts_health = new float[6] { health_max, health_max/3, health_max / 3, health_max / 3, health_max / 3, health_max / 3 };
        } else if (bodytype == 3)
        {
            bodyparts_name = new string[] { "body", "head"};
            bodyparts_health = new float[2] { health_max, health_max};
        } else if (bodytype == 4)
        {
            bodyparts_name = new string[] { "body"};
            bodyparts_health = new float[1] { health_max};
        }



        
    }

    // Update is called once per frame
    void Update()
    {
        //limits of abilities cooldown
        for (int i = 0; i < abilities_name.Length; i++)
        {
            abilities_cd_cur[i] = Mathf.Clamp(abilities_cd_cur[i], 0, abilities_cd_max[i]);
            //Debug.Log("CLAMP");
            if(abilities_cd_cur[i] > 0) { abilities_cd_cur[i] -= Time.deltaTime; }
        }

        //EXPERIMENT
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            for (int i = 0; i < abilities_cd_cur.Length; i++)
            {
                abilities_cd_cur[i] = abilities_cd_max[i]; 
                Debug.Log(999);

            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            ReplaceSkills();
        }

        //life & death triggers
        // if (health_cur < 0) { alive = false; }

        if (alive)
        {
            Regen();
        } else
        {
            health_cur = 0;
            mana_cur = 0;
        }

        //influence of bodyparts damage on common health
       // if (bodytype == 4) { health_cur = health_max - (health_max - bodyparts_health[0]); }
       // if (bodytype == 3) { health_cur = health_max - (health_max - bodyparts_health[0]) - (health_max - bodyparts_health[1]); }
       // if (bodytype == 2) { health_cur = health_max - (health_max - bodyparts_health[0]) - ((health_max / 3) - bodyparts_health[1]) - ((health_max / 3) - bodyparts_health[2]) - ((health_max / 3) - bodyparts_health[3]) - ((health_max / 3) - bodyparts_health[4]) - ((health_max / 3) - bodyparts_health[5]); }
       // if (bodytype == 1) { health_cur = health_max - (health_max - bodyparts_health[0]) - (health_max - bodyparts_health[1]) - ((health_max / 3) - bodyparts_health[2]) - ((health_max / 3) - bodyparts_health[3]) - ((health_max / 3) - bodyparts_health[4]) - ((health_max / 3) - bodyparts_health[5]); }
      //  if (bodytype == 0) { health_cur = health_max - (health_max - bodyparts_health[0]) - (health_max - bodyparts_health[1]) - ((health_max / 3) - bodyparts_health[2]) - ((health_max / 3) - bodyparts_health[3]) - ((health_max / 3) - bodyparts_health[4]) - ((health_max / 3) - bodyparts_health[5]); }






    }

    void Regen()
    {
        if (health_cur<health_max)
        {
             health_cur += regen_base * Time.deltaTime;
            float damaged = 0;
            for (int i = 0; i < bodyparts_name.Length; i++)
            {
                if (bodyparts_name[i] == "body" && bodyparts_health[i] < health_max)
                { damaged += 1;} else { bodyparts_health[i] = health_max; }

                if (bodytype != 2 && bodyparts_name[i] == "head" && bodyparts_health[i] < health_max)
                { damaged += 1; } else { bodyparts_health[i] = health_max; }

                if (bodytype == 2 && bodyparts_name[i] == "head" && bodyparts_health[i] < health_max/3)
                { damaged += 1; } else { bodyparts_health[i] = health_max/3; }

                if (bodyparts_name[i] == "armleft" && bodyparts_health[i] < health_max/3)
                { damaged += 1; } else { bodyparts_health[i] = health_max / 3; }

                if (bodyparts_name[i] == "armright" && bodyparts_health[i] < health_max / 3)
                { damaged += 1; } else { bodyparts_health[i] = health_max / 3; }

                if (bodyparts_name[i] == "legleft" && bodyparts_health[i] < health_max / 3)
                { damaged += 1; } else { bodyparts_health[i] = health_max / 3; }

                if (bodyparts_name[i] == "legright" && bodyparts_health[i] < health_max / 3)
                { damaged += 1; } else { bodyparts_health[i] = health_max / 3; }

            }
            Debug.Log(damaged);

        }
        if (health_cur > health_max) { health_cur = health_max; }
        if (mana_cur < mana_max && health_cur > 0)
        { mana_cur += recover_base * Time.deltaTime; }
        if (mana_cur > mana_max) { mana_cur = mana_max; }
    }

    void ReplaceSkills() 
    { 
        
        GameObject list = GameObject.Find("AbilitiesList");
        AbilitiesList abilitiesList = list.GetComponent<AbilitiesList>();
       // Debug.Log(900);
        for (int i = 0;i< abilities_name.Length; i++)
        {
            
            for (int j=0;j<abilitiesList.skills_name.Length; j++)
            {
                
                if (abilities_name[i] == abilitiesList.skills_name[j])
                {
                    Debug.Log("A" + j);
                    abilities_name[i] = abilitiesList.skills_name[j];
                    abilities_cd_max[i] = abilitiesList.skills_cd[j];
                }
            }
        }


    }


}
