using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[DefaultExecutionOrder(-2)]
public class GameManager : MonoBehaviour
{
    public float environmentSpeed;

    public bool isGameActive;

    private AudioSource gameAudioClip;

    public GameObject redScreen;
    public GameObject greenScreen;

    public GameObject panelShapesUIGrey;

    public GameObject panelGameOver;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplierText;
    public TextMeshProUGUI difficultyText;

    public TextMeshProUGUI yourScoreText;

    private float currentScore;
    public int multiplierScore;
    public int difficultyScore;

    public int schemaPositionToFill;
    public List<string> currentSchemaList = new List<string>();
    public List<string> newSchemaList = new List<string>();

    public bool flagDiff3;
    public bool flagDiff4;
    public bool flagDiff5;
    public bool flagDiff6;
    public bool moveTile { get; set; }

    private void Start()
    {
        StartGame();
        currentScore = 0;
        multiplierScore = 1;
        difficultyScore = 3;
        scoreText.text = "Score: " + currentScore;
        multiplierText.text = "Multiplier: x" + multiplierScore;
        difficultyText.text = "Difficulty: x" + difficultyScore;
        flagDiff3 = true;
        flagDiff4 = true;
        flagDiff5 = true;
        flagDiff6 = true;
}

    void Update()
    {
        currentScore += 1 * Time.deltaTime * multiplierScore * difficultyScore;
        scoreText.SetText("Score: " + Mathf.Ceil(currentScore));
        multiplierText.SetText("Multiplier: x" + multiplierScore);
        difficultyText.SetText("Difficulty: x" + difficultyScore);

        if (currentScore > 100 && flagDiff3)
        {
            flagDiff3 = false;
            difficultyScore += 1;
        }
        else if (currentScore > 1000 && flagDiff4)
        {
            flagDiff4 = false;
            difficultyScore += 1;
        }
        else if (currentScore > 10000 && flagDiff5)
        {
            flagDiff5 = false;
            difficultyScore += 1;
        }
        else if (currentScore > 100000 && flagDiff6)
        {
            flagDiff6 = false;
            difficultyScore += 1;
        }
    }

    public void StartGame()
    {
        isGameActive = true;
        Time.timeScale = 1;
        schemaPositionToFill = 0;
        moveTile = false;
    }

    public void GameOver()
    {
        isGameActive = false;
        Time.timeScale = 0;

        newSchemaList.Clear();
        currentSchemaList.Clear();
        schemaPositionToFill = 0;

        panelGameOver.SetActive(true);
        
        yourScoreText.SetText("Your Score: " + Mathf.Ceil(currentScore));
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
