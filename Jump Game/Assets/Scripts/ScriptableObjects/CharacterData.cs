using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Game Data/Character")]
public class CharacterData : ScriptableObject
{
    [Header("Basic Infor")]
    public string characterName;
    public Sprite icon;
    public Sprite sprite;
    [Header("Parts Of Body")]
    public Sprite head;
    public Sprite body;
    public Sprite leftArm;
    public Sprite rightArm;
    public Sprite leftLeg;
    public Sprite rightLeg;
    public Sprite tail;
    [Header("Animation")]
    public RuntimeAnimatorController characterAnimatorController;
}
