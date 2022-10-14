using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlueShape : BaseShape
{
    public GameObject blueTexture;

    public override void GenerateShape()
    {
        GameObject blshape = Instantiate(blueTexture, base.canvasBuildedSchema);
        string idBlShape = "Bl";
        BuildShapeGenerated(blshape, idBlShape);
    }

    public override void DisplayOnScreen()
    {
        base.DisplayOnScreen();
        GenerateShape();
    }
}
