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

    #region Callbacks

    private void Start()
    {
        blockPool = PoolManager.Instance.blockPool;
    }

    #endregion

    #region OtherMethods
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
