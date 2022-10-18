using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    private GameManager gameManager;

    // Ground speed on z-axis
    private float speedGround;

    void Start()
    {
        // Reference to gameManager script
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        // Set the ground speed as the environment speed
        speedGround = gameManager.environmentSpeed;

        // Move the ground by translation
        transform.Translate(-Vector3.forward * speedGround * Time.deltaTime);
    }
}
