using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoAdsPanel : Panel
{
    public void BackToMenu()
    {
        SoundManager.Instance.PlayClickSound();
        Close();
    }
}