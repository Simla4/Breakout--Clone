using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject startUI;
    [SerializeField] private GameObject inGameUI;
    [SerializeField] private GameObject failUI;
    [SerializeField] private GameObject winUI;

    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI firstScoreTxt;
    [SerializeField] private TextMeshProUGUI secondScoreTxt;
    [SerializeField] private TextMeshProUGUI thirtScoreTxt;

    #endregion

    #region Callbacks

    private void OnEnable()
    {
        EventManager.OnBlockCollisionBall += ChangeScoreTxt;
        EventManager.OnGameOver += ShowFailUI;
        EventManager.OnGameOver += ChangeHighScore;
        EventManager.OnGameOver += ShowWinUI;
    }

    private void OnDisable()
    {
        EventManager.OnBlockCollisionBall -= ChangeScoreTxt;
        EventManager.OnGameOver -= ShowFailUI;
        EventManager.OnGameOver -= ChangeHighScore;
        EventManager.OnGameOver -= ShowWinUI;
    }

    #endregion

    #region OtherMethods

    public void ShowStartUI()
    {
        scoreTxt.text = "0";
        failUI.SetActive(false);
        winUI.SetActive(false);
        startUI.SetActive(true);
    }

    public void ShowInGameUI()
    {
        startUI.SetActive(false);
        inGameUI.SetActive(true);
    }

    private void ShowWinUI()
    {
        inGameUI.SetActive(false);
        winUI.SetActive(true);
    }

    private void ShowFailUI()
    {
        inGameUI.SetActive(false);
        failUI.SetActive(true);
    }

    private void ChangeScoreTxt()
    {
        scoreTxt.text = PlayerPrefs.GetInt("Score").ToString();
    }

    private void ChangeHighScore()
    {
        var highScores = ScoreManager.Instance.highScores;
        firstScoreTxt.text = highScores[0].ToString();
        secondScoreTxt.text = highScores[1].ToString();
        thirtScoreTxt.text = highScores[2].ToString();
    }

    #endregion
}
