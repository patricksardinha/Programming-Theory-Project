using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// INHERITANCE - Child class 
public class BlueShape : BaseShape
{
    public GameObject blueTexture;

    // POLYMORPHISM

    // When the shape is clicked, instantiate a new picture of the shape in the build schema panel
    public override void GenerateShape()
    {
        GameObject blshape = Instantiate(blueTexture, base.canvasBuildedSchema);
        string idBlShape = "Bl";
        BuildShapeGenerated(blshape, idBlShape);
    }

    // POLYMORPHISM
    public override void DisplayOnScreen()
    {
        base.DisplayOnScreen();
        GenerateShape();
    }
}
