using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Paddle"))
        {
            var paddlePos = col.gameObject.transform.position;
            
            EventManager.OnBallCollisionPaddle?.Invoke(paddlePos.x);
        }
        else if(col.gameObject.CompareTag("Border"))
        {
            EventManager.OnBallCollisionBorder?.Invoke();
        }
    }
}
