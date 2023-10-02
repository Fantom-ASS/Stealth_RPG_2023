using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
//using static System.IO.Enumeration.FileSystemEnumerable<TResult>;

public class Spawn1 : MonoBehaviour
{
    public GameObject target;
    public Character_Stats charStats;
    public GameObject buff;
    public ParticleSystem effect;
    public string effName;

    public List<Transform> children1 = new List<Transform>();
    public List<string> location = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        charStats = target.GetComponent<Character_Stats>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Buff_Data buff_Data= buff.GetComponent<Buff_Data>();
            Effect_Data effect_Data = effect.GetComponent<Effect_Data>();
            int sameCount = 0;
            GameObject childObject2 = Instantiate(buff, transform.position, transform.rotation) as GameObject;
            childObject2.transform.parent = target.transform;
            childObject2.transform.localPosition = new Vector3(0, 0, 0);
            charStats.buffList.Add(childObject2);



            for (int i=0;i<charStats.particleList.Count;i++)
            {
                Effect_Data effect1 = charStats.particleList[i].GetComponent<Effect_Data>();
                string effectName = effect1.particleName;
               // if(effectName == "blessing") { sameCount += 1; }
                if (effectName == "rage") { sameCount += 1; }
            }



            if(sameCount > 0)
            {
               // Debug.Log(sameCount);
            } else
            {
                //Debug.Log(sameCount);
                effect_Data.buff = childObject2;
                    
                ParticleSystem childObject1 = Instantiate(effect, transform.position, transform.rotation) as ParticleSystem;
                children1 = new List<Transform>(target.GetComponentsInChildren<Transform>());
                if (location.Count > 0 && children1.Count > 0)
                {
                    for (int i = 0; i < location.Count; i++)
                    {
                        for (int j = 0; j < children1.Count; j++)
                        {
                            string objName = children1[j].gameObject.name;
                            if (objName == location[i])
                            {
                                Debug.Log(objName);
                                childObject1.transform.SetParent(children1[j]);
                                childObject1.transform.localPosition = new Vector3(0, 0.25f, 0);
                                childObject1.transform.localRotation = Quaternion.Euler(270, 0, 0);
                            }
                        }
                    }
                }




                // childObject1.transform.parent = target.transform;
                Effect_Data effect2 = childObject1.GetComponent<Effect_Data>();
                //Debug.Log(effect2.name);
                charStats.particleList.Add(childObject1);
            }
        }




    }
}
