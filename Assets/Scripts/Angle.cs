using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Angle : MonoBehaviour
{
    public double angleBase;
    public double angleRange;
    public double angleFinal;
    public double vertical;
    public double hypotenuse;
    public double time;

    public float rangeX;
    public float rangeZ;
    public float rangeS;
    public float adjacent;
    public float opposite;
    
    public float gravity;
    public float speed;

    public GameObject start;
    public GameObject end;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = hypotenuse / speed;
        vertical = 10/2 * Math.Pow(time, 2);
        if(start != null && end != null) { 
        rangeX = start.transform.position.x-end.transform.position.x;
        if(rangeX<0) rangeX = -rangeX;
        rangeZ = start.transform.position.z-end.transform.position.z;
        if(rangeZ<0) rangeZ = -rangeZ;
        adjacent = Mathf.Sqrt(Mathf.Pow(rangeX,2f) + Mathf.Pow(rangeZ, 2f));
        opposite = start.transform.position.y-end.transform.position.y;
        if(opposite<0) opposite = -opposite;
        hypotenuse = Mathf.Sqrt(Mathf.Pow(adjacent, 2f) + Mathf.Pow(opposite, 2f));
        angleBase = Mathf.Tan(opposite / adjacent) *(180 / Math.PI);
        angleRange = Mathf.Tan((float)vertical / (float)hypotenuse) *(180 / Math.PI);
        angleFinal = angleBase+angleRange;
        }




        
    }
}
