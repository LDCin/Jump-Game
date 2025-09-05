using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewBackground", menuName = "Game Data/Background")]
public class MapData : ScriptableObject
{
    [Header("Basic Infor")]
    public string mapName;
    public Sprite icon;
    public Sprite backgroundImage;
    public Sprite obstacleImage;
    [Header("Animation")]
    public RuntimeAnimatorController obstacleAnimatorController;
}
