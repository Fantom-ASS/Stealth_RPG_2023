using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalDPS : MonoBehaviour
{
    public int boost;
    public int abiBonus;
    public float dpsBonus;
    public float summ;
    public float cd;
    public float mana;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        summ = (1 + ((float)boost / 10) + ((float)abiBonus / 100)) * dpsBonus;
        if(active ) { mana = (summ*cd)/10; }
    }
}
