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
        GameObject bshape = Instantiate(blueTexture, base.canvasBuildedSchema);
        bshape.transform.localPosition += new Vector3(position3Shapes[base.schemaPositionToFill] * 50, 0, 0);
        base.schemaPositionToFill++;
        base.currentSchemaList.Add("Bl");
        //Debug.Log("bshape: " + bshape.transform.position);
    }

    public override void DisplayOnScreen()
    {
        base.DisplayOnScreen();
        base.shapeText.SetText("Blue");
        Debug.Log("blueShape.DisplayOnScreen");
        GenerateShape();
    }

}
