using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiplayerMenu : MonoBehaviour
{
    //Load the Beginner Game
    public void ToBeginnerGame()
    {
        SceneManager.LoadScene("multiplayerScene");
    }
    //Load the Amateur Game
    public void ToAmateurGame()
    {
        SceneManager.LoadScene("Multiplayer - Amateur");
    }
    //Load the Professional Game
    public void ToProGame()
    {
        SceneManager.LoadScene("Multiplayer - Professional");
    }
    //Open the menu
    public void ToggleMenu()
    {
        gameObject.SetActive(true);
    }
    //Close the menu
    public void Return()
    {
        gameObject.SetActive(false);
    }
}
