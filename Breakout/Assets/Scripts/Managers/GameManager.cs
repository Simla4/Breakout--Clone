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
        PlayerPrefs.GetInt("Score", 0);
    }

    private void OnEnable()
    {
        EventManager.OnBallCollisionBlock += CalculateScore;
    }

    private void OnDisable()
    {
        EventManager.OnBallCollisionBlock -= CalculateScore;
    }

    #endregion

    #region OtherMethods

    private void CalculateScore()
    {
        var score = PlayerPrefs.GetInt("Score", 0);

        score += 10;

        PlayerPrefs.SetInt("Score", 0);
        
        Debug.Log("Score: " + score);
    }

    private void Health()
    {
        
    }

    #endregion
}
