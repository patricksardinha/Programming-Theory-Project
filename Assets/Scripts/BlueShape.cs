using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlueShape : BaseShape
{
    public GameObject blueTexture;

    public override void GenerateShape()
    {
        base.GenerateShape();
        Debug.Log("blueShape.GenerateShape");
        Instantiate(blueTexture, transform.parent);
    }

    public override void DisplayOnScreen()
    {
        base.DisplayOnScreen();
        base.shapeText.SetText("Blue");
        Debug.Log("blueShape.DisplayOnScreen");
        GenerateShape();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
