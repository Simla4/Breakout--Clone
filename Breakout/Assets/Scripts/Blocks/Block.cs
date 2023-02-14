using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour, ISpawn, IDespawn
{
    #region Variables

    [SerializeField] private BlockData blockData;
    [SerializeField] private SpriteRenderer blockSprite;

    private Pool<Block> blockPool;

    #endregion

    #region

    private void Start()
    {
        blockPool = PoolManager.Instance.blockPool;
    }

    private void OnEnable()
    {
        EventManager.OnBallCollisionBlock += RemoveBlock;
    }

    private void OnDisable()
    {
        EventManager.OnBallCollisionBlock -= RemoveBlock;
    }

    #endregion

    #region OtherMethods

    private void RemoveBlock()
    {
        blockPool.ReturnToPool(this);
    }

    public void OnSpawn()
    {
        gameObject.SetActive(true);
        
        var blockSpriteCount = blockData.blockSpriteList.Count;
        
        var rnd = Random.Range(0, blockSpriteCount);

        blockSprite.sprite = blockData.blockSpriteList[rnd];
    }
    
    public void OnDespawn()
    {
        gameObject.SetActive(false);
    }

    #endregion
}
