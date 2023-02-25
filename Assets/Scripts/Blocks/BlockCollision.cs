using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{
    [SerializeField] private Block block;

    private Pool<Block> blockPool;

    private void Start()
    {
        blockPool = PoolManager.Instance.blockPool;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        blockPool.ReturnToPool(block);
        
        EventManager.OnBlockCollisionBall?.Invoke();
    }
}
