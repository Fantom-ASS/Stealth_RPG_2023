using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCameraMove : MonoBehaviour
{
    public Camera thisCamera;
    public GameObject displayedUnit;
    public GameObject chosen;
    public bool hovered;
    public Vector3 cameraPos1;
    // Start is called before the first frame update
    void Start()
    {
        thisCamera.cullingMask = 1 << LayerMask.NameToLayer("unit");
    }

    // Update is called once per frame
    void Update()
    {

        


    }
}
