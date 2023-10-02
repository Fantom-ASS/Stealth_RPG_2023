using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject mouseCode;
    public MousePoint mousePoint;

    public Transform targetPos;
    public Transform shooterPos;
    public GameObject shooter;
    public GameObject target;
    public GameObject missile;
    public Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            direction = mousePoint.pointer.transform.position - shooter.transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
            Instantiate(missile, shooter.transform.position, missile.transform.rotation = Quaternion.LookRotation(direction));
        }




    }
}
