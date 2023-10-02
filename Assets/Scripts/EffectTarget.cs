using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EffectTarget : MonoBehaviour
{
    public float max_hp;
    public float cur_hp;
    public float regen_hp;
    public float damage;
    public float attack;
    public float defence;
    public float speed;
    public float vision;
    public float armor;

    public List<string> buffName;
    public List<float> buffTime;
    public List<float> buffEffect;
    public List<int> buffStuck;
    public List<float> maxEffects;
    //public float sixth;
    //public List<float> buff = new List<float>();
    public float[,] effect = new float[68,16];
    public float[] experiment = new float[16];

    // Start is called before the first frame update
    void Start()
    {

        //checking array of buff effects
        int rows = effect.GetLength(0);
        int cols = effect.GetLength(1);
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++) {
               // if (row == 22) { effect[row, col] = Random.Range(0.0f, 10.0f); } //row - це одні й ті самі ефекти, а column - їхня кількість
                //Debug.Log("Value at (" + row + ", " + col + "): " + effect[row, col]);
                //if(effect[row, col] != 0) { Debug.Log("Value at (" + row + ", " + col + "): " + effect[row, col]); }
            }    
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (buffName != null) 
        { 
        for(int i = 0; i < buffName.Count; i++)
            {
                if (buffTime[i] > 0) { buffTime[i] -= Time.deltaTime; } //after time runs out we check how the value will be changed
                else 
                {
                    if (buffName[i] == "strengthen") //algorithm for strengthen effect
                    {
                        for (int j = 0; j < 16; j++) 
                        {
                            if ((buffEffect[i] / 100) - effect[22, j] < 0.0000001f && (buffEffect[i] / 100) - effect[22, j] > -0.0000001f) //if array effect is similar to list, it's what we need
                            {
                                float oldEff1 = effect[22, j];
                                effect[22, j] = 0; //zeroing the expired effect and resorting the array
                                float[] targetArray = new float[16]; //creating a new array to sort values of 2nd dimension
                                for (int k = 0; k < 16; k++) { targetArray[k] = effect[22, k]; } //filling new array with values of effect
                                System.Array.Sort(targetArray, (a, b) => b.CompareTo(a)); //sorting
                                for (int k = 0; k < 16; k++) { effect[22, k] = targetArray[k]; } //refilling out 2-dimensional array with new values
                                float newEff1 = effect[22, buffStuck[i] - 1];  
                                if (effect[22, buffStuck[i]-1] == 0) { damage -= (buffEffect[i] / 100); } else 
                                { if (j < buffStuck[i]) { damage -= (buffEffect[i] / 100); damage += newEff1;} }
                                break;
                            } else { continue; }
                        }
                    }
                    if (buffName[i] == "haste") //algorithm for strengthen effect
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            if ((buffEffect[i] / 100) - effect[23, j] < 0.0000001f && (buffEffect[i] / 100) - effect[23, j] > -0.0000001f) //if array effect is similar to list, it's what we need
                            {
                                float oldEff1 = effect[23, j];
                                effect[23, j] = 0; //zeroing the expired effect and resorting the array
                                float[] targetArray = new float[16]; //creating a new array to sort values of 2nd dimension
                                for (int k = 0; k < 16; k++) { targetArray[k] = effect[23, k]; } //filling new array with values of effect
                                System.Array.Sort(targetArray, (a, b) => b.CompareTo(a)); //sorting
                                for (int k = 0; k < 16; k++) { effect[23, k] = targetArray[k]; } //refilling out 2-dimensional array with new values
                                float newEff1 = effect[23, buffStuck[i] - 1];
                                if (effect[23, buffStuck[i] - 1] == 0) { speed -= (buffEffect[i] / 100); }
                                else
                                { if (j < buffStuck[i]) { speed -= (buffEffect[i] / 100); speed += newEff1; } }
                                break;
                            }
                            else { continue; }
                        }
                    }
                    if (buffName[i] == "life") //algorithm for strengthen effect
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            if ((buffEffect[i] / 100) - effect[24, j] < 0.0000001f && (buffEffect[i] / 100) - effect[24, j] > -0.0000001f) //if array effect is similar to list, it's what we need
                            {
                                float oldEff1 = effect[24, j];
                                effect[24, j] = 0; //zeroing the expired effect and resorting the array
                                float[] targetArray = new float[16]; //creating a new array to sort values of 2nd dimension
                                for (int k = 0; k < 16; k++) { targetArray[k] = effect[24, k]; } //filling new array with values of effect
                                System.Array.Sort(targetArray, (a, b) => b.CompareTo(a)); //sorting
                                for (int k = 0; k < 16; k++) { effect[24, k] = targetArray[k]; } //refilling out 2-dimensional array with new values
                                float newEff1 = effect[24, buffStuck[i] - 1];
                                if (effect[24, buffStuck[i] - 1] == 0) { max_hp -= (buffEffect[i] / 100); }
                                else
                                { if (j < buffStuck[i]) { max_hp -= (buffEffect[i] / 100); max_hp += newEff1; } }
                                break;
                            }
                            else { continue; }
                        }
                    }






                    buffName.Remove(buffName[i]);
                    buffTime.Remove(buffTime[i]);
                    buffEffect.Remove(buffEffect[i]);
                    buffStuck.Remove(buffStuck[i]);
                }
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
