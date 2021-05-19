using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Start_Button()
    {
        SceneManager.LoadScene("Gameplay");

    }

    public void Settings_Button()
    {

    }
}
