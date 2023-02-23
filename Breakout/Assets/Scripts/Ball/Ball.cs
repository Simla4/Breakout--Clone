using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Callbacks

    private void OnEnable()
    {
        EventManager.OnBallCollisionBorder += DestroyBall;
    }

    private void OnDisable()
    {
        EventManager.OnBallCollisionBorder -= DestroyBall;
    }

    #endregion
    
    #region OtherMethods

    private void DestroyBall()
    {
        gameObject.SetActive(false);
        transform.position = new Vector3(0, 0, 0);
        gameObject.SetActive(true);
    }

    #endregion
}
