using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private int health = 3;

    #endregion

    #region Callbacks

    private void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
    }

    private void OnEnable()
    {
        EventManager.OnBlockCollisionBall += CalculateScore;
        EventManager.OnBallCollisionBorder += CalculateHealth;
    }

    private void OnDisable()
    {
        EventManager.OnBlockCollisionBall -= CalculateScore;
        EventManager.OnBallCollisionBorder -= CalculateHealth;
    }

    #endregion

    #region OtherMethods

    private void CalculateScore()
    {
        var score = PlayerPrefs.GetInt("Score");

        score += 10;

        PlayerPrefs.SetInt("Score", score);
        
        Debug.Log("Score: " + score);
    }

    private void CalculateHealth()
    {
        health--;
        
        if (health <= 0)
        {
            EventManager.OnGameOver?.Invoke();
            PlayerPrefs.SetInt("Score", 0);
            
            Debug.Log("Game Over");    
        }
    }

    #endregion
}
