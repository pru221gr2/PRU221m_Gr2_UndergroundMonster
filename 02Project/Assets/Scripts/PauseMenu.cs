﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    private Button PauseButton;
    private Button ResumeButton;
    private Button SaveAndQuitButton;
    private void Start()
    {
        PauseButton = gameObject.transform.Find("PauseButton").GetComponent<Button>();
        ResumeButton = PauseMenuUI.gameObject.transform.Find("Resume").GetComponent<Button>();
        SaveAndQuitButton = PauseMenuUI.gameObject.transform.Find("Quit").GetComponent<Button>();
    }
    void Update()
    {
        if (Time.timeScale==0f)
        {
            GameIsPaused = true;
        }
        else
        {
            GameIsPaused = false;
        }
        if (GameIsPaused)
        {
            PauseButton.gameObject.SetActive(false);
            ResumeButton.onClick.AddListener(Resume);
            SaveAndQuitButton.onClick.AddListener(SaveAndQuit);
        }
        else
        {
            PauseButton.gameObject.SetActive(true);
            PauseButton.onClick.AddListener(Pause);
        }
    }
    void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    void SaveAndQuit()
    {
        Application.Quit();
    }
    public void GoToMainMenu()
    {
        PlayerPrefs.DeleteAll();
        StartCoroutine(GoToMainMenuCoroutine());
    }
    IEnumerator GoToMainMenuCoroutine()
    {
        // Stop game a while 0.1s 
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(0.1f);
        // change scene
        SceneManager.LoadScene(0);
        // Kích hoạt lại game
        Time.timeScale = 1f;
    }
}
