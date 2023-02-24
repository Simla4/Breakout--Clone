using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private int health = 3;
    private int firstHealth;
    [SerializeField] private GameObject inGame;

    #endregion

    #region Callbacks

    private void Start()
    {
        firstHealth = health;
    }

    private void OnEnable()
    {
        EventManager.OnBallCollisionBorder += CalculateHealth;
        EventManager.OnGameWin += GameOver;
    }

    private void OnDisable()
    {
        EventManager.OnBallCollisionBorder -= CalculateHealth;
        EventManager.OnGameWin -= GameOver;
    }

    #endregion

    #region OtherMethods
    
    public void StartGame()
    {
        inGame.SetActive(true);
        Time.timeScale = 1;
        EventManager.OnGameStart?.Invoke();
    }
    
    private void GameOver()
    {
        Time.timeScale = 0;
        inGame.SetActive(false);
        health = firstHealth;
    }

    

    private void CalculateHealth()
    {
        health--;
        
        if (health <= 0)
        {
            EventManager.OnGameOver?.Invoke();
            PlayerPrefs.SetInt("Score", 0);
            
            GameOver();  
        }
    }

    #endregion
}
