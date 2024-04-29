using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{   
    public bool gameStarted;
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    private void Awake()
    {
        highscoreText.text="Highscore:"+ GetHighScore().ToString();

    }

    public void StartGame()
    {
        gameStarted = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            StartGame();
        }
    }
    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    public void IncreaseScore() {
        score++;
        scoreText.text=score.ToString();

        //player prefs to store small amounts of data
        if (score > GetHighScore()){
            PlayerPrefs.SetInt("Highscore",score);
            highscoreText.text="Highscorre:"+score.ToString();

        }


            }
    public void DecreaseScore()
    {
        score--;
        scoreText.text = score.ToString();
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    public int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("Highscore");
        return i;
    }

}
