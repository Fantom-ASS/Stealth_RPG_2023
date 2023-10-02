using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NoiseSource : MonoBehaviour
{
    public float radius;
    //public float range;
    public int clan;
    List<GameObject> unitsNear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha9)) { Noise(); }
        //Debug.Log("NOISE");
        //range = Mathf.Clamp(range,0,radius);
        //if(range > 0) { range -= Time.deltaTime * 10; }
           
    }

    void Noise()
    {
        //if (unitsNear.Count > 0) { unitsNear.Clear(); }
        float range = radius;
        List<GameObject> unitsAll = GameObject.FindGameObjectsWithTag("unit").ToList();
        //List<GameObject> unitsNear = null;
        Debug.Log("unitsAll "+ unitsAll.Count);

        for (int i = 0; i < unitsAll.Count; i++)
        {
            if(Vector3.Distance(transform.position, unitsAll[i].transform.position) <= range)  
            {
                UnitData unitdata = unitsAll[i].GetComponent<UnitData>();
                if (clan != unitdata.clan && unitdata.unitstate != "FightState" && unitdata.alive) //if chosen unit is hostile
                {
                    if (unitdata.alert == false)  //if unit was calm runs to the noise source to check it
                    {
                        unitdata.alert = true; unitdata.point = transform; unitdata.agent.SetDestination(unitdata.point.transform.position);
                        Debug.Log(unitsAll[i].name + " is alerted!"); unitdata.Alert();
                    }
                    else
                    {
                        Debug.Log(unitsAll[i].name + " was already alerted!");
                        unitdata.alert = true; unitdata.point = transform; unitdata.agent.SetDestination(unitdata.point.transform.position); unitdata.Alert();
                    }
                }
            }
        }


    }

}
