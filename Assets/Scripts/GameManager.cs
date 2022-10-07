using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-2)]
public class GameManager : MonoBehaviour
{
    public float environmentSpeed;

    public bool isGameActive;

    public GameObject redScreen;
    public GameObject greenScreen;

    private void Start()
    {
        StartGame();
    }

    void Update()
    {

    }

    public void StartGame()
    {
        isGameActive = true;
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        isGameActive = false;
        Time.timeScale = 0;
    }
}
