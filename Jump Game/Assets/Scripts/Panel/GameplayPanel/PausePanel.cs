using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : Panel
{
    public void Resume()
    {
        PanelManager.Instance.ClosePanel(GameConfig.PAUSE_PANEL);
    }
    public void Setting()
    {
        PanelManager.Instance.OpenPanel(GameConfig.SETTING_PANEL);
    }
    public void BackToMenu()
    {
        PanelManager.Instance.OpenPanel(GameConfig.MENU_PANEL);
    }
}
