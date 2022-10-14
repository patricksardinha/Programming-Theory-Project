using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YellowShape : BaseShape
{
    public GameObject yellowTexture;

    public override void GenerateShape()
    {
        GameObject yeshape = Instantiate(yellowTexture, base.canvasBuildedSchema);
        string idYeShape = "Ye";
        BuildShapeGenerated(yeshape, idYeShape);
    }

    public override void DisplayOnScreen()
    {
        base.DisplayOnScreen();
        GenerateShape();
    }
}
