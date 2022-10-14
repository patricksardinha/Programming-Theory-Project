using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RedShape : BaseShape
{
    public GameObject redTexture;

    public override void GenerateShape()
    {
        GameObject reshape = Instantiate(redTexture, base.canvasBuildedSchema);
        string idReShape = "Re";
        BuildShapeGenerated(reshape, idReShape);
    }

    public override void DisplayOnScreen()
    {
        base.DisplayOnScreen();
        GenerateShape();
    }
}
