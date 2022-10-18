using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GreyShape : BaseShape
{
    public GameObject greyTexture;

    // When the shape is clicked, instantiate a new picture of the shape in the build schema panel
    public override void GenerateShape()
    {
        GameObject whshape = Instantiate(greyTexture, base.canvasBuildedSchema);
        string idWhShape = "Wh";
        BuildShapeGenerated(whshape, idWhShape);
    }

    public override void DisplayOnScreen()
    {
        base.DisplayOnScreen();
        GenerateShape();
    }
}
