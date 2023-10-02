using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualBuff : MonoBehaviour
{
    public bool living;
    public float killdelay;
    public string castname;
    public UnitData unitdata;
    public List<ParticleSystem> start = new List<ParticleSystem>();
    public List<ParticleSystem> particles = new List<ParticleSystem>();
    public List<ParticleSystem> end = new List<ParticleSystem>();

    // Start is called before the first frame update
    private void Start()
    {
        living = true;
        if (killdelay == 0) { killdelay = 3; } 
        if (start.Count > 0)
        {
            foreach (ParticleSystem ps in start)
            {
                ps.Stop();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!unitdata.buffName.Contains(castname) && living) 
        {
            living = false;
            unitdata.buffVisual.Remove(castname);
            Destroy(gameObject, killdelay);
            if(particles.Count > 0)
            {
                foreach (ParticleSystem ps in particles)
                {
                    ps.Stop();
                }
            }
            if(end.Count > 0)
            {
                foreach (ParticleSystem ps in end)
                {
                    ps.Play();
                }
            }
            
        }
        
    }
}
