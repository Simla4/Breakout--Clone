using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoSingleton<ScoreManager>
{
    #region Variables

    public int[] highScores = {0, 0, 0};

    #endregion

    #region Callbacks

    private void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
    }

    private void OnEnable()
    {
        EventManager.OnBlockCollisionBall += CalculateScore;
        EventManager.OnGameOver += GetHighScores;
    }

    private void OnDisable()
    {
        EventManager.OnBlockCollisionBall -= CalculateScore;

        EventManager.OnGameOver -= GetHighScores;
    }

    #endregion

    #region OtherMethods

    private void GetHighScores()
    {
        var currentScore = PlayerPrefs.GetInt("Score", 0);
        
        for (int i = 0; i < highScores.Length; i++)
        {
            if (currentScore > highScores[0])
            {

                if (i == 0)
                {
                    highScores[2] = highScores[1];
                    highScores[1] = highScores[0];
                }
                else if (i == 1)
                {
                    highScores[2] = highScores[1];
                }
                
                highScores[i] = currentScore;
                
                break;
            }
        }
    }
    
    private void CalculateScore()
    {
        var score = PlayerPrefs.GetInt("Score");

        score += 10;

        PlayerPrefs.SetInt("Score", score);
        
        Debug.Log("Score: " + score);
    }

    #endregion
}
