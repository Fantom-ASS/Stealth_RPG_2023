using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Event_Guide : MonoBehaviour
{
   public  delegate void Shout();
   public static event Shout Heared;

    public int ass;
     void Cry()
    {
        if(Heared != null) { Heared(); }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Cry();
        }
    }


}
