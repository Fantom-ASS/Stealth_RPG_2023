using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public bool turnstart;
    public bool turning;
    public float rotator;
    public float rotateleft;
    public bool positive;
    public float timecount;
    public Quaternion rot;
    public float stop;
    public Transform clickPosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (turnstart) //trigger to start turning
        {
            Transform change;
            turnstart = false;
            timecount = 0;
            turning = true;
            System.Random rng = new System.Random();
            rotator = rng.Next(0, 360);
            rot = Quaternion.Euler(0, rotator, 0);
            rotateleft = rotator;
            if(rotateleft >= 0) { positive = true; } else { positive = false; }
        }
        
        if(turning) //trigger to continue and end turning. Lasts near 0.4 seconds
        { 
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, 1*timecount);
            timecount = timecount + Time.deltaTime;
            if(timecount > stop) 
            { 
                turning= false; 
                timecount = 0; 
                rotator = 0; 
                rotateleft = 0;
            }
        } else { timecount = 0; }
        

    }
}
