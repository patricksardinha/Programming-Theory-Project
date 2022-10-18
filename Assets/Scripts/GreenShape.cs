using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GreenShape : BaseShape
{
    public GameObject greenTexture;

    // When the shape is clicked, instantiate a new picture of the shape in the build schema panel
    public override void GenerateShape()
    {
        GameObject grshape = Instantiate(greenTexture, base.canvasBuildedSchema);
        string idGrShape = "Gr";
        base.BuildShapeGenerated(grshape, idGrShape);
    }

    public override void DisplayOnScreen()
    {
        base.DisplayOnScreen();
        GenerateShape();
    }
}
