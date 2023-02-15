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
        EventManager.OnBallCollisionBlock += ChangeScoreTxt;
    }

    private void OnDisable()
    {
        EventManager.OnBallCollisionBlock -= ChangeScoreTxt;
    }

    #endregion

    #region OtherMethods

    private void ChangeScoreTxt()
    {
        scoreTxt.text = PlayerPrefs.GetInt("Score", 0).ToString();
    }

    #endregion
}
