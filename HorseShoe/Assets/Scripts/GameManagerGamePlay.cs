using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerGamePlay : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject pauseGameCanvas;

    public int score = 0;
    public Text scoreText;
    public Text finalScoreText;

    public Button pauseButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        finalScoreText.text = "Your final score is " + scoreText.text;
        Time.timeScale = 0f;
        Debug.Log("Gameover");
        pauseButton.gameObject.SetActive(false);

    }

    public void Retry_Button()
    {
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1f;
        score = 0;
        SceneManager.LoadScene("GamePlay");
        pauseButton.gameObject.SetActive(true);
    }

    public void MainMenu_Button()
    {
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1f;
        score = 0;
        SceneManager.LoadScene("MainMenu");
    }

    public void Pause_Button()
    {
        pauseGameCanvas.SetActive(true);
        Time.timeScale = 0f;

    }

    public void Continue_Button()
    {
        pauseGameCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void CheckHighScore()
    {
        if(score > GamePreferences.GetHighScore())
        {
            GamePreferences.SetHighScore(score);
        }
    }
    
}
