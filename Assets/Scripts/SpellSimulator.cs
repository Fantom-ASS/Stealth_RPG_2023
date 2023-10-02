using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpellSimulator : MonoBehaviour
{

    public string spellL;
    public string spellR;

    public string spell1;
    public string spell2;
    public string spell3;
    public string ultimate;

    public float cdR;
    public float cd1;
    public float cd2;
    public float cd3;

    public float mpR;
    public float mp1;
    public float mp2;
    public float mp3;

    public int cur;

    public float mana;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (mana >= mp1 && cd1 == 0)
            {
                cur = 1;
            }
            else
            {
                Debug.Log("spell 1 not ready");
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (mana >= mp2 && cd2 == 0)
            {
                cur = 2;
            }
            else
            {
                Debug.Log("spell 2 not ready");
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (mana >= mp3 && cd3 == 0)
            {
                cur = 3;
            }
            else
            {
                Debug.Log("spell 3 not ready");
            }
        }




        if (Input.GetMouseButtonDown(1))
        {
            if(cur == 0) { 
                if(mana >= mpR && cdR == 0)
                {
                    Debug.Log(spellR);
                    cdR += 1;
                    mana -= 3;
                }
                else
                {
                    Debug.Log("RMB spell not ready");
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (cur == 0)
            {
                if (mana >= mpR && cdR == 0)
                {
                    Debug.Log(spellL);
                }
            }
            if (cur == 1)
            {
                if (mana >= mp1 && cd1 == 0)
                {
                    Debug.Log(spell1);
                    cd1 += 5;
                    mana -= 15;
                    cur = 0;
                }
            }
            if (cur == 2)
            {
                if (mana >= mp2 && cd2 == 0)
                {
                    Debug.Log(spell2);
                    cd2 += 7;
                    mana -= 25;
                    cur = 0;
                }
            }
        }

        if (cur == 3)
        {
            if (mana >= mp3 && cd3 == 0)
            {
                Debug.Log(spell3);
                cd3 += 7;
                mana -= 35;
                cur = 0;
            }
        }

















    }
}
