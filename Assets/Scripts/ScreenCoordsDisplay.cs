using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScreenCoordsDisplay : MonoBehaviour
{
    public Transform targetObject1;
    public Transform targetObject2;
    public Transform targetObject3;
    public TextMeshProUGUI textElement;
    public RectTransform selector;
    public Vector2 startPos;
    public Vector2 endPos;
    Camera mainCamera;
    public bool unit1;
    public bool unit2;
    public bool unit3;

    void Start()
    {
        mainCamera = Camera.main;

        startPos = Vector2.zero;
        endPos = Vector2.zero;
    }

    void Update()
    {
         Vector3 objectScreenPos1 = mainCamera.WorldToScreenPoint(targetObject1.position);
         Vector3 objectScreenPos2 = mainCamera.WorldToScreenPoint(targetObject2.position);
         Vector3 objectScreenPos3 = mainCamera.WorldToScreenPoint(targetObject3.position);

        string screenCoordinatesText = "Screen X: " + objectScreenPos1.x.ToString("F0") + "\nScreen Y: " + objectScreenPos1.y.ToString("F0");

        textElement.text = "Screen Coordinates:\n" + screenCoordinatesText;
        //Debug.Log("Screen Coordinates:\n" + screenCoordinatesText);

        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            endPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if(startPos.x > endPos.x && startPos.y > endPos.y) //right-left top-bottom
            {
                if (objectScreenPos3.x < startPos.x && objectScreenPos3.x > endPos.x && objectScreenPos3.y < startPos.y && objectScreenPos3.y > endPos.y) { unit3 = true; }
                else { if (unit1 | unit2) { unit3 = false; } }
                if (objectScreenPos2.x < startPos.x && objectScreenPos2.x > endPos.x && objectScreenPos2.y < startPos.y && objectScreenPos2.y > endPos.y) { unit2 = true; }
                else { if (unit1 | unit3) { unit2 = false; } }
                if (objectScreenPos1.x < startPos.x && objectScreenPos1.x > endPos.x && objectScreenPos1.y < startPos.y && objectScreenPos1.y > endPos.y) { unit1 = true; }
                else { if (unit2 | unit3) { unit1 = false; }  }
            }
            if (startPos.x < endPos.x && startPos.y < endPos.y) //left-right bottom-top
            {
                if (objectScreenPos3.x > startPos.x && objectScreenPos3.x < endPos.x && objectScreenPos3.y > startPos.y && objectScreenPos3.y < endPos.y) { unit3 = true; }
                else { if (unit1 | unit2) { unit3 = false; } }
                if (objectScreenPos2.x > startPos.x && objectScreenPos2.x < endPos.x && objectScreenPos2.y > startPos.y && objectScreenPos2.y < endPos.y) { unit2 = true; }
                else { if (unit1 | unit3) { unit2 = false; } }
                if (objectScreenPos1.x > startPos.x && objectScreenPos1.x < endPos.x && objectScreenPos1.y > startPos.y && objectScreenPos1.y < endPos.y) { unit1 = true; }
                else { if (unit2 | unit3) { unit1 = false; } }
            }
            if (startPos.x > endPos.x && startPos.y < endPos.y) //right-left bottom-top
            {
                if (objectScreenPos3.x < startPos.x && objectScreenPos3.x > endPos.x && objectScreenPos3.y > startPos.y && objectScreenPos3.y < endPos.y) { unit3 = true; }
                else { if (unit1 | unit2) { unit3 = false; } }
                if (objectScreenPos2.x < startPos.x && objectScreenPos2.x > endPos.x && objectScreenPos2.y > startPos.y && objectScreenPos2.y < endPos.y) { unit2 = true; }
                else { if (unit1 | unit3) { unit2 = false; } }
                if (objectScreenPos1.x < startPos.x && objectScreenPos1.x > endPos.x && objectScreenPos1.y > startPos.y && objectScreenPos1.y < endPos.y) { unit1 = true; }
                else { if (unit2 | unit3) { unit1 = false; } }
            }
            if (startPos.x < endPos.x && startPos.y > endPos.y) //left-right top-bottom
            {
                if (objectScreenPos3.x > startPos.x && objectScreenPos3.x < endPos.x && objectScreenPos3.y < startPos.y && objectScreenPos3.y > endPos.y) { unit3 = true; }
                else { if (unit1 | unit2) { unit3 = false; } }
                if (objectScreenPos2.x > startPos.x && objectScreenPos2.x < endPos.x && objectScreenPos2.y < startPos.y && objectScreenPos2.y > endPos.y) { unit2 = true; }
                else { if (unit1 | unit3) { unit2 = false; } }
                if (objectScreenPos1.x > startPos.x && objectScreenPos1.x < endPos.x && objectScreenPos1.y < startPos.y && objectScreenPos1.y > endPos.y) { unit1 = true; }
                else { if (unit2 | unit3) { unit1 = false; } }
            }   
            startPos = Vector2.zero; //after release of mouse start and end positions turn to zero
            endPos = Vector2.zero;
        }




    }
}