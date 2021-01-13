using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{

    //Load the Beginner Game
    public void ToBeginnerGame()
    {
        SceneManager.LoadScene("Beginner");
    }
    //Load the Amateur Game
    public void ToAmateurGame()
    {
        SceneManager.LoadScene("Amateur");
    }
    //Load the Professional Game
    public void ToProGame()
    {
        SceneManager.LoadScene("Professional");
    }
    //Open the game menu
    public void ToggleGameMenu()
    {
        gameObject.SetActive(true);
    }
    //Close the game menu
    public void Return()
    {
        gameObject.SetActive(false);
    }

}
