using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PinkShape : BaseShape
{
    public GameObject pinkTexture;

    // When the shape is clicked, instantiate a new picture of the shape in the build schema panel
    public override void GenerateShape()
    {
        GameObject pishape = Instantiate(pinkTexture, base.canvasBuildedSchema);
        string idPiShape = "Pi";
        BuildShapeGenerated(pishape, idPiShape);
    }

    public override void DisplayOnScreen()
    {
        base.DisplayOnScreen();
        GenerateShape();
    }
}
