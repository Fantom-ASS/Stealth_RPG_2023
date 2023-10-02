using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckSummDistances : MonoBehaviour
{
    public float detectionRadius;
    //public LayerMask detectionLayer;
    public List<GameObject> unitsAttackable = new List<GameObject>();
    public List<float> enemiesDistances = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] allObjectsInLayer = GameObject.FindGameObjectsWithTag("unit");
        foreach (GameObject obj in allObjectsInLayer)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);

            if (distance <= detectionRadius && !unitsAttackable.Contains(obj))
            {
                unitsAttackable.Add(obj);
                enemiesDistances.Add(0);
            }
        }
        for(int i = 0; i< unitsAttackable.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, unitsAttackable[i].transform.position);
            if(distance > detectionRadius) 
            {
                unitsAttackable.Remove(unitsAttackable[i]); 
                enemiesDistances.Remove(enemiesDistances[i]); 
            }
        }
        for (int i = 0; i < unitsAttackable.Count; i++)
        {
            float sumOfDistances = 0;
            foreach (GameObject obj in unitsAttackable)
            {
                float distance = Vector3.Distance(unitsAttackable[i].transform.position, obj.transform.position);
                sumOfDistances += distance;

            }
            enemiesDistances[i] = sumOfDistances;
        }




    }
}
