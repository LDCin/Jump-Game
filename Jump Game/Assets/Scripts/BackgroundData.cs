using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Background", menuName = "BackgroundData", order = 1)]
public class BackgroundData : ScriptableObject
{
    public int id;
    public Sprite backgroundSprite;
    public Sprite wallSprite;
}
