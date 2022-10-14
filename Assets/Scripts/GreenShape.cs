using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GreenShape : BaseShape
{
    public GameObject greenTexture;

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
