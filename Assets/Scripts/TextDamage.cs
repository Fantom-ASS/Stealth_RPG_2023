using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextDamage : MonoBehaviour
{
    public float value;
    public TextMeshPro tmp;
    float alpha = 1;
    Vector3 direction = new Vector3(1, 1, 0);


    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(63,0,0);
        Vector3 newPosition = new Vector3(0f, 1.5f, 0f);
        transform.position += newPosition;
        Destroy(gameObject,3);
        Color rgbaColor = new Color(0, 1f, 0.3f, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        alpha -= (Time.deltaTime/3);
        Color rgbaColor = new Color(0, 1f, 0.3f, alpha);
        tmp.color = rgbaColor;
        transform.Translate(direction * Time.deltaTime);


    }
}
