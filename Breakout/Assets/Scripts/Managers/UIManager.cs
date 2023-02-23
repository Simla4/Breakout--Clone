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

    #endregion

    #region Callbacks

    private void OnEnable()
    {
        EventManager.OnBlockCollisionBall += ChangeScoreTxt;
        EventManager.OnGameOver += ShowFailUI;
        EventManager.OnGameWin += ShowWinUI;
    }

    private void OnDisable()
    {
        EventManager.OnBlockCollisionBall -= ChangeScoreTxt;
        EventManager.OnGameOver -= ShowFailUI;
        EventManager.OnGameWin -= ShowWinUI;
    }

    #endregion

    #region OtherMethods

    public void ShowStartUI()
    {
        failUI.SetActive(false);
        winUI.SetActive(true);
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

    #endregion
}
