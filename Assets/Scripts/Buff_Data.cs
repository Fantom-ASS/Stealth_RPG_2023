using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_Data : MonoBehaviour
{
    public ParticleSystem particle;
    public GameObject target;
    public Character_Stats targetStats;
    //public Effect_Data effData;

    public string buffName;
    public float time;
    public float effect;
    public bool stack;
    public bool dispell;
    public bool actived;
    public float difference;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Character(MeleeBlue)");
    List<GameObject> buffSame = new List<GameObject>();

    foreach (Transform child in target.transform){
            Buff_Data curStats1 = child.GetComponent<Buff_Data>();
            if (null == child)
            continue;
    }
    targetStats = target.GetComponent<Character_Stats>();
        if (buffName == "blessing")
        {
            Character_Stats buffStats = target.GetComponent<Character_Stats>();
            for(int i = 0; i < buffStats.buffList.Count; i++)
            {
                GameObject curBuff = buffStats.buffList[i];
                Buff_Data curStats1 = buffStats.buffList[i].GetComponent<Buff_Data>();
                if (buffName == curStats1.buffName)
                {
                    buffSame.Add(curBuff);
                    //Debug.Log(buffSame.Count);
                }
            }
            Buff_Data curStats2;
            for (int j = 0; j < buffSame.Count; j++)
            {
                curStats2 = buffSame[j].GetComponent<Buff_Data>();
                if (effect >= curStats2.effect)
                {
                    difference = effect - curStats2.effect;
                }
                else
                {
                    if(buffSame[j] != gameObject)
                    //actived = false;
                    difference = 0;
                }

            }
            if (buffSame.Count < 2) { targetStats.dmg_mod += effect;} else { targetStats.dmg_mod += difference; }
            //if(actived) { targetStats.dmg_mod += effect; }
        }
        if (buffName == "rage")
        {
            int sb = 0;
            Character_Stats buffStats = target.GetComponent<Character_Stats>();
            for (int i = 0; i < buffStats.buffList.Count; i++)
            {
                
                GameObject curBuff = buffStats.buffList[i];
                Buff_Data curStats1 = buffStats.buffList[i].GetComponent<Buff_Data>();
                if (buffName == curStats1.buffName)
                {
                    sb += 1;
                }
            }
            //if(sb > 10) {actived = false;} else { actived = true;}
            if (sb <= 10) { targetStats.dmg_mod += effect; }
           // if (actived) { targetStats.dmg_mod += effect; }
            //Debug.Log(sb);
        }

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            if(buffName == "blessing")
            {
                targetStats.dmg_mod -= effect;

                List<GameObject> buffSame = new List<GameObject>();
                Character_Stats buffStats = target.GetComponent<Character_Stats>();
                GameObject strongest = null;
                Buff_Data strongBuff;
                for (int i = 0; i < buffStats.buffList.Count; i++)
                {
                    GameObject curBuff = buffStats.buffList[i];
                    Buff_Data curStats1 = buffStats.buffList[i].GetComponent<Buff_Data>();
                    if (buffName == curStats1.buffName)
                    {
                        buffSame.Add(curBuff);
                        Debug.Log(buffSame.Count);
                    }
                }
                for (int j = 0; j < buffSame.Count; j++)
                {
                    Buff_Data curStats2 = buffStats.buffList[j].GetComponent<Buff_Data>();
                    if (effect >= curStats2.effect)
                    {
                        // strongest = buffStats.buffList[j];
                        strongest = buffSame[j];
                    }
                }
                if(buffSame.Count > 1)
                {
                    strongBuff = strongest.GetComponent<Buff_Data>();
                    targetStats.dmg_mod += strongBuff.effect;
                    //strongBuff.actived = true;
                    
                } else
                {
                    if(buffSame.Count == buffStats.buffList.Count)
                    {
                       // Buff_Data strongBuff1 = strongest.GetComponent<Buff_Data>();
                      //  targetStats.dmg_mod += strongBuff1.effect;
                    }
                    
                }
                
            }
            if (buffName == "rage")
            {
                int sb = 0;
                Character_Stats buffStats = target.GetComponent<Character_Stats>();
                for (int i = 0; i < buffStats.buffList.Count; i++)
                {

                    GameObject curBuff = buffStats.buffList[i];
                    Buff_Data curStats1 = buffStats.buffList[i].GetComponent<Buff_Data>();
                    if (buffName == curStats1.buffName)
                    {
                        sb += 1;
                    }
                }
                if (sb < 11)
                {
                    targetStats.dmg_mod -= effect;
                }
                //Debug.Log(sb);
            }
           // Debug.Log(gameObject);
            Destroy(gameObject);
        }

        
    }
}
