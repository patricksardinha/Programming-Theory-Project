using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseShape : MonoBehaviour
{
    protected TextMeshProUGUI shapeText;

    private void Start()
    {
        shapeText = GameObject.Find("ShapeText").GetComponent<TextMeshProUGUI>();
    }

    public virtual void DisplayOnScreen()
    {
        shapeText.text = "";
        Debug.Log("baseShape.DisplayOnScreen");
    }

    public virtual void GenerateShape()
    {
        Debug.Log("baseShape.GenerateShape");
    }
}
