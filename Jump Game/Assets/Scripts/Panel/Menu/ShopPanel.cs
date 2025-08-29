using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : Panel
{
    public void BackToMenu()
    {
        SoundManager.Instance.PlayClickSound();
        Close();
    }
}