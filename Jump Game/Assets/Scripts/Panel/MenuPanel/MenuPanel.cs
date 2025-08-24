using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : Panel
{
    public void StartGame()
    {
        SceneManager.LoadScene(GameConfig.GAME_SCENE);
        PanelManager.Instance.CloseAllPanel();
        GameManager.Instance.InitObstacleSpawner();
        Time.timeScale = 1;
    }
    public void Shop()
    {
        PanelManager.Instance.OpenPanel(GameConfig.SHOP_PANEL);
    }
    public void Setting()
    {
        PanelManager.Instance.OpenPanel(GameConfig.SETTING_PANEL);
    }
    public void NoAds()
    {
        PanelManager.Instance.OpenPanel(GameConfig.NOADS_PANEL);
    }
}
