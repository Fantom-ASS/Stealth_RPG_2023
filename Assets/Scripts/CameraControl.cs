using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public int mode; //0 - follow player, 1 - cinematic
    public float slerpspeed;
    public Transform followTarget;
    public Vector3 cameraPos; //position of camera example (0,10,-5)
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(followTarget != null && mode == 0) 
        { 
        FollowPlayer();
        }

    }

    void FollowPlayer()
    {
        transform.position = Vector3.Slerp(transform.position,followTarget.position+cameraPos, slerpspeed*Time.deltaTime);
    }
}
