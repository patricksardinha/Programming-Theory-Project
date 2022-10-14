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

    public GameObject panelShapesUIGrey;

    public int schemaPositionToFill;
    public List<string> currentSchemaList = new List<string>();
    public List<string> newSchemaList = new List<string>();

    public bool moveTile { get; set; }

    private void Start()
    {
        StartGame();

        schemaPositionToFill = 0;
        moveTile = false;
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
