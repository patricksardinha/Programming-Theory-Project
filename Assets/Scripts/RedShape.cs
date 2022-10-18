using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RedShape : BaseShape
{
    public GameObject redTexture;

    // When the shape is clicked, instantiate a new picture of the shape in the build schema panel
    public override void GenerateShape()
    {
        GameObject reshape = Instantiate(redTexture, base.canvasBuildedSchema);
        string idReShape = "Re";
        BuildShapeGenerated(reshape, idReShape);
    }

    public override void DisplayOnScreen()
    {
        base.DisplayOnScreen();
        GenerateShape();
    }
}
