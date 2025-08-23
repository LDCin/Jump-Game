using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : Panel
{
    public void Resume()
    {
        PanelManager._instance.ClosePanel(GameConfig.PAUSE_PANEL);
    }
    public void Setting()
    {
        PanelManager._instance.OpenPanel(GameConfig.SETTING_PANEL);
    }
    public void BackToMenu()
    {
        PanelManager._instance.OpenPanel(GameConfig.MENU_PANEL);
    }
}
