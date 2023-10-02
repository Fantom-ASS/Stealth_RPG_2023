using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curses : MonoBehaviour
{
    public GameObject Effects;
    public Vector3 EffectPosition;
    public GameObject childing_Object;


    public GameObject regenerateHP;
    public GameObject regenerateMP;


    public string innerEffect;


    public bool regenHP;
    public float regenHP_effect;
    public float regenHP_time;

    public bool regenMP;
    public float regenMP_effect;
    public float regenMP_time;


    public bool strong;
    public float strong_effect;
    public float strong_time;

    public bool weakness;
    public float weakness_effect;
    public float weakness_time;

    public bool magicsight;
    public float magicsight_effect;
    public float magicsight_time;

    public bool invisibility;
    public float invisibility_effect;
    public float invisibility_time;

    public bool nosound;
    public float nosound_effect;
    public float nosound_time;

    public bool enemyvision;
    public float enemyvision_time;

    public bool dimvision;
    public float dimvision_effect;
    public float dimvision_time;

    public bool insanity;
    public float insanity_time;

    public bool hypnos;
    public float hypno_time;

    public bool firespirits;
    public float firespirits_effect;
    public float firespirits_time;

    public bool physprotect;
    public float physprotect_effect;
    public float physprotect_time;

    public bool fireprotect;
    public float fireprotect_effect;
    public float fireprotect_time;

    public bool lightprotect;
    public float lightprotect_effect;
    public float lightprotect_time;

    public bool acidprotect;
    public float acidprotect_effect;
    public float acidprotect_time;

    public bool coldprotect;
    public float coldprotect_effect;
    public float coldprotect_time;


    public bool magicprotect;
    public float magicprotect_effect;
    public float magicprotect_time;

    public bool lethargy;
    public float lethargy_time;


    public bool paralize;
    public float paralize_time;


    public bool heartstop;
    public float heartstop_effect;
    public float heartstop_time;

    public bool trapped;
    public float trapped_time;


    public bool stunned;
    public float stunned_time;


    public bool frozen;
    public float frozen_effect;
    public float frozen_time;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    void FidexUpdate()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!regenHP)
            {
                Instantiate(regenerateHP, transform.position, Quaternion.identity);
                childing_Object = GameObject.Find("RegenHP(Clone)");
                childing_Object.transform.parent = Effects.transform;
                childing_Object = null;
            }

            regenHP = true;
            regenHP_time = 5;
            regenHP_effect = 50;
            

        }
        if (regenHP_time > 0)
        {
            regenHP_time -= Time.deltaTime;
        }



        if (Input.GetKeyDown(KeyCode.B))
        {
            regenMP = true;
            regenMP_time = 7;
            regenMP_effect = 80;
        }
        if (regenMP_time > 0)
        {
            regenMP_time -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            weakness = true;
            weakness_time = 3;
            weakness_effect = 10;
        }
        if (weakness_time > 0)
        {
            weakness_time -= Time.deltaTime;
        }



    }

    private void FixedUpdate()
    {
        if (regenHP_time < 0)
        {
            regenHP_time = 0;
            regenHP_effect = 0;
            regenHP = false;
            childing_Object = GameObject.Find("RegenHP(Clone)");
            Destroy(childing_Object);

        }

        if (regenMP_time < 0)
        {
            regenMP_time = 0;
            regenMP_effect = 0;
            regenMP = false;
        }

        if (weakness_time < 0)
        {
            weakness_time = 0;
            weakness_effect = 0;
            weakness = false;
        }



    }




    void Decrepify(float effect, float time)
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            weakness = true;
        } if (time < 0)
        {
            time = 0;
            effect = 0;
            weakness = false;
           
        }
        
    }


}
