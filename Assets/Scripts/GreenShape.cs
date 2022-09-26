using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GreenShape : BaseShape
{
    public override void DisplayOnScreen()
    {
        base.DisplayOnScreen();
        base.shapeText.SetText("Green");
        Debug.Log("greenShape.DisplayOnScreen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
