using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;
using UnityEngine.XR;

public class AI_Behaviour : MonoBehaviour
{
    delegate void MyBroadcaster();
    MyBroadcaster myDelegate;

    public int id;
    public bool player;

    public NavMeshAgent agent;
    public Animator animator;

    public Character_Stats unitstats;
    public Character_Stats targetstats;
    public GameObject target;
    public GameObject unit;
    public GameObject shootPoint;
    public Transform point;
    public GameObject missile;
    public GameObject spell;


    public float behaveswitch;
    public string behave;
    public string unit_type;
    public string skill_name;
    public string skill_type;



    public float timer;
    public float angle;
    public float rotatetime;
    public bool rotating;
    public bool fight;
    public bool move;



    public bool notice;
    public bool run;


    
    public List<GameObject> unitsAround;
    public List<GameObject> unitsVisible;
    public List<GameObject> unitsAttackable;
    public List<GameObject> unitsBuffable;
    public List<GameObject> unitsCursable;
    public List<float> cursedRange;
    public List<float> minEHP;
    public List<float> maxDPS;
    public List<float> bestAoE;

    //public List<Character_Stats> unitStats;



    // Start is called before the first frame update
    void Start()
    {
       // animator = gameObject.GetComponent<Animator>();
      //  agent = gameObject.GetComponent<NavMeshAgent>();
       // unitstats = gameObject.GetComponent<Character_Stats>();
    }

