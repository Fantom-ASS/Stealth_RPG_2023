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

public class Ground : MonoBehaviour
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
    public float landRange;

    public GameObject start;
    public GameObject end;
    public Vector3 rayHit;

    //terminal properties
    public Character_Stats stats;
    public Transform shooter;
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
    public GameObject[] foundObjects;
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

        
        num = 0;
        pause = 0;
        Destroy(this.gameObject, 7);

        //gameObject.transform.forward = new Vector3(1, 0, 0);
        //  closest = GameObject.FindGameObjectsWithTag("Unit").ToList();



        transform.Rotate(-transform.rotation.x, 0, 0);



    }

    // Update is called once per frame
    void Update()
    {
        
     //   pause -= Time.deltaTime;

        //movement
        if (pause <= 0)
        transform.position += transform.forward * Time.deltaTime * speed;


        transform.Rotate(-transform.rotation.x, 0, 0);


        // transform.Rotate(10 * Time.deltaTime, 0, 0);

        //transform.position += transform.up * Time.deltaTime * movementSpeed;
        // transform.rotation = Quaternion.Euler(transform.rotation.x+rotate, transform.rotation.y, transform.rotation.z);



        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(-Vector3.up);

        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            //pause = 0.2f;
            if (hit.transform.gameObject.layer == 6) {


                rayHit = hit.point;
              //  landRange = Vector3.Distance(transform.position, hit.transform.position);
                transform.position = new Vector3(transform.position.x, rayHit.y+0.1f, transform.position.z);



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
                        int j=0;
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
                        //    transform.LookAt(matching[0].transform.position);
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
                        //    transform.LookAt(matching[num].transform.position);
                        }
                    }
                }



                /*
                //riñochet
                if (bounce > 0&& type == "bounce")
                {
                    units = GameObject.FindGameObjectsWithTag("Unit").ToList();
                    if (targets.Count < 1)
                    {
                        GameObject hitobject = hit.transform.gameObject;
                        targets.Add(hit.transform.gameObject);
                        bounce--;
                        int j = 0;
                        for (int i = 0; i < units.Count; i++)
                        {

                            if ((Vector3.Distance(units[i].transform.position, transform.position) < 15f))
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
                            transform.rotation = Quaternion.Euler(0,0,0);
                            Debug.Log(bounce);
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
                            pause = 0.01f;
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                            Debug.Log(bounce);
                        }
                    }
                }
                */







            }
            Debug.Log(hit.transform.gameObject.name);



              if(pierce == 0 && type == "pierce") { Destroy(this.gameObject);}
              if(chain == 0 && type == "chain")  { Destroy(this.gameObject);}
             if (bounce == 0 && type == "bounce") { Destroy(this.gameObject); }

        }





    }
}
