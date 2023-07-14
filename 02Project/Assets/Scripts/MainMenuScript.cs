using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1.0f;
    }

    public void AboutUs()
    {
        SceneManager.LoadScene("Credit");
    }    
    public void Guideline()
    {
        SceneManager.LoadScene("Guidance");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
