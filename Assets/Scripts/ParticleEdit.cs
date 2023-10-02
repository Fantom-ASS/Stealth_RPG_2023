using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ParticleEdit : MonoBehaviour
{
    public ParticleSystem particle = new ParticleSystem();


    public float timeAlive;

    // Start is called before the first frame update
    void Start()
    {

        // Calculate how long the particle has been alive.
     //   timeAlive = particle1.startLifetime;
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
}
