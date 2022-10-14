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
        distanceToCenter = new Vector3 (30,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        distanceToCenter = new Vector3(0, transform.position.y, transform.position.z) - transform.position;
        if (gameManager.moveTile && Mathf.Abs(distanceToCenter.x) > 0.1f)
        {
            transform.Translate(distanceToCenter * Time.deltaTime);
        }
        else if (Mathf.Abs(distanceToCenter.x) < 0.1f)
        {
            Debug.Log("MOVE TILE? " + gameManager.moveTile);
            gameManager.moveTile = false;
        }
    }
}
