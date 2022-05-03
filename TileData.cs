using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Scriptable Object", menuName = "Scriptable Object/TileData")]
public class TileData : ScriptableObject
{
    public float health;

    public TileBase[] tileBases;

//    public Sprite[] animatedSprites;
}
