using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Variables

    private Pool<Block> blockPool;

    #endregion

    #region MyRegion

    private void Start()
    {
        blockPool = PoolManager.Instance.blockPool;

        blockPool.Spawn();
    }

    #endregion

    #region OtherMethods

    

    #endregion
}
