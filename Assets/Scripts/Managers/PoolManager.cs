using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PoolManager: MonoSingleton<PoolManager>
{
    public Pool<Block> blockPool { get; } = new Pool<Block>();
    [SerializeField] private Block blockPrefab;
    private void Awake()
    {
        blockPool.Initialize(blockPrefab);
    }
}