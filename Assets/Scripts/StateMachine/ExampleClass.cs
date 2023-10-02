using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    public Transform target;
    public float rotSpeed;
    public bool turn;

    void Update()
    {
        if (turn)
        {
            Vector3 dir = target.position - transform.position;

            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotate = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), rotSpeed * Time.deltaTime);
            rotate.x = 0;
            rotate.z = 0;
            transform.rotation = rotate;
            
        }
        
    }
}