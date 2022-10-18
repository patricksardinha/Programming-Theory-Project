using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the censor end game collides with the player
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);

            // If yes, set the game as Over
            gameManager.GameOver();
        }
    }

}
