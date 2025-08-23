using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : Panel
{
    public void StartGame()
    {
        PanelManager._instance.ClosePanel(name);
        Time.timeScale = 1f;
    }
    public void Shop()
    {
        PanelManager._instance.OpenPanel(GameConfig.SHOP_PANEL);
    }
    public void Setting()
    {
        PanelManager._instance.OpenPanel(GameConfig.SETTING_PANEL);
    }
    public void NoAds()
    {
        PanelManager._instance.OpenPanel(GameConfig.NOADS_PANEL);
    }
    public void BackToMenu()
    {
        PanelManager._instance.ClosePanel(GameConfig.MENU_PANEL_PATH + name);
    }
}
