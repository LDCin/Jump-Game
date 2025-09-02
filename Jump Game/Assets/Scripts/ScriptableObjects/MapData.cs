using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewBackground", menuName = "Game Data/Background")]
public class MapData : ScriptableObject
{
    [Header("Basic Infor")]
    public string characterName;
    public Image backgroundImage;
    public Image obstacleImage;
    [Header("Animation")]
    public RuntimeAnimatorController obstacleAnimatorController;
}
