using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events_Multicast : MonoBehaviour
{
    delegate void MyMultiDelegate();
    MyMultiDelegate myDelegate;
    [Range(0,100)] public float percent;

    void Start()
    {
        percent = 100;
        myDelegate += PowerUp;
        myDelegate += TurnRed;
       // myDelegate();
        Event_Guide.Heared += PowerUp;
        Event_Guide.Heared += TurnRed;
    }

    // Update is called once per frame
    private void PowerUp()
    {
        Debug.Log("power");
        
    }
    private void TurnRed()
    {
        Debug.Log("red");
    }
    private void Update()
    {
      //  percent -= Time.deltaTime*10;
    }
}
