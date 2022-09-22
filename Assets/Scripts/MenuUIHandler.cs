using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameText;
    public static string namePlayer;

    void Start()
    {
        LoadNamePlayer();
    }

    public void StartGame()
    {
        namePlayer = nameText.text;
        SaveNamePlayer();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        // Application.Quit(); // for exiting app in build mode
        EditorApplication.ExitPlaymode(); // for exiting app in editor testing mode
    }

    public void LoadNamePlayer()
    {
        nameText.text = MenuManager.Instance.LoadNamePlayer();
    }

    public void SaveNamePlayer()
    {
        MenuManager.Instance.SaveNamePlayer();
    }
}
