using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Variables

    [SerializeField] private BlockData blockData;

    [SerializeField] private SpriteRenderer blockSprite;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        var blockSpriteCount = blockData.blockSpriteList.Count;
        
        var rnd = Random.Range(0, blockSpriteCount);

        blockSprite.sprite = blockData.blockSpriteList[rnd];
    }
}
