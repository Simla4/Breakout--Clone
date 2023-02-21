using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public static Action<float> OnBallCollisionPaddle;
    public static Action OnBlockCollisionBall;
    public static Action OnBallCollisionBorder;
    public static Action OnGameOver;
}
