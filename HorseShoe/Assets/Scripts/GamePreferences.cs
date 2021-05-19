using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePreferences
{
    public static string highScore = "HighScore";

    public static int high_Score;

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.highScore);
    }

    public static void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.highScore, score);
    }


}
