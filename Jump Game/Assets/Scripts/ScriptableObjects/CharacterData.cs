using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Game Data/Character")]
public class CharacterData : ScriptableObject
{
    [Header("Basic Infor")]
    public string characterName;
    public Image image;
    [Header("Animation")]
    public RuntimeAnimatorController characterAnimatorController;
}
