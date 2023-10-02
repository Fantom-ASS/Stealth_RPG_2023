using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int[,] typestd = new int[3,5];
    public int[] lvl_free = new int[3];


    // Start is called before the first frame update
    void Start()
    {
        typestd[0,4] = 1;
        Debug.Log(typestd[0,4]);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
