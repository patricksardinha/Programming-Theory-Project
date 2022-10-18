using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInCenter : MonoBehaviour
{
    private Vector3 distanceToCenter;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        // Define the distance (X-axis) to reach the center from a decor object
        distanceToCenter = new Vector3 (30,0,0);
    }

    void Update()
    {
        // Constently recompute the distance to center
        distanceToCenter = new Vector3(0, transform.position.y, transform.position.z) - transform.position;

        // Move the current movable tile smoothly with time in case a correct schema is builded & stop the movement when it is almost 0 
        if (gameManager.moveTile && Mathf.Abs(distanceToCenter.x) > 0.1f)
        {
            transform.Translate(distanceToCenter * Time.deltaTime);
        }
        // Set boolean to stop movement
        else if (Mathf.Abs(distanceToCenter.x) < 0.1f)
        {
            gameManager.moveTile = false;
        }
    }
}
