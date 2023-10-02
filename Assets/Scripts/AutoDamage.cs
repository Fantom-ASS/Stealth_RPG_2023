using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AutoDamage : MonoBehaviour
{
    public bool active;
    public UnitData udata;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        udata = GetComponent<UnitData>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha8)) { active = true; }
            



        if (active)
        {
            active = false;
            if (udata.bodytype <= 2) { udata.bodyparts_health_display[0] -= damage / 4; udata.bodyparts_health_display[1] -= damage / 4; udata.bodyparts_health_display[2] -= damage / 4; udata.bodyparts_health_display[3] -= damage / 4; udata.bodyparts_health_display[4] -= damage / 4; udata.bodyparts_health_display[5] -= damage / 4; }
            if (udata.bodytype == 3) { udata.bodyparts_health_display[0] -= damage; udata.bodyparts_health_display[1] -= damage; }
            if (udata.bodytype == 4) { udata.bodyparts_health_display[0] -= damage * 2; }
        }
    }
}
