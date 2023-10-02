using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EffectTest : MonoBehaviour
{
    public EffectTarget target;
    public int clan;
    public int stuck;
    public string buff;
    public float effect;
    public float duration;
    public float effect_max;
    public float effect_min;

    private void Update()
    {
        //Debug.Log(target.effect[22, 0]); 
        if (Input.GetKeyDown(KeyCode.A))
        {
            int randomInt = UnityEngine.Random.Range(0, 4);
            if (randomInt == 1) { buff = "strengthen"; }
            if (randomInt == 2) { buff = "haste"; }
            if (randomInt == 3) { buff = "life"; }
            effect = UnityEngine.Random.Range(effect_min, effect_max);
            //row - це ефекти різних типів, а column - їхня кількість
            int rows = target.effect.GetLength(0);
            int cols = target.effect.GetLength(1);
            for (int row = 0; row < rows; row++) //checking the whole list of different buffs
            {
                for (int col = 0; col < cols; col++) //checking the dimension of same buffs
                {
                    if(row == 22 && buff == "strengthen") //blessing buff
                    { if (target.effect[row, cols-1] == 0) //if array of buffs if this type is not filled, we can add a new one
                        { if (target.effect[row, col] == 0) 
                            { Vector2 result = Checker(row, rows, col, cols);
                                if (target.effect[row, stuck] == 0) { target.damage += (effect / 100); } else  { target.damage += result.y - result.x; }
                                break; 
                            } else { continue; }
                        }
                    }
                    if (row == 23 && buff == "haste") //blessing buff
                    { if (target.effect[row, cols - 1] == 0) //if array of buffs if this type is not filled, we can add a new one
                        { if (target.effect[row, col] == 0)
                            { Vector2 result = Checker(row, rows, col, cols);
                                if (target.effect[row, stuck] == 0) { target.speed += (effect / 100); } else { target.speed += result.y - result.x; }
                                break;
                            }else { continue; }
                        }
                    }
                    if (row == 24 && buff == "life") //blessing buff
                    { if (target.effect[row, cols - 1] == 0) //if array of buffs if this type is not filled, we can add a new one
                        { if (target.effect[row, col] == 0)
                            { Vector2 result = Checker(row, rows, col, cols);
                                if (target.effect[row, stuck] == 0) { target.max_hp += (effect / 100); } else { target.max_hp += result.y - result.x; } //changing effect according to input data
                                break;
                            } else { continue; }
                        }
                    }








                }
            }

        }
    }

    void AddBuff()
    {
        target.buffName.Add(buff);
        target.buffStuck.Add(stuck);
        target.buffEffect.Add(effect);
        target.buffTime.Add(duration);
    }

    Vector2 Checker(int row, int rows, int col, int cols)
    {
        Debug.Log("row: " + row + " rows: " + rows + " col: " + col + " cols: " + cols);
        float oldSum = 0;
        float newSum = 0;
        for (int i = 0; i < stuck; i++) { oldSum += target.effect[row, i]; }//checking top old strongest effect
        target.effect[row, col] = effect / 100; //putting new effect into array
        AddBuff(); //adding a new buff to list
        float[] targetArray = new float[cols]; //creating a new array to sort values of 2nd dimension
        for (int j = 0; j < cols; j++) { targetArray[j] = target.effect[row, j]; } //filling new array with values of effect
        System.Array.Sort(targetArray, (a, b) => b.CompareTo(a)); //sorting
        for (int j = 0; j < cols; j++) { target.effect[row, j] = targetArray[j]; } //refilling out 2-dimensional array with new values
        for (int i = 0; i < stuck; i++) { newSum += target.effect[row, i]; }//checking top new strongest effect
        Vector2 result = new Vector2(oldSum,newSum); //result.x is out oldSum, result.y - newSum
        return result;
    }

}
