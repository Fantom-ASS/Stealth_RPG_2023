using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Color wantedColor;
    public Button button1;

    void Start()
    {

    }

    void OnMouseOver()
    {

    }

    void OnMouseExit()
    {
        
    }

    public void ChangeButtonColor()
    {
        ColorBlock cb = button1.colors;
        cb.normalColor = wantedColor;
        cb.highlightedColor = wantedColor;
        cb.pressedColor = wantedColor;
        button1.colors = cb;
    }
}