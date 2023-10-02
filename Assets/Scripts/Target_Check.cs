using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Check : MonoBehaviour
{
    //target flags
    public bool self;
    public bool enemy;
    public bool friend;
    public bool neutral;
    public bool corpse;
    public bool undead;
    public bool organic;

    public GameObject caster;
    public GameObject target;
    public Character_Stats stats_tgt;
    public Character_Stats stats_cst;


    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
              //  Debug.Log(hit.transform.gameObject.name);
              if(hit.transform.gameObject.name != null && hit.transform.gameObject.layer == 8)
                {
                    target = hit.transform.gameObject;
                    stats_tgt = target.GetComponent<Character_Stats>();

                    if(stats_tgt.unit_clan == 0) {friend = true;}
                    if (stats_tgt.unit_clan == 1) {neutral = true;}
                    if (stats_tgt.unit_clan == 2) {enemy = true;}
                    if (caster == target) {self = true;}
                    if (!stats_tgt.unit_alive) {corpse = true;}
                    if (stats_tgt.unit_organic) {organic = true;}

                    Debug.Log(stats_tgt.unit_name);
                    if(self) { Debug.Log("self"); } else { Debug.Log("not self"); }
                    if (enemy) { Debug.Log("enemy"); }
                    if (friend) { Debug.Log("friend"); }
                    if (neutral) { Debug.Log("neutral"); }
                    if (undead) { Debug.Log("undead"); } else { Debug.Log("living"); }
                    if (organic) { Debug.Log("organic"); } else { Debug.Log("mechanic"); }
                    if (corpse) { Debug.Log("corpse"); } else { Debug.Log("alive"); }

                    friend = false;
                    neutral = false;
                    enemy = false;
                    self = false;
                    corpse = false;
                    organic = false;

                    stats_cst = null;
                    target = null;
                }


            }






        }






    }


}
