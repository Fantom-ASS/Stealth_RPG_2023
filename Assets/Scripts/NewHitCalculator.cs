using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHitCalculator : MonoBehaviour
{
    public float attack;
    public float defence;
    public bool limbs;
    public float[] hitchance = new float[6]; //0 - body, 1 -  head, 2-6 - limbs
    public float hitchance_total;
    public bool calculate;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (calculate)
        {
            calculate = false;
            hitchance_total = 0;
            
            if (limbs)
            {
                for (int i = 0; i < hitchance.Length; i++)
                {
                    if (i == 0) { hitchance[i] = (((attack - defence) / 2) + 75) / 100; }
                    if (i == 1) { hitchance[i] = (((attack - defence) / 2) + 25) / 100; }
                    if (i > 1) { hitchance[i] = (((attack - defence)/2) + 50) / 100; }
                    
                }
                
            }else{

                for (int i = 0; i < hitchance.Length; i++)
                {
                    if (i == 0) { hitchance[i] = ((attack - defence) + 75) / 100; }
                    if (i == 1) { hitchance[i] = ((attack - defence) + 25) / 100; }
                }
                
            }
            for (int j = 0; j < hitchance.Length; j++)
            {
                hitchance[j] = Mathf.Clamp(hitchance[j], 0, 1);
                hitchance_total += hitchance[j];
            }
            if (limbs) { hitchance_total /= 6; } else { hitchance_total = (hitchance[0] + hitchance[1]) / 2; }


        }
    }
}
