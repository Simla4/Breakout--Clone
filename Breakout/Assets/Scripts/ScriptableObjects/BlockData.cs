using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BlockData", menuName = "ScriptableObjects/BlockData", order = 1)]
public class BlockData : ScriptableObject
{
    public List<Sprite> blockSpriteList;
}
