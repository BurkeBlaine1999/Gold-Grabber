using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private float score = 0f;
    public Text scoreText;

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 10;
    private int coinCounter = 0;
    private int coinValue;

    private bool isDead = false;
    public DeathMenu deathMenu;

    public AudioSource audioSource;
    public AudioClip coins;
    public string Beginner, Amateur,Professional;
    void Start(){
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == Beginner)
        {
            coinValue = 50;
        }else if (scene.name == Amateur)
        {
            coinValue = 100;
        }else 
        {
            coinValue = 150;
        }
    }

    void Update(){

        if(isDead)
            return;

        if(score >= scoreToNextLevel){
            LevelUp();
        }

        score+= Time.deltaTime;
        scoreText.text = ((int)score).ToString();

    }
    
    void LevelUp(){
        if(difficultyLevel == maxDifficultyLevel){
            return;
        }

        scoreToNextLevel = scoreToNextLevel * 2 + (50 * difficultyLevel);
        difficultyLevel++;

        GetComponent<CharController>().SetSpeed(difficultyLevel);
        Debug.Log(difficultyLevel);
    }

    public void OnDeath(){
        isDead = true;
        if(PlayerPrefs.GetFloat("Highscore") < score)
            PlayerPrefs.SetFloat("Highscore",score);       

        deathMenu.ToggleEndMenu(score);
    }


    private void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Gold"){
            coinCounter++;
            audioSource.PlayOneShot(coins);
            if(coinCounter == 10){
                coinCounter = 0;
                score += (coinValue * 2);
            }else{
                score += coinValue;
            }
            Destroy(hit.gameObject);
        }

    }
}

