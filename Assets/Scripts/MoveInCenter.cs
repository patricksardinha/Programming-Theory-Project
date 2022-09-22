using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInCenter : MonoBehaviour
{
    private bool moveTile;
    private Vector3 distanceToCenter;

    void Start()
    {
        moveTile = false;
        Invoke("MoveMovableGroundTile", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        distanceToCenter = new Vector3(0, transform.position.y, transform.position.z) - transform.position;
        if (moveTile && Mathf.Abs(distanceToCenter.x) > 0)
        {
            transform.Translate(distanceToCenter * Time.deltaTime);
        }
    }

    void MoveMovableGroundTile()
    {
        moveTile = true;
    }
}
