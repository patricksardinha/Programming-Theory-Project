using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CyanShape : BaseShape
{
    public GameObject cyanTexture;

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
