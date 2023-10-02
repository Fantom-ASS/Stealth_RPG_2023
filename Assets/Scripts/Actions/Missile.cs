using JetBrains.Annotations;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using UnityEngine.XR;
using static UnityEditor.Progress;
using static UnityEngine.GraphicsBuffer;

public class Missile : MonoBehaviour
{
    //ballistic properties

    public string type;
    public float vertical;
    public float hypotenuse;
    public float time;
    public float rangeX;
    public float rangeZ;
    public float adjacent;
    public float opposite;
    public float speed;
    public float angleFinal;
    public float angleBase;
    public float angleRange;

    //missile characteristics
    public float damage;
    public string damage_type;
    public string attack;
    public float clan;


    public GameObject Marker;
    public GameObject start;
    public GameObject end;

    public GameObject target;
    public GameObject unit;

    //terminal properties
    public Character_Stats statsShooter;
    public Character_Stats statsTarget;
    public Transform shooter;
    public Transform destination;
    public float destRange;


    public List<GameObject> targets;
    public List<GameObject> units;
    public List<GameObject> matching;
    public List<float> distance;
    public int num;
    public float pause;
    public float rotate;
    public int pierce;
    public int chain;
    public int bounce;
    public int blast;
    public float aoe;
    public float range;
    public GameObject pointer;
    public bool count;
    public bool upper;
    public bool deflect;


    // Start is called before the first frame update
    void Start()
    {
        statsShooter = unit.GetComponent<Character_Stats>();
        statsTarget = target.GetComponent<Character_Stats>();


        pointer = GameObject.Find("Pointer");
        start = this.gameObject;
        end = pointer;
        upper = true; num = 0;
        pause = 0;
        Destroy(this.gameObject, 7);  if (count)
        {
            rangeX = start.transform.position.x - end.transform.position.x;
            if (rangeX < 0) rangeX = -rangeX;
            rangeZ = start.transform.position.z - end.transform.position.z;
            if (rangeZ < 0) rangeZ = -rangeZ;
            adjacent = Mathf.Sqrt(Mathf.Pow(rangeX, 2f) + Mathf.Pow(rangeZ, 2f));
            opposite = start.transform.position.y - end.transform.position.y;
            if (opposite < 0) opposite = -opposite; upper = false;
            hypotenuse = Mathf.Sqrt(Mathf.Pow(adjacent, 2f) + Mathf.Pow(opposite, 2f));
            time = hypotenuse / speed;
            vertical = 50 * (float)Math.Pow(time, 2);
            angleBase = (float)Mathf.Tan(opposite / adjacent) * (180 / (float)Math.PI);
            angleRange = (float)Mathf.Tan((float)vertical / (float)hypotenuse) * (180 / (float)Math.PI);
            angleFinal = (float)angleBase + (float)angleRange;
            count = false;
        }

        if (deflect && target != null)
        {
            NavMeshAgent nmagent = target.GetComponent<NavMeshAgent>();
            NavMeshPath nmpath = nmagent.path;
            float magnitude = nmagent.velocity.magnitude / nmagent.speed;
            float tgtrange = hypotenuse;
            float prediction = time * nmagent.speed;
            Vector3 destination = nmagent.destination - target.transform.position;
            float destrange = Vector3.Distance(nmagent.destination,target.transform.position);
            float desttime = destrange / nmagent.speed;
            //Debug.Log(nmagent.velocity.magnitude);
            Instantiate(Marker, (end.transform.position + (destination * (time / desttime)))*magnitude, start.transform.rotation);
            transform.LookAt(end.transform.position + ((destination * (time / desttime))*magnitude));

        }
    }

