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
    }

    private void OnDisable()
    {
        EventManager.OnBlockCollisionBall -= ChangeScoreTxt;
        EventManager.OnGameOver -= ShowFailUI;
    }

    #endregion

    #region OtherMethods

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
