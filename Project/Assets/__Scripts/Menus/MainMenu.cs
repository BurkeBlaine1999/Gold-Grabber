using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //Variables
    public Text highScoreText;

    //Retrieve the current local highscore
    void Start()
    {
        highScoreText.text = "Highscore : " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
    }

    //Open the main menu
    public void OpenMainMenu()
    {
        gameObject.SetActive(true);
    }
    //Close the main menu
    public void CloseMainMenu()
    {
        gameObject.SetActive(false);
    }
    //Exit the Application
    public void QuitGame()
    {
        Application.Quit();
    }
}
