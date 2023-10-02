using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIObjectOverlapCheck : MonoBehaviour
{
    public Camera mainCamera;
    public RectTransform uiElement;
    public Vector3 boxSize; // Adjust as needed
    public float x;
    public float y;

    public Vector2 WorldUnitsInCamera;
    public Vector2 WorldToPixelAmount;

    public TextMeshProUGUI text;

    private void Update()
    {
        text.text =  ConvertToUnits(uiElement.sizeDelta.x) + ":" + ConvertToUnits(uiElement.sizeDelta.y);
        x = ConvertToUnits(uiElement.sizeDelta.x);
        y = ConvertToUnits(uiElement.sizeDelta.y);
        boxSize = new Vector3(boxSize.x, boxSize.y, 50);
        Debug.Log(uiElement.sizeDelta);
        // Convert pixel coordinates to viewport coordinates
        



        // Convert UI screen position to world space ray
        Vector3 uiScreenPos = RectTransformUtility.WorldToScreenPoint(mainCamera, uiElement.position);
        Ray ray = mainCamera.ScreenPointToRay(uiScreenPos);

        RaycastHit[] hits;

        // BoxCastAll from UI to 3D objects
        hits = Physics.BoxCastAll(ray.origin, boxSize, ray.direction);
        


        bool overlapsWith3DObject = false;

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.gameObject != null && hit.collider.gameObject.layer == 6)
            {
               // Debug.Log("UI element overlaps with a 3D object: " + hit.collider.gameObject.name);
                for(int i = 0; i < hits.Length; i++) { Debug.Log(hits[i].transform.gameObject.name); }
                Debug.Log(hits.Length);
                overlapsWith3DObject = true;
                // Handle overlap here
            }
        }

        if (!overlapsWith3DObject)
        {
           // Debug.Log("UI element does not overlap with any 3D object.");
            // Handle non-overlap here
        }
    }
    public Vector2 ConvertToWorldUnits(Vector2 TouchLocation)
    {
        Vector2 returnVec2;

        returnVec2.x = ((TouchLocation.x / WorldToPixelAmount.x) - (WorldUnitsInCamera.x / 2)) +
        mainCamera.transform.position.x;
        returnVec2.y = ((TouchLocation.y / WorldToPixelAmount.y) - (WorldUnitsInCamera.y / 2)) +
        mainCamera.transform.position.y;

        return returnVec2;
    }
    float ConvertToUnits(float p)
    {
        float ortho = mainCamera.orthographicSize;
        float pixelH = mainCamera.pixelHeight;

        return (p * ortho * 2) / pixelH;

    }


}