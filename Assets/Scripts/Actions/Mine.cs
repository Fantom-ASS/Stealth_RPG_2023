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
using UnityEngine.XR;
using static UnityEditor.Progress;
using static UnityEngine.GraphicsBuffer;

public class Mine : MonoBehaviour
{
    //ballistic properties

    public string type;
    public float time;
    public float speed;
    public bool active;

    public GameObject start;
    public GameObject end;

    //terminal properties
    public Character_Stats stats;
    public List<GameObject> targets;
    public List<GameObject> units;
    public List<GameObject> matching;
    public int num;
    public float pause;
    public float rotate;
    public int bounce;
    public int blast;
    public float aoe;
    public GameObject pointer;
    public bool count;
    public bool upper;


    // Start is called before the first frame update
    void Start()
    {
        pointer = GameObject.Find("Pointer");
        start = this.gameObject;
        end = pointer;
        upper = true;
        active = true;

        
        num = 0;
        pause = 0;
        Destroy(this.gameObject, 7);

        //gameObject.transform.forward = new Vector3(1, 0, 0);
        //  closest = GameObject.FindGameObjectsWithTag("Unit").ToList();

        


        




    }

    // Update is called once per frame
    void Update()
    {
        //movement
        if (pause <= 0)
        transform.position -= transform.up * Time.deltaTime * speed;



       
        // transform.Rotate(10 * Time.deltaTime, 0, 0);

        //transform.position += transform.up * Time.deltaTime * movementSpeed;
        // transform.rotation = Quaternion.Euler(transform.rotation.x+rotate, transform.rotation.y, transform.rotation.z);



        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(-Vector3.up);

        if (Physics.Raycast(transform.position, fwd, out hit, 0.1f) && active == true)
        {


            //pause = 0.2f;
            if (hit.transform.gameObject.layer == 6)
            {
                Debug.Log(hit.transform.gameObject);

                active = false;

                //riñochet
                if (aoe > 0)
                {
                    units = GameObject.FindGameObjectsWithTag("Unit").ToList();
                    if (targets.Count < 1)
                    {
                        GameObject hitobject = hit.transform.gameObject;
                        targets.Add(hit.transform.gameObject);
                        bounce--;
                        int j = 0;
                        int penalty = 0;
                        for (int i = 0; i < units.Count - penalty; i++)
                        {

                            if ((Vector3.Distance(units[i].transform.position, transform.position) < aoe))
                            {
                                matching.Add(units[i]);
                            }
                        }
                        for (int i = 0; i < units.Count - penalty; i++)
                        {
                            if (hitobject == matching[i])
                                matching.RemoveAt(i);
                            //stop to change direction
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
                            bounce--;
                            num += 1;
                        }
                    }
                }
            }
            //  Debug.Log(hit.transform.gameObject.name);

            if (bounce == 0 && type == "bounce") { Destroy(this.gameObject); }

        }





    }
}
