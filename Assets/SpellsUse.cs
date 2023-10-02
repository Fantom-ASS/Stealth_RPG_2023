using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellsUse : MonoBehaviour
{


    public string spellL;
    public string spellR;
    public string spell1;
    public string spell2;
    public string spell3;

    public float cdR;
    public float cd1;
    public float cd2;
    public float cd3;

    public int sp;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cd1 > 0) { cd1 -= Time.deltaTime; }
        if (cd1 < 0) { cd1 = 0; }
        if (cd2 > 0) { cd2 -= Time.deltaTime; }
        if (cd2 < 0) { cd2 = 0; }
        if (cd3 > 0) { cd3 -= Time.deltaTime; }
        if (cd3 < 0) { cd3 = 0; }
        if (cdR > 0) { cdR -= Time.deltaTime; }
        if (cdR < 0) { cdR = 0; }




        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(cd1 <= 0)
            {
                sp = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (cd2 <= 0)
            {
                sp = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (cd3 <= 0)
            {
                sp = 3;
                Debug.Log(spell3);
                sp = 0;
                cd3 += 9;
            }
        }




        if (Input.GetMouseButtonDown(0))
        {
            if (sp == 0)
            {
                Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit1;
                if (Physics.Raycast(ray1, out hit1))
                {
                    if (hit1.transform != null && sp == 0)
                    {
                        Debug.Log(hit1.transform.name + " = " + spellL);
                        sp = 0;
                    }
                }
            }

            if (sp == 2)
            {
                Debug.Log(spell2);
                sp = 0;
                cd2 += 7;
            }


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform != null && sp == 1)
                {
                    Debug.Log(hit.transform.name +" = "+ spell1);
                    sp = 0;
                    cd1 += 5;
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (sp != 0) { sp = 0; }
            if (sp == 0 && cdR <= 0)
            {
                Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit2;
                if (Physics.Raycast(ray2, out hit2))
                {
                    if (hit2.transform != null && sp == 0)
                    {
                        Debug.Log(hit2.transform.name + " = " + spellR);
                        sp = 0;
                        cdR += 1;
                    }
                }
            }
        }
        





    }



}