    // Update is called once per frame
    void Update()
    {
        rotate += (float)vertical*Time.deltaTime;
        pause -= Time.deltaTime;
        //movement
        if (pause <= 0)
        transform.position += transform.forward * Time.deltaTime * speed;
        transform.Rotate(rotate / 10 * Time.deltaTime, 0, 0);
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, 0.1f))
        {
            //pause = 0.2f;
            if (hit.transform.gameObject.layer == 8) {

                Character_Stats cs = hit.transform.GetComponent<Character_Stats>();
                if(cs.unit_clan != statsShooter.unit_clan) { RangeDamage(); }
                //piercing
                if (pierce > 0 && type == "pierce")
                {
                    if (targets.Count < 1)
                    {
                        targets.Add(hit.transform.gameObject);
                        pierce--;
                    }
                    if (targets.Count >= 1)
                    {
                        targets.Add(hit.transform.gameObject);
                        GameObject same = targets[targets.Count - 1];
                        if (targets[targets.Count - 2] == same)
                        {
                            targets.Remove(targets.Last());
                        }
                        else
                        {
                            pierce--;
                        }
                    }
                }
                //chaining
                if (chain > 0 && type == "chain")
                {
                    units = GameObject.FindGameObjectsWithTag("Unit").ToList();
                    if (targets.Count < 1)
                    {
                        GameObject hitobject = hit.transform.gameObject;
                        targets.Add(hit.transform.gameObject);
                        chain--;
                        for (int i = 0; i < units.Count; i++)
                        {
                            
                            if ((Vector3.Distance(units[i].transform.position, transform.position) < aoe))
                            {
                                matching.Add(units[i]);
                            }
                        }
                        for (int i = 0; i < units.Count; i++)
                        {
                            if (hitobject == matching[i]) 
                                matching.RemoveAt(i);
                            //stop to change direction
                            
                            pause = 0.01f;
                            transform.LookAt(matching[0].transform.position);
                        }
                    }
                    if (targets.Count >= 1)
                    {
                        targets.Add(hit.transform.gameObject);
                        GameObject same = targets[targets.Count - 1];
                        if (targets[targets.Count - 2] == same)
                        {
                            targets.Remove(targets.Last());
                        }
                        else
                        {
                            chain--;
                            num += 1;
                            pause = 0.01f;
                            transform.LookAt(matching[num].transform.position);
                        }
                    }
                }
                


            }

              if(pierce == 0 && type == "pierce") { Destroy(this.gameObject);}
              if(chain == 0 && type == "chain")  { Destroy(this.gameObject);}
             if (bounce == 0 && type == "bounce") { Destroy(this.gameObject); }

        }

        void RangeDamage()
        {
            statsShooter = unit.GetComponent<Character_Stats>();
            statsTarget = target.GetComponent<Character_Stats>();

            statsShooter.unit_attack = true;
            float dmg = UnityEngine.Random.Range(statsShooter.dmg_min, statsShooter.dmg_max);
            string restype = statsShooter.dmg_type;
            float resscale = 0;
            if (restype == "pierce") { resscale = statsTarget.respierce_total; }
            if (restype == "slice") { resscale = statsTarget.resslice_total; }
            if (restype == "blund") { resscale = statsTarget.resblund_total; }
            if (restype == "storm") { resscale = statsTarget.resstorm_total; }
            if (restype == "fire") { resscale = statsTarget.resfire_total; }
            if (restype == "earth") { resscale = statsTarget.researth_total; }
            if (restype == "astral") { resscale = (statsTarget.researth_total + statsTarget.resfire_total + statsTarget.resstorm_total) / 3; }
            if (restype == "physic") { resscale = (statsTarget.respierce_total + statsTarget.resslice_total + statsTarget.resblund_total) / 3; }
            if (restype == "lava") { resscale = (statsTarget.researth_total + statsTarget.resfire_total) / 2; }
            if (restype == "acid") { resscale = (statsTarget.resstorm_total + statsTarget.resfire_total) / 2; }
            if (restype == "cold") { resscale = (statsTarget.resstorm_total + statsTarget.researth_total) / 2; }


            bool crit;
            bool block;
            float check = UnityEngine.Random.Range(0, 1f);
            //  Debug.Log(check);
            if (statsTarget.defend_type == "block")
            {
                float blockchance = (((statsTarget.def_total - statsShooter.ar_total) / (1 + ((statsTarget.unit_level + statsShooter.unit_level) / 20))) + 30) / 100;
                if (blockchance < 0.05) { blockchance = 0.05f; }
                if (blockchance > 0.75) { blockchance = 0.75f; }
                check = UnityEngine.Random.Range(0, 1f);
                if (blockchance > check) { block = true; } else { block = false; }
                if (!block)
                {
                    float critchance = (((statsShooter.ar_total - statsShooter.def_total) / (2 + ((statsShooter.unit_level + statsShooter.unit_level) / 10))) + 15) / 100;
                    check = UnityEngine.Random.Range(0, 1f);
                    if (critchance > check) { crit = true; } else { crit = false; }
                    if (crit)
                    {
                        float dmgtotal = ((dmg - statsTarget.armor_total) * (1 - resscale)) * statsShooter.crit_mult;
                        //Debug.Log("Crit," + dmgtotal); 
                        statsTarget.hp_cur -= dmgtotal;
                    }
                    else
                    {
                        float dmgtotal = (dmg - statsTarget.armor_total) * (1 - resscale);
                        //Debug.Log("Hit," + dmgtotal); 
                        statsTarget.hp_cur -= dmgtotal;
                    }
                }
                if (block)
                {
                    float dmgtotal = (dmg - (statsTarget.armor_total + statsTarget.defend_blockdmg_total)) * (1 - resscale);
                    //Debug.Log("Blocked," + dmgtotal); 
                    statsTarget.hp_cur -= dmgtotal;
                }
            }
            if (statsTarget.defend_type == "none")
            {
                float critchance = (((statsShooter.ar_total - statsTarget.def_total) / (2 + ((statsShooter.unit_level + statsTarget.unit_level) / 10))) + 15) / 100;
                check = UnityEngine.Random.Range(0, 1f);
                if (critchance > check) { crit = true; } else { crit = false; }
                if (crit)
                {
                    float dmgtotal = ((dmg - statsTarget.armor_total) * (1 - resscale)) * statsShooter.crit_mult;
                    //Debug.Log("Crit," + dmgtotal);
                }
                else
                {
                    float dmgtotal = (dmg - statsTarget.armor_total) * (1 - resscale);
                    //Debug.Log("Hit," + dmgtotal); 
                    statsTarget.hp_cur -= dmgtotal;
                }
            }
            //Debug.Log(targetstats.hp_cur);
        }






    }
}
