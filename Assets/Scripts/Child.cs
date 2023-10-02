using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour
{
    public List<Transform> children1 = new List<Transform>();
    public GameObject effect;
    public List<Transform> tag_targets = new List<Transform>(); //список трансформів який буде заповнюватися якщо в об'єкта є дочерні
    public List<string> location = new List<string>(); //це поки не потрібно

    // Start is called before the first frame update
    void Start()
    {
        children1 = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        //скріпт перевіряє все дочерні об'єкти до 10 ступеню каталога
        for (int i = 0; i < transform.childCount; i++)
        {
            
            tag_targets.Add(gameObject.transform.GetChild(i));
            Transform child1 = this.gameObject.transform.GetChild(i);
            if (child1.childCount > 0)
            {
                for (int j = 0; j < child1.childCount; j++)
                {
                    tag_targets.Add(child1.transform.GetChild(j));
                    Transform child2 = child1.gameObject.transform.GetChild(j);
                    if (child2.childCount > 0)
                    {
                        for (int k = 0; k < child2.childCount; k++)
                        {
                            tag_targets.Add(child2.transform.GetChild(k));
                            Transform child3 = child2.gameObject.transform.GetChild(k);
                            if (child3.childCount > 0)
                            {
                                for (int l = 0; l < child3.childCount; l++)
                                {
                                    tag_targets.Add(child3.transform.GetChild(l));
                                    Transform child4 = child3.gameObject.transform.GetChild(l);
                                    if (child4.childCount > 0)
                                    {
                                        for (int m = 0; m < child4.childCount; m++)
                                        {
                                            tag_targets.Add(child4.transform.GetChild(m));
                                            Transform child5 = child4.gameObject.transform.GetChild(m);
                                            if (child5.childCount > 0)
                                            {
                                                for (int n = 0; n < child5.childCount; n++)
                                                {
                                                    tag_targets.Add(child5.transform.GetChild(n));
                                                    Transform child6 = child5.gameObject.transform.GetChild(n);
                                                    if (child6.childCount > 0)
                                                    {
                                                        for (int o = 0; o < child6.childCount; o++)
                                                        {
                                                            tag_targets.Add(child6.transform.GetChild(o));
                                                            Transform child7 = child6.gameObject.transform.GetChild(o);
                                                            if (child7.childCount > 0)
                                                            {
                                                                for (int p = 0; p < child7.childCount; p++)
                                                                {
                                                                    tag_targets.Add(child7.transform.GetChild(p));
                                                                    Transform child8 = child7.gameObject.transform.GetChild(p);
                                                                    if (child8.childCount > 0)
                                                                    {
                                                                        for (int q = 0; q < child8.childCount; q++)
                                                                        {
                                                                            tag_targets.Add(child8.transform.GetChild(q));
                                                                            Transform child9 = child8.gameObject.transform.GetChild(q);
                                                                            if (child9.childCount > 0)
                                                                            {
                                                                                for (int r = 0; r < child9.childCount; r++)
                                                                                {
                                                                                    tag_targets.Add(child9.transform.GetChild(r));
                                                                                    Transform child10 = child9.gameObject.transform.GetChild(r);
                                                                                    if (child10.childCount > 0)
                                                                                    {
                                                                                        for (int s = 0; s < child10.childCount; s++)
                                                                                        {
                                                                                            tag_targets.Add(child10.transform.GetChild(s));
                                                                                            Transform child11 = child10.gameObject.transform.GetChild(s);
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //потім у списку шукається об'єкт з певним іменем, до якого треба приперентити effect
        if (location.Count > 0 && tag_targets.Count > 0)
        {
            for(int i = 0 ; i < location.Count; i++) {
                for (int j = 0; j < tag_targets.Count; j++)
                {
                    string objName = tag_targets[j].gameObject.name;
                    if(objName == location[i])
                    {
                        Debug.Log(objName);
                        effect.transform.SetParent(tag_targets[j]);
                    }
                }
            }
        }
    }
}
