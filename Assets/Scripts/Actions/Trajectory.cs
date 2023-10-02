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

public class Trajectory : MonoBehaviour
{
    //ballistic properties

    public string type;
    public float vertical;
    public float hypotenuse;
    public float time;
    public float rangeX;
    public float rangeZ;
    public float wayX;
    public float wayZ;
    public float way;
    public float different;


    public float adjacent;
    public float opposite;
    public float speed;
    public float angleFinal;
    public float angleBase;
    public float angleRange;
    public float height;

    public float rotX;
    public float rotY;
    public float rotZ;

    public GameObject start;
    public GameObject end;
    public GameObject missile;

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
        rotX = this.transform.rotation.x;
        rotY = this.transform.rotation.y;
        rotZ = this.transform.rotation.z;

        pointer = GameObject.Find("Pointer");
        start = this.gameObject;
        missile = this.gameObject;
        end = pointer;
        upper = true;

        
        num = 0;
        pause = 0;
        Destroy(this.gameObject, 7);

        transform.Rotate(-45,0,0);

        rangeX = start.transform.position.x - end.transform.position.x;
        if (rangeX < 0) rangeX = -rangeX;
        rangeZ = start.transform.position.z - end.transform.position.z;
        if (rangeZ < 0) rangeZ = -rangeZ;
        adjacent = Mathf.Sqrt(Mathf.Pow(rangeX, 2f) + Mathf.Pow(rangeZ, 2f));
        opposite = start.transform.position.y - end.transform.position.y;
        height = start.transform.position.y - end.transform.position.y;
        if (opposite < 0) opposite = -opposite; upper = false;
        hypotenuse = Mathf.Sqrt(Mathf.Pow(adjacent, 2f) + Mathf.Pow(opposite, 2f));
        way = (float)hypotenuse;
        different = height / hypotenuse;
        //gameObject.transform.forward = new Vector3(1, 0, 0);
        //  closest = GameObject.FindGameObjectsWithTag("Unit").ToList();









    }

    // Update is called once per frame
    void Update()
    {
        
        if (count)
        {
            rangeX = start.transform.position.x - end.transform.position.x;
            if (rangeX < 0) rangeX = -rangeX;
            rangeZ = start.transform.position.z - end.transform.position.z;
            if (rangeZ < 0) rangeZ = -rangeZ;
            adjacent = Mathf.Sqrt(Mathf.Pow(rangeX, 2f) + Mathf.Pow(rangeZ, 2f));
            opposite = start.transform.position.y - end.transform.position.y;
            height = start.transform.position.y - end.transform.position.y;
            if (opposite < 0) opposite = -opposite; upper = false;
            hypotenuse = Mathf.Sqrt(Mathf.Pow(adjacent, 2f) + Mathf.Pow(opposite, 2f));

            time = way/speed;
            vertical = 50 * (float)Math.Pow(time, 2);


         //   way = (((speed * (opposite / hypotenuse)) + Mathf.Pow(speed * (opposite / hypotenuse), 2f) + 2 * 10 * height) / 10) * ((adjacent / hypotenuse) * speed);



        //    angleBase = (float)Mathf.Tan(opposite / adjacent) * (180 / (float)Math.PI);
        //   angleRange = (float)Mathf.Tan((float)vertical / (float)hypotenuse) * (180 / (float)Math.PI);
        //    angleFinal = ((float)angleBase + (float)angleRange)*5;
        //    count = false;



        }





        rotate = 135f*0.636f;
        pause -= Time.deltaTime;

        //movement
        if (pause <= 0)
        transform.position += transform.forward * Time.deltaTime * speed;


      //  transform.rotation = Quaternion.Euler(transform.rotation.x+(10*Time.deltaTime), transform.rotation.y, transform.rotation.z);

        if (this.transform.rotation.x < 45)
        { transform.Rotate((rotate*Time.deltaTime)/time, 0, 0); }
        

       
        // transform.Rotate(10 * Time.deltaTime, 0, 0);

        //transform.position += transform.up * Time.deltaTime * movementSpeed;
        // transform.rotation = Quaternion.Euler(transform.rotation.x+rotate, transform.rotation.y, transform.rotation.z);



        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, 0.1f))
        {
            //pause = 0.2f;
            if (hit.transform.gameObject.layer == 8) {
                
                //riñochet
                if (bounce > 0)
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
                            


                         //   pause = 0.01f;
                         //   transform.rotation = Quaternion.Euler(0,0,0);
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
                







            }
            Debug.Log(hit.transform.gameObject.name);

             if (bounce == 0 && type == "bounce") { Destroy(this.gameObject); }

        }





    }
}
