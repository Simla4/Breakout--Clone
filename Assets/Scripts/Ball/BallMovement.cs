using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] private int ballSpeed;
    [SerializeField] private Rigidbody2D rb;

    #endregion

    #region Calllbacks

    private void OnEnable()
    {
        EventManager.OnBallCollisionPaddle += ApplyForce;
        EventManager.OnBallCollisionBorder += ApplyFirstForce;
        EventManager.OnGameStart += ApplyFirstForce;
    }

    private void OnDisable()
    {
        EventManager.OnBallCollisionPaddle -= ApplyForce;
        EventManager.OnBallCollisionBorder -= ApplyFirstForce;
        EventManager.OnGameStart -= ApplyFirstForce;
    }

    private void Start()
    {
        ApplyFirstForce();
    }

    #endregion

    #region OtherMethods

    private void ApplyFirstForce()
    {
        var force = Vector2.down;
        
        rb.AddForce(force * ballSpeed);
    }

    private void ApplyForce(float paddlePos)
    {
        var ballPos = transform.position;
        var distance = ballPos.x - paddlePos;
        var newSpeed = ballSpeed / Mathf.Abs(distance);
        rb.velocity = Vector2.zero;

        if (distance < -0.2f || distance > 0.2f)
        {
            rb.AddForce(new Vector2(distance * newSpeed, ballSpeed));
        }
        else
        {
            rb.AddForce(Vector2.up * ballSpeed);
        }
    }
    
    #endregion
}
