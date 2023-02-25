using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private AudioSource audioSource;

    #endregion

    #region Callbacks

    private void OnEnable()
    {
        EventManager.OnBlockCollisionBall += PlayAudio;
    }

    private void OnDisable()
    {
        EventManager.OnBlockCollisionBall -= PlayAudio;
    }

    #endregion

    #region OtherMethods

    private void PlayAudio()
    {
        audioSource.Play(0);
    }

    #endregion
}
