using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ret : MonoBehaviour
{
    // Start is called before the first frame update
    public int state;
    void Start()
    {
        if(state == 3)
        {
            Debug.Log("NONE");
            return;
        }
        Debug.Log(state);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
