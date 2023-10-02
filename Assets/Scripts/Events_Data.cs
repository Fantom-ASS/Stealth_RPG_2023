using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Events_Data : MonoBehaviour
{
    delegate void MyDelegate(int num);
    MyDelegate myDelegate;

    void Start()
    {
        myDelegate = PrintNum;
        myDelegate(50);

        myDelegate = DualNum;
        myDelegate(50);
    }

    private void PrintNum(int num)
    {
        Debug.Log(num);
    }
    private void DualNum(int num)
    {
        Debug.Log(num*2);
    }

}
