using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Effect_Data : MonoBehaviour
{
    float countdown;
    public ParticleSystem particle;
    public GameObject buff;
    public GameObject unit;
    public Character_Stats charStats;
    public Buff_Data buffData;
    //public float timeleft;
    public bool active;
    public string particleName;   
    public string placing;
    //public List<GameObject> buffs = new List<GameObject>();
    //public List<Transform> children1 = new List<Transform>();
    //public List<string> location = new List<string>();




    // Start is called before the first frame update
    void Start()
    {
        unit = GameObject.Find("Character(MeleeBlue)");
        countdown = 0.01f;
        buffData = buff.GetComponent<Buff_Data>();
        charStats = unit.GetComponent<Character_Stats>();
        particle = gameObject.GetComponent<ParticleSystem>();
        particle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        //timeleft = buffData.time;
        
        if (buff == null) {
            List<GameObject> buffs2 = new List<GameObject>();
            for (int i = 0; i < charStats.buffList.Count; i++) { 
            Buff_Data bd = charStats.buffList[i].GetComponent<Buff_Data>();
            if (particleName == bd.buffName)
                {
                    buffs2.Add(charStats.buffList[i]);
                }
            }
            if(buffs2.Count == 0 ) {
                particle.Stop();
                Destroy(this.gameObject, 2);
                for(int i = 0; i<charStats.particleList.Count; i++)
                {
                    if(charStats.particleList[i] == particle)
                    {
                        charStats.particleList.RemoveAt(i);
                    }
                }    
            }
        }
        
    }
}
