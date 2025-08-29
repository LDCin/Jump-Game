using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultPanel : Panel
{
    public void PauseGame()
    {
        SoundManager.Instance.PlayClickSound();
        PanelManager.Instance.ClosePanel(GameConfig.DEFAULT_PANEL);
        PanelManager.Instance.OpenPanel(GameConfig.PAUSE_PANEL);
        Time.timeScale = 0;
    }
}
