using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCull : MonoBehaviour
{
    public GameObject hero;
    public GameObject[] unitClothes = new GameObject[3];
    public GameObject[] heroClothes = new GameObject[3];
    public Camera cameraCull;
    public DisplayCameraMove displayCam;
    public Vector3 cameraPos1;
    public bool hover;

    // Start is called before the first frame update
    void Start()
    {
        // cameraCull.cullingMask = 1 << LayerMask.NameToLayer("cameracull");
        cameraPos1 = new Vector3(0, 1, 2);
        //Transform[] children = hero.GetComponentsInChildren<Transform>(true);
        if(gameObject == hero)
        {
            for (int i = 0; i < heroClothes.Length; i++)
            {
                if (heroClothes[i] != null)
                {
                    heroClothes[i].gameObject.layer = 10;
                }
            }
        }


        Vector3 newPosition = hero.transform.position - (hero.transform.forward * 2);
        Vector3 targetPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 1, transform.localPosition.z);
        cameraCull.transform.position = newPosition;
        Vector3 directionToTarget = targetPosition - cameraCull.transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget, Vector3.up);
        cameraCull.transform.rotation = rotationToTarget;
    }

    // Update is called once per frame
    void OnMouseEnter()
    {
        

        Vector3 newPosition = new Vector3(transform.localPosition.x, transform.localPosition.y+1, transform.localPosition.z-2);
        Vector3 targetPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 1, transform.localPosition.z);
        cameraCull.transform.position = newPosition;
        Vector3 directionToTarget = targetPosition - cameraCull.transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget, Vector3.up);
        cameraCull.transform.rotation = rotationToTarget;
        if (gameObject == hero)
        {
            for (int i = 0; i < heroClothes.Length; i++)
            {
                if (heroClothes[i] != null)
                {
                    heroClothes[i].gameObject.layer = 10;
                }
            }
        }
        else
        {
            for (int i = 0; i < heroClothes.Length; i++)
            {
                if (heroClothes[i] != null)
                {
                    heroClothes[i].gameObject.layer = 0;
                }
            }
            for (int i = 0; i < unitClothes.Length; i++)
            {
                if (unitClothes[i] != null)
                {
                    unitClothes[i].gameObject.layer = 10;
                }
            }
        }




    }

    void OnMouseExit()
    {
        
        if(gameObject == hero)
        {
            Vector3 newPosition = new Vector3(hero.transform.localPosition.x, hero.transform.localPosition.y + 1, hero.transform.localPosition.z - 2);
            Vector3 targetPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 1, transform.localPosition.z);
            cameraCull.transform.position = newPosition;
            Vector3 directionToTarget = targetPosition - cameraCull.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget, Vector3.up);
            cameraCull.transform.rotation = rotationToTarget;
        }
        else
        {
            Vector3 newPosition = new Vector3(hero.transform.localPosition.x, hero.transform.localPosition.y + 1, hero.transform.localPosition.z - 2);
            Vector3 targetPosition = new Vector3(hero.transform.localPosition.x, hero.transform.localPosition.y + 1, hero.transform.localPosition.z);
            cameraCull.transform.position = newPosition;
            Vector3 directionToTarget = targetPosition - cameraCull.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget, Vector3.up);
            cameraCull.transform.rotation = rotationToTarget;

            for (int i = 0; i < heroClothes.Length; i++)
            {
                if (heroClothes[i] != null)
                {
                    heroClothes[i].gameObject.layer = 10;
                }
            }
            for (int i = 0; i < unitClothes.Length; i++)
            {
                if (unitClothes[i] != null)
                {
                    unitClothes[i].gameObject.layer = 0;
                }
            }



        }

        



        
    }

    void Update()
    {
       // if (!hover) { transform.position = hero.transform.position + cameraPos1; }
        
    }
}
