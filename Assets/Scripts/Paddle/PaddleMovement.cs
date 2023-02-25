using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] private float sideLimits = 11;

    #endregion

    #region Callbacks

    private void Update()
    {
        var currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);;
        
        MovePlayer(currentMousePos.x);
    }

    #endregion
    
    #region OtherMethods

    private void MovePlayer(float mousePosX)
    {
        var pos = transform.position;

        pos.x = mousePosX;
        var newPosX = Mathf.Clamp(pos.x, -sideLimits, sideLimits);
        
        transform.position = new Vector3(newPosX, pos.y, pos.z);
    }

    #endregion
}
