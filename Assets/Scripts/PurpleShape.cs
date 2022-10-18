using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PurpleShape : BaseShape
{
    public GameObject purpleTexture;

    // When the shape is clicked, instantiate a new picture of the shape in the build schema panel
    public override void GenerateShape()
    {
        GameObject pushape = Instantiate(purpleTexture, base.canvasBuildedSchema);
        string idPuShape = "Pu";
        BuildShapeGenerated(pushape, idPuShape);
    }

    public override void DisplayOnScreen()
    {
        base.DisplayOnScreen();
        GenerateShape();
    }
}
