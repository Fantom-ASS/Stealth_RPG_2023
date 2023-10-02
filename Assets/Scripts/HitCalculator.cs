using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCalculator : MonoBehaviour
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
        for(int i = 0; i < hitchance.Length; i++)
        {
            hitchance[i] = Mathf.Clamp(hitchance[i], 0, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (calculate)
        {
            Debug.Log(0);
            calculate = false;
            hitchance_total = 0;
            if (limbs)
            {
                for (int i = 0; i < hitchance.Length; i++)
                {
                    if (i == 0) { hitchance[i] = ((attack - defence) + 40) / 80; if (hitchance[i] < 0) { hitchance[i] = 0; } if (hitchance[i] > 1) { hitchance[i] = 1; } }
                    if (i == 1) { hitchance[i] = (((attack - defence) + 15) / 80)*3; if (hitchance[i] < 0) { hitchance[i] = 0; } if (hitchance[i] > 3) { hitchance[i] = 3; } }
                    if (i > 1) { hitchance[i] = ((attack - defence) + 35) / 80; if (hitchance[i] < 0) { hitchance[i] = 0; } if (hitchance[i] > 1) { hitchance[i] = 1; } }
                    hitchance_total += hitchance[i];
                }
                hitchance_total /= 6;
            }
            else
            {
                hitchance[0] = ((attack - defence) + 40) / 80; if(hitchance[0] < 0) { hitchance[0] = 0; } if(hitchance[0] > 1) { hitchance[0] = 1; }
                hitchance[1] = (((attack - defence) + 15) / 80) * 3; if (hitchance[1] < 0) { hitchance[1] = 0; } if(hitchance[1] > 3) { hitchance[1] = 3; }
                hitchance_total = (hitchance[0] + hitchance[1]) / 2;
            }
        }
    }

    float CalculateSum(List<float> list)
    {
        float sum = 0f;
        foreach (float number in list)
        {
            sum += number;
        }
        return sum;
    }
}
