using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Vis : MonoBehaviour
{
    
    public List<float> bestAoE = new List<float>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        List<GameObject> objects = new List<GameObject>();
        List<float> ranges = new List<float>();
        objects = GameObject.FindGameObjectsWithTag("Unit").ToList();
        for (int a=0; a<objects.Count; a++)
        {
            for (int b = 0; b<objects.Count; b++)
            {
                if (ranges.Count < objects.Count)
                { ranges.Add(Vector3.Distance(transform.position, objects[b].transform.position));  }
                if(bestAoE.Count < objects.Count)
                { bestAoE.Add(ranges.Sum()); }
            }
            for (int c = 0; c < objects.Count; c++)
            {
                GameObject curobject;
                curobject = objects[a];
                ranges[c] = Vector3.Distance(objects[a].transform.position, objects[c].transform.position);
                bestAoE[c] = ranges.Sum();
                for (int d = 0; d < objects.Count; d++)
                {curobject = objects[d]; }
            }
        }









    }
}
