using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerGameplay : MonoBehaviour
{
    public GameObject lostPanel;
    public GameObject pausePanel;
    public GameObject verticalButtons;
    public GameObject horizontalButtons;

    public GameObject pauseButton;
    public GameObject endPanel;
    public GameObject winText;
    public GameObject lostText;

    public bool win;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (win == true)
        {

            horizontalButtons.SetActive(false);
            verticalButtons.SetActive(false);
            pauseButton.SetActive(false);
            endPanel.SetActive(true);
            winText.SetActive(true);
            lostText.SetActive(false);
            Time.timeScale = 0f;
            win = false;
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        horizontalButtons.SetActive(false);
        verticalButtons.SetActive(false);
        
    }


    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1; 
        horizontalButtons.SetActive(true);
        verticalButtons.SetActive(true);
    }

    public void MainMenu()
    {
       
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        lostPanel.SetActive(false);
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
       

 
}
