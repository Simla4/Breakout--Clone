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

    private void Start()
    {
        ApplyForce();
    }

    #endregion

    #region OtherMethods

    private void ApplyForce()
    {
        var force = Vector2.down;
        
        rb.AddForce(force * ballSpeed);
    }
    
    #endregion
}
