using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public Text scoreText;
    public Image backgroundImage;
    public bool IsShown = false;
    public float transition =0.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }
    
    //Open the death Menu
    public void ToggleEndMenu(float score){
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
        IsShown =true;
    }

    //Reload/Restart the scene
    public void Restart(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Return to the main menu
    public void ToMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
