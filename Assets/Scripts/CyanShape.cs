using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CyanShape : BaseShape
{
    public GameObject cyanTexture;

    // When the shape is clicked, instantiate a new picture of the shape in the build schema panel
    public override void GenerateShape()
    {
        GameObject cyshape = Instantiate(cyanTexture, base.canvasBuildedSchema);
        string idCyShape = "Cy";
        BuildShapeGenerated(cyshape, idCyShape);
    }

    public override void DisplayOnScreen()
    {
        base.DisplayOnScreen();
        GenerateShape();
    }
}
