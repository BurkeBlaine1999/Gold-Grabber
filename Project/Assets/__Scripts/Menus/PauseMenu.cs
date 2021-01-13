using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Variables
    public static bool isPaused = false;

    //Check if the game is paused
    public bool GameIsPaused()
    {
        return isPaused;
    }

    //Open the pause menu and stop time
    public void TogglePauseMenu(float score)
    {
        isPaused = true;
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    //Close the pause menu and resume time
    public void Resume()
    {
        isPaused = false;
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    //Reload/Restart the current scene
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    //Exit to the main menu
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
