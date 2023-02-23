using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private int blockCount = 10;
    [SerializeField] private Vector2 distance = new Vector2(2.8f, -0.8f);
    
    private Pool<Block> blockPool;

    #endregion

    #region MyRegion

    private void Start()
    {
        blockPool = PoolManager.Instance.blockPool;
    }

    private void OnEnable()
    {
        EventManager.OnGameStart += CreateLevel;
        EventManager.OnGameOver += DestroyLevel;
        EventManager.OnBlockCollisionBall += CheckLevel;
    }

    private void OnDisable()
    {
        EventManager.OnGameStart -= CreateLevel;
        EventManager.OnGameOver -= DestroyLevel;
        EventManager.OnBlockCollisionBall -= CheckLevel;
    }

    #endregion

    #region OtherMethods

    private void CreateLevel()
    {
        var firstPos = new Vector2(-7, 3.8f);
        
        for (int i = 0; i < blockCount; i++)
        {
            
            var block = blockPool.Spawn();
            block.transform.position = firstPos;

            firstPos.x += distance.x;

            Debug.Log("first Pos: " + firstPos);

            if (block.transform.position.x >= 7)
            {
                firstPos = new Vector2(-7, firstPos.y - distance.y);
            }
            
        }
    }

    private void CheckLevel()
    {
        if (blockPool.IsListEmpty() == true)
        {
            EventManager.OnGameWin?.Invoke();
        }
    }

    private void DestroyLevel()
    {
        blockPool.ReturnAll();
    }

    #endregion
}
