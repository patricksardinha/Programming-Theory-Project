using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrangeShape : BaseShape
{
    public GameObject orangeTexture;

    public override void GenerateShape()
    {
        GameObject orshape = Instantiate(orangeTexture, base.canvasBuildedSchema);
        string idOrShape = "Or";
        BuildShapeGenerated(orshape, idOrShape);
    }

    public override void DisplayOnScreen()
    {
        base.DisplayOnScreen();
        GenerateShape();
    }
}