    // Update is called once per frame
    void Update()
    {

        //animator settings
        if (unitstats.attack_type == "melee")
        {
            animator.SetInteger("attackType", 0);
        }
        if (unitstats.attack_type == "range")
        {
            animator.SetInteger("attackType", 1);
        }
        if (unitstats.attack_type == "magic")
        {
            animator.SetInteger("attackType", 2);
        }

        if (unitstats.move_type == "walk")
        {
            animator.SetInteger("moveType", 0);
        }
        if (unitstats.move_type == "run")
        {
            animator.SetInteger("moveType", 1);
        }

        if (unitstats.hp_cur < 0)
        {Death();}





        //checking units around
        List<GameObject> unitsAll = GameObject.FindGameObjectsWithTag("Unit").ToList();
        for (int i = 0; i < unitsAll.Count; i++)
        {
            Character_Stats charstats1 = unitsAll[i].GetComponent<Character_Stats>();
            if (!unitsAround.Contains(unitsAll[i]) && charstats1.unit_alive)
            {
                if (charstats1.unit_alive)
                {
                    unitsAround.Add(unitsAll[i]);
                }
            }
        }
        for (int i = 0; i < unitsAround.Count; i++)
        {
            Character_Stats charstats1 = unitsAround[i].GetComponent<Character_Stats>();
            if (!charstats1.unit_alive)
            {
                unitsAround.RemoveAt(i);
            }
            if (unitsAround[i] == this.gameObject)
            {
                unitsAround.RemoveAt(i);
            }
        }

        //visible units
        for (int j = 0; j < unitsAround.Count; j++)
        {
            Vector3 visionDir1 = (new Vector3(unitsAround[j].transform.position.x, transform.position.y, unitsAround[j].transform.position.z)) - transform.position;
            Vector3 vision1 = transform.forward;
            float visangle1 = Vector3.SignedAngle(visionDir1, vision1, Vector3.up);
            float visrange1 = Vector3.Distance(unitsAround[j].transform.position, transform.position);
            Character_Stats charstats1 = unitsAround[j].GetComponent<Character_Stats>();
            if (visrange1 < unitstats.visionlength_total)
            {
                if (visangle1 < 70 && visangle1 > -70)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, unitsAround[j].transform.position - transform.position, out hit, 10f))
                    {
                        if (hit.transform.gameObject == unitsAround[j])
                        {
                            if (!unitsVisible.Contains(unitsAround[j]))
                            {
                                if (charstats1.unit_alive)
                                {
                                    unitsVisible.Add(unitsAround[j]);
                                }
                                else
                                {
                                    unitsVisible.Remove(unitsAround[j]);
                                }
                            }
                        }
                    }
                }
            }
        }





        for (int k = 0; k < unitsVisible.Count; k++)
        {
            Vector3 visionDir2 = (new Vector3(unitsVisible[k].transform.position.x, transform.position.y, unitsVisible[k].transform.position.z)) - transform.position;
            Vector3 vision2 = transform.forward;
            float visangle2 = Vector3.SignedAngle(visionDir2, vision2, Vector3.up);
            float visrange2 = Vector3.Distance(unitsVisible[k].transform.position, transform.position);
            Character_Stats charstats1 = unitsAround[k].GetComponent<Character_Stats>();
            if (visrange2 < unitstats.visionlength_total)
            {
                if (visangle2 < 70 && visangle2 > -70)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, unitsVisible[k].transform.position - transform.position, out hit, unitstats.visionlength_total))
                    {
                        if (hit.transform.gameObject != unitsVisible[k])
                        {
                            if (hit.transform.gameObject.layer != 8)
                            {
                                unitsVisible.RemoveAt(k);

                            }
                        }
                    }
                }
                else
                { unitsVisible.RemoveAt(k); }
            } else
            { unitsVisible.RemoveAt(k); }
        }


        //visible dead remove
        for (int i = 0; i < unitsVisible.Count; i++)
        {
            Character_Stats charstats1 = unitsVisible[i].GetComponent<Character_Stats>();
            if (!charstats1.unit_alive)
            {
                unitsVisible.RemoveAt(i);
               // Debug.Log("AAAAAAAAAA");
            }
            if (unitsAround[i] == this.gameObject)
            {
                unitsVisible.RemoveAt(i);
            }
        }




        //attackable units
        for (int l = 0; l < unitsVisible.Count; l++)
        {
            Character_Stats charstats = unitsVisible[l].GetComponent<Character_Stats>();
            float range = Vector3.Distance(transform.position, unitsVisible[l].transform.position);
            float dps = ((charstats.dmg_min + charstats.dmg_max) / 2) * charstats.ias_total;
            if (range < unitstats.attack_range)
            {
                if (!unitsAttackable.Contains(unitsVisible[l]) && unitstats.unit_clan != charstats.unit_clan && charstats.unit_alive)
                {
                    unitsAttackable.Add(unitsVisible[l]);
                    minEHP.Add(charstats.hp_cur);
                    maxDPS.Add(dps);
                }
            }
        }
        for (int m = 0; m < unitsAttackable.Count; m++)
        {
            Character_Stats charstats = unitsAttackable[m].GetComponent<Character_Stats>();
            float range = Vector3.Distance(transform.position, unitsAttackable[m].transform.position);
            if (unitsVisible.Contains(unitsAttackable[m]))
            {
                if (range > unitstats.attack_range && !charstats.unit_alive)
                {
                    unitsAttackable.RemoveAt(m);
                    minEHP.RemoveAt(m);
                    maxDPS.RemoveAt(m);
                    bestAoE.RemoveAt(m);
                }
            }
            else
            {
                unitsAttackable.RemoveAt(m);
                minEHP.RemoveAt(m);
                maxDPS.RemoveAt(m);
                bestAoE.RemoveAt(m);
            }
        }

        //buffable units
        for (int n = 0; n < unitsVisible.Count; n++)
        {
            Character_Stats charstats = unitsVisible[n].GetComponent<Character_Stats>();
            float range = Vector3.Distance(transform.position, unitsVisible[n].transform.position);
            if (!unitsBuffable.Contains(unitsVisible[n]) && unitstats.unit_clan == charstats.unit_clan && charstats.unit_alive)
            {
                unitsBuffable.Add(unitsVisible[n]);
            }
        }
        for (int o = 0; o < unitsBuffable.Count; o++)
        {
            if (!unitsVisible.Contains(unitsBuffable[o]))
            {
                unitsBuffable.RemoveAt(o);
            }
        }

        //cursable units
        for (int p = 0; p < unitsVisible.Count; p++)
        {
            Character_Stats charstats = unitsVisible[p].GetComponent<Character_Stats>();
            float range = Vector3.Distance(transform.position, unitsVisible[p].transform.position);
            if (!unitsCursable.Contains(unitsVisible[p]) && unitstats.unit_clan != charstats.unit_clan)
            {
                unitsCursable.Add(unitsVisible[p]);
                cursedRange.Add(range);
            }
        }
        for (int q = 0; q < unitsCursable.Count; q++)
        {
            if (!unitsVisible.Contains(unitsCursable[q]))
            {
                unitsCursable.RemoveAt(q);
                cursedRange.RemoveAt(q);
            }
        }
        for (int q = 0; q < cursedRange.Count; q++)
        {
            Character_Stats charstats = unitsVisible[q].GetComponent<Character_Stats>();
            float range = Vector3.Distance(transform.position, unitsVisible[q].transform.position);
            cursedRange[q] = range;
        }
        for (int r = 0; r < minEHP.Count; r++)
        {
            Character_Stats charstats = unitsAttackable[r].GetComponent<Character_Stats>();
            float vitality = charstats.hp_cur;
            minEHP[r] = vitality;
        }
        for (int s = 0; s < maxDPS.Count; s++)
        {
            Character_Stats charstats = unitsAttackable[s].GetComponent<Character_Stats>();
            float dps = ((charstats.dmg_min + charstats.dmg_max) / 2) * charstats.ias_total;
            maxDPS[s] = dps;
        }

        //looking for best AoE target
        List<GameObject> objects = new List<GameObject>();
        List<float> ranges = new List<float>();
        for (int a = 0; a < unitsAttackable.Count; a++)
        {
            for (int b = 0; b < unitsAttackable.Count; b++)
            {
                if (ranges.Count < unitsAttackable.Count)
                { ranges.Add(Vector3.Distance(transform.position, unitsAttackable[b].transform.position)); }
                if (bestAoE.Count < unitsAttackable.Count)
                { bestAoE.Add(ranges.Sum()); }
            }
            for (int c = 0; c < unitsAttackable.Count; c++)
            {
                GameObject curobject;
                curobject = unitsAttackable[a];
                ranges[c] = Vector3.Distance(unitsAttackable[a].transform.position, unitsAttackable[c].transform.position);
                bestAoE[c] = ranges.Sum();
                for (int d = 0; d < unitsAttackable.Count; d++)
                { curobject = unitsAttackable[d]; }
            }
        }





        //actions if unit is alive
        if (unitstats.unit_alive)
        {
            //rotating
            if (rotating && timer > 0)
            {


                if (angle >= 0)
                    transform.Rotate(0, (-angle * Time.deltaTime) / rotatetime, 0);

                if (angle < 0)
                    transform.Rotate(0, (angle * Time.deltaTime) / rotatetime, 0);
            }
            if (timer > 0) { timer -= Time.deltaTime; }
            if (timer < 0) { timer = 0; rotating = false; }

            //melee attack conditions
            if (unitstats.attack_type == "melee" && agent.remainingDistance < (agent.stoppingDistance + 0.5))
            {
                animator.SetBool("Move", false);
                move = false;

                if (target != null && target.layer == 8)
                {
                    float tgtrange = Vector3.Distance(target.transform.position, transform.position);
                    if (tgtrange < unitstats.attack_range)
                    {
                        animator.SetBool("Attack", true);
                    }
                    if (tgtrange > unitstats.attack_range)
                    {
                        animator.SetBool("Attack", false);
                    }
                    float rotDif = (transform.rotation.y - target.transform.rotation.y);
                    if(rotDif<0) {rotDif = -rotDif;}
                   // if(rotDif < 150) { Turn(); }
                }
            }

            //ranged attack conditions
            if (target != null && target.layer == 8)
            {
                if (unitstats.attack_type == "range" || unitstats.attack_type == "magic")
                {
                    Turn();
                    animator.SetBool("Move", false);
                    move = false;
                    animator.SetBool("Attack", true);
                }
            }




            //walking conditions
            if (target != null)
            {

                float walkrange = Vector3.Distance(target.transform.position, transform.position);
                if (walkrange > (agent.stoppingDistance + 0.5))
                {
                    animator.SetBool("Move", true);
                    move = true;
                }
                else
                {
                    animator.SetBool("Move", false);
                    move = false;
                    agent.destination = transform.position;

                }

                //attack interrupt
                float attrange = Vector3.Distance(target.transform.position, agent.destination);
                if (attrange > unitstats.attack_range)
                {
                    animator.SetBool("Move", false);
                    move = false;
                }

                //target dies (no need later)
                if (target.layer == 8 && targetstats != null && !targetstats.unit_alive)
                {
                    target = null;
                    animator.SetBool("Attack", false);
                    animator.SetBool("Move", false);
                    move = false;
                }

            }

            //damage conditions
            if (Input.GetKeyDown(KeyCode.U))
            {
                MeleeDamage();
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                RangeShot();
            }
        }



        




        //bot behaviour switching
        if (!player && unitstats.unit_alive)
        {

            //patroling, environment interacting, rotating or just doing nothing
            if (behave == "calm")
            {
                //state switch conditions
                if (unitsCursable.Count > 0)
                {
                    if (unitstats.unit_flee)
                    {
                        behave = "flee";
                        behaveswitch = 10;
                    }
                    else
                    {
                        behave = "attack";
                    }
                }
                animator.SetBool("Move", false);
            }

            //chasing and fighting the enemy
            if (behave == "attack")
            {
                //state switch conditions
                if (unitstats.unit_flee)
                {
                    behave = "flee";
                    behaveswitch = 10;
                }
                else
                {
                    if (unitsCursable.Count == 0)
                    {
                        behaveswitch = 10;
                        behave = "search";
                    }
                }
            }

            //searching for enemy
            if (behave == "search")
            {
                //state switch conditions
                if (unitsCursable.Count == 0)
                {
                    behaveswitch -= Time.deltaTime;
                }
                else
                {
                    behave = "attack";
                    behaveswitch = 0;
                }
                if (behaveswitch <= 0)
                {
                    behave = "calm";
                    behaveswitch = 0;
                }

                if(target != null)
                {point = target.transform;
                target = null;
                Move();
                }
                if (agent.remainingDistance < 2.1)
                {
                    Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * 4f;
                   // point.transform.position = agent.destination;
                    Move();
                    agent.destination += randomDirection;
                }


                //if unit loses visual contact with all of enemies he tries to find them
                /*
                Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * 4f;
                randomDirection += transform.position;
                NavMeshHit hit;
                Vector3 finalPosition = Vector3.zero;
                if (NavMesh.SamplePosition(randomDirection, out hit, 4f, 1))
                {
                    finalPosition = hit.position;
                    point.transform.position = finalPosition;
                }
                
                */

            }

            //running away from visible enemy
            if (behave == "flee")
            {
                //state switch conditions
                if (unitsCursable.Count == 0)
                {
                    behaveswitch -= Time.deltaTime;
                }
                else
                {
                    if (unitstats.unit_flee)
                    {
                        if (unitstats.unit_flee)
                        {
                            behave = "flee";
                            behaveswitch = 10;
                        }
                        else
                        {
                            behave = "search";
                            behaveswitch = 10;
                        }
                    }
                    else
                    {
                        behave = "search";
                        behaveswitch = 10;
                    }
                }
                if (behaveswitch <= 0)
                {
                    behave = "calm";
                    behaveswitch = 0;
                    animator.SetBool("Move", false);
                }
            }
            //magic spells
            if (behave == "cast")
            {

            }




            //attack state
            if (behave == "attack")
            {
                //multiple targets make to choose the best of them
                if (unitsAttackable.Count == 0)
                {
                    var min = Mathf.Infinity;
                    for (int i = 0; i < cursedRange.Count; i++)
                    {
                        if (cursedRange[i] < min)
                        {
                            min = cursedRange[i];
                            target = unitsCursable[i];
                            point = unitsCursable[i].transform;
                        }
                    }
                }
                else
                {
                    //damager prefers less viable targets
                    if (unitstats.unit_class == "damager")
                    {
                        int index = minEHP.IndexOf(minEHP.Min());
                        target = unitsAttackable[index];
                    }

                    //tank prefers targets with highest dps
                    if (unitstats.unit_class == "tank")
                    {
                        int index = maxDPS.IndexOf(maxDPS.Max());
                        target = unitsAttackable[index];
                    }

                    //caster prefers targets that stay closer to others for best aoe damage
                    if (unitstats.unit_class == "caster")
                    {
                        if (bestAoE.Count == 1)
                        {
                                  target = unitsAttackable[0];
                        }
                        if (bestAoE.Count > 1)
                        {
                                  int index = bestAoE.IndexOf(bestAoE.Min());
                                   target = unitsAttackable[index];
                        }
                    }
                }
                if(Vector3.Distance(transform.position, target.transform.position) > unitstats.attack_range)
                {
                    Move();
                }
                else
                {
                    if (unitstats.attack_type == "melee")
                    { Strike();}

                    if (unitstats.attack_type == "range")
                    { Turn(); Shoot(); }

                    if (unitstats.attack_type == "magic")
                    { Turn(); Magic(); }
                }







            }




        }

    

        


        
        

        




    }

    //function help to find random point at navmesh to go there
    void RangeShot()
    {
        if (target != null)
        {
            GameObject instantiated = Instantiate(missile, shootPoint.transform.position, shootPoint.transform.rotation);
            Missile predict = instantiated.GetComponent<Missile>();
            predict.unit = this.gameObject;
            predict.target = target;
            predict.damage = UnityEngine.Random.Range(unitstats.dmg_min, unitstats.dmg_max);
            predict.damage_type = "pierce";
            predict.damage = unitstats.ar_total;
        }
    }





    /*
    void RangeDamage()
    {
        unitstats = unit.GetComponent<Character_Stats>();
        targetstats = target.GetComponent<Character_Stats>();

        unitstats.unit_attack = true;
        float dmg = UnityEngine.Random.Range(unitstats.dmg_min, unitstats.dmg_max);
        string restype = unitstats.dmg_type;
        float resscale = 0;
        if (restype == "pierce") { resscale = targetstats.respierce_total; }
        if (restype == "slice") { resscale = targetstats.resslice_total; }
        if (restype == "blund") { resscale = targetstats.resblund_total; }
        if (restype == "storm") { resscale = targetstats.resstorm_total; }
        if (restype == "fire") { resscale = targetstats.resfire_total; }
        if (restype == "earth") { resscale = targetstats.researth_total; }
        if (restype == "astral") { resscale = (targetstats.researth_total + targetstats.resfire_total + targetstats.resstorm_total) / 3; }
        if (restype == "physic") { resscale = (targetstats.respierce_total + targetstats.resslice_total + targetstats.resblund_total) / 3; }
        if (restype == "lava") { resscale = (targetstats.researth_total + targetstats.resfire_total) / 2; }
        if (restype == "acid") { resscale = (targetstats.resstorm_total + targetstats.resfire_total) / 2; }
        if (restype == "cold") { resscale = (targetstats.resstorm_total + targetstats.researth_total) / 2; }

        
        bool crit;
        bool block;
        float check = UnityEngine.Random.Range(0, 1f);
        //  Debug.Log(check);
        if (targetstats.defend_type == "block")
        {
            float blockchance = (((targetstats.def_total - unitstats.ar_total) / (1 + ((targetstats.unit_level + unitstats.unit_level) / 20))) + 30) / 100;
            if (blockchance < 0.05) { blockchance = 0.05f; }
            if (blockchance > 0.75) { blockchance = 0.75f; }
            check = UnityEngine.Random.Range(0, 1f);
            if (blockchance > check) { block = true; } else { block = false; }
            if (!block)
            {
                float critchance = (((unitstats.ar_total - targetstats.def_total) / (2 + ((unitstats.unit_level + targetstats.unit_level) / 10))) + 15) / 100;
                check = UnityEngine.Random.Range(0, 1f);
                if (critchance > check) { crit = true; } else { crit = false; }
                if (crit)
                {
                    float dmgtotal = ((dmg - targetstats.armor_total) * (1 - resscale)) * unitstats.crit_mult;
                    //Debug.Log("Crit," + dmgtotal); 
                    targetstats.hp_cur -= dmgtotal;
                }
                else
                {
                    float dmgtotal = (dmg - targetstats.armor_total) * (1 - resscale);
                    //Debug.Log("Hit," + dmgtotal); 
                    targetstats.hp_cur -= dmgtotal;
                }
            }
            if (block)
            {
                float dmgtotal = (dmg - (targetstats.armor_total + targetstats.defend_blockdmg_total)) * (1 - resscale);
                //Debug.Log("Blocked," + dmgtotal); 
                targetstats.hp_cur -= dmgtotal;
            }
        }
        if (targetstats.defend_type == "none")
        {
            float critchance = (((unitstats.ar_total - targetstats.def_total) / (2 + ((unitstats.unit_level + targetstats.unit_level) / 10))) + 15) / 100;
            check = UnityEngine.Random.Range(0, 1f);
            if (critchance > check) { crit = true; } else { crit = false; }
            if (crit)
            {
                float dmgtotal = ((dmg - targetstats.armor_total) * (1 - resscale)) * unitstats.crit_mult;
                //Debug.Log("Crit," + dmgtotal);
            }
            else
            {
                float dmgtotal = (dmg - targetstats.armor_total) * (1 - resscale);
                //Debug.Log("Hit," + dmgtotal); 
                targetstats.hp_cur -= dmgtotal;
            }
        }
        //Debug.Log(targetstats.hp_cur);
    }
    */


    void MeleeDamage()
    {
        // unitstats = unit.GetComponent<Character_Stats>();
        if (target != null) { targetstats = target.GetComponent<Character_Stats>(); }
        

        unitstats.unit_attack = true;
        float dmg = UnityEngine.Random.Range(unitstats.dmg_min, unitstats.dmg_max);
       // targetstats.hp_cur -= dmg;
        string restype = unitstats.dmg_type;
        float resscale = 0;
        if (restype == "pierce") { resscale = targetstats.respierce_total; }
        if (restype == "slice") { resscale = targetstats.resslice_total; }
        if (restype == "blund") { resscale = targetstats.resblund_total; }
        if (restype == "storm") { resscale = targetstats.resstorm_total; }
        if (restype == "fire") { resscale = targetstats.resfire_total; }
        if (restype == "earth") { resscale = targetstats.researth_total; }
        if (restype == "astral") { resscale = (targetstats.researth_total + targetstats.resfire_total + targetstats.resstorm_total) / 3; }
        if (restype == "physic") { resscale = (targetstats.respierce_total + targetstats.resslice_total + targetstats.resblund_total) / 3; }
        if (restype == "lava") { resscale = (targetstats.researth_total + targetstats.resfire_total) / 2; }
        if (restype == "acid") { resscale = (targetstats.resstorm_total + targetstats.resfire_total) / 2; }
        if (restype == "cold") { resscale = (targetstats.resstorm_total + targetstats.researth_total) / 2; }

        float hitchance = (((unitstats.ar_total - targetstats.def_total) / (1 + ((unitstats.unit_level + targetstats.unit_level) / 20))) + 50) / 100;
        if (hitchance < 0.05) { hitchance = 0.05f; }
        if (hitchance > 0.95) { hitchance = 0.95f; }
        //Debug.Log(hitchance);
        bool hit;
        bool crit;
        bool block;
        bool evade;
        float check = UnityEngine.Random.Range(0, 1f);
      //  Debug.Log(check);
        if (hitchance > check) { hit = true;} else { hit = false;}
        if (hit)
        {
          //  targetstats.hp_cur -= dmg;


            if (targetstats.defend_type == "block")
            {
                float blockchance = (((targetstats.def_total - unitstats.ar_total) / (1 + ((targetstats.unit_level + unitstats.unit_level) / 20))) + 30) / 100;
                if (blockchance < 0.05) { blockchance = 0.05f; }
                if (blockchance > 0.75) { blockchance = 0.75f; }
                check = UnityEngine.Random.Range(0, 1f);
                if (blockchance > check) { block = true; } else { block = false; }
                if (!block)
                {
                    float critchance = (((unitstats.ar_total - targetstats.def_total) / (2 + ((unitstats.unit_level + targetstats.unit_level) / 10))) + 15) / 100;
                    check = UnityEngine.Random.Range(0, 1f);
                    if (critchance > check) { crit = true; } else { crit = false; }
                    if (crit)
                    {  float dmgtotal = ((dmg - targetstats.armor_total) * (1 - resscale)) * unitstats.crit_mult;
                        //Debug.Log("Crit," + dmgtotal); 
                        targetstats.hp_cur -= dmgtotal;
                    }
                    else
                    { float dmgtotal = (dmg - targetstats.armor_total) * (1 - resscale);
                        //Debug.Log("Hit," + dmgtotal); 
                        targetstats.hp_cur -= dmgtotal;
                    }
                }
                if (block)
                { float dmgtotal = (dmg - (targetstats.armor_total+targetstats.defend_blockdmg_total)) * (1 - resscale);
                    //Debug.Log("Blocked," + dmgtotal); 
                    targetstats.hp_cur -= dmgtotal;
                }
            }
            if (targetstats.defend_type == "evade")
            {
                float evadechance = (((targetstats.def_total - unitstats.ar_total) / (2 + ((targetstats.unit_level + unitstats.unit_level) / 10))) + 15) / 100;
                if (evadechance < 0.05) { evadechance = 0.05f; }
                if (evadechance > 0.75) { evadechance = 0.75f; }
                check = UnityEngine.Random.Range(0, 1f);
                if (evadechance > check) { evade = true; } else { evade = false; }
                if (!evade)
                {
                    float critchance = (((unitstats.ar_total - targetstats.def_total) / (2 + ((unitstats.unit_level + targetstats.unit_level) / 10))) + 15) / 100;
                    //Debug.Log(critchance);
                    check = UnityEngine.Random.Range(0, 1f);
                    if (critchance > check) { crit = true; } else { crit = false; }
                    if (crit)
                    { float dmgtotal = ((dmg - targetstats.armor_total) * (1 - resscale)) * unitstats.crit_mult;
                        //Debug.Log("Crit," + dmgtotal); 
                        targetstats.hp_cur -= dmgtotal;
                    }
                    else
                    { float dmgtotal = (dmg - targetstats.armor_total) * (1 - resscale);
                        //Debug.Log("Hit," + dmgtotal); 
                        targetstats.hp_cur -= dmgtotal;
                    }
                }
                if (evade)
                {
                    //Debug.Log("Evaded");
                }
            }
            if (targetstats.defend_type == "none")
            {
                float critchance = (((unitstats.ar_total - targetstats.def_total) / (2 + ((unitstats.unit_level + targetstats.unit_level) / 10))) + 15) / 100;
                check = UnityEngine.Random.Range(0, 1f);
                if (critchance > check) { crit = true; } else { crit = false; }
                if (crit) {  float dmgtotal = ((dmg - targetstats.armor_total) * (1 - resscale)) * unitstats.crit_mult;
                    //Debug.Log("Crit," + dmgtotal); 
                }
                else
                { float dmgtotal = (dmg - targetstats.armor_total) * (1 - resscale);
                    //Debug.Log("Hit," + dmgtotal); 
                    targetstats.hp_cur -= dmgtotal;
                }
            }
             // Debug.Log(targetstats.hp_cur);
        }
        else
        {
           // Debug.Log("Not hit");
        }
    }


    public void SpellCast()
    {
        if (skill_name == "Fireball") 
        {
            GameObject instantiated = Instantiate(spell, shootPoint.transform.position, shootPoint.transform.rotation);
        }
        Debug.Log("SPELL");
    }




    public void Magic()
    {
        Turn();
        behave = "cast";
        agent.SetDestination(transform.position);
        if (target != null)
        {
            animator.SetInteger("castType", 2);
            animator.SetTrigger("Cast");
        }
        if (point != null)
        {
            animator.SetInteger("castType", 2);
            animator.SetTrigger("Cast");
        }
        unitstats.unit_spell = true;
        if(skill_type == "magic")
        {
           // SpellCast();
        }
        Debug.Log("MAGIC");

    }

    public void MagicEnd()
    {
        behave = "calm";
    }

    public void Shoot()
    {
        agent.SetDestination(transform.position);
        unitstats.unit_attack = true;
        if (target != null)
        {
            animator.SetBool("Attack", true);
        }
        if (point != null)
        {
            animator.SetBool("Attack", true);
        }
    }
    public void Strike()
    {
        agent.SetDestination(transform.position);
        unitstats.unit_attack = true;
        if (target != null)
        {
            animator.SetBool("Attack", true);
        }
        if (point != null)
        {
            animator.SetBool("Attack", true);
        }
    }

    public void Block()
    {
        unitstats.unit_block = true;
    }
    public void Hit()
    {
        unitstats.unit_hit = true;
    }
     public void Move()
    {
        if (target != null) 
        {
            animator.SetBool("Attack", false);
            agent.SetDestination(target.transform.position);
            animator.SetBool("Move", true);
        }
        if (point != null) 
        {
            animator.SetBool("Attack", false);
            animator.SetBool("Move", true);
            //patch
            if(behave != "search")
            {agent.SetDestination(point.transform.position); }
        }
    }

    public void Turn()
    {
        rotating = true;
        Vector3 targetDir = (new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z)) - transform.position;
        Vector3 forward = transform.forward;
        angle = Vector3.SignedAngle(targetDir, forward, Vector3.up);
        timer = angle / 600;
        if (timer < 0) { timer = -timer; }
        rotatetime = angle / 600;
        if (timer < 0) { timer = -timer; }
    }

    public void Death()
    {
        unitstats.unit_alive = false;
        animator.SetBool("Attack", false);
        animator.SetBool("Move", false);
        animator.SetTrigger("Die");
        unitstats.hp_cur = 0;
        Collider collider = gameObject.GetComponent<Collider>();
        collider.enabled = false;
        agent.enabled = false;
       // agent.avoidancePriority  = 0;
        target = null;
        point = null;

    }


}
