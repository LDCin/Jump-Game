using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : Panel
{
    public void Resume()
    {
        PanelManager.Instance.OpenPanel(GameConfig.DEFAULT_PANEL);
        PanelManager.Instance.ClosePanel(GameConfig.PAUSE_PANEL);
        Time.timeScale = 1;
    }
    public void Setting()
    {
        PanelManager.Instance.OpenPanel(GameConfig.SETTING_PANEL);
    }
    public void BackToMenu()
    {
        PanelManager.Instance.CloseAllPanel();
        PanelManager.Instance.OpenPanel(GameConfig.MENU_PANEL);
    }
}
