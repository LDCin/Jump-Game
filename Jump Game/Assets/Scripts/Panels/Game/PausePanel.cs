using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : Panel
{
    [SerializeField] private GameObject _pauseBoard;
    private void OnEnable()
    {
        _pauseBoard.SetActive(true);
    }
    public void Resume()
    {
        SoundManager.Instance.PlayClickSound();
        PanelManager.Instance.OpenPanel(GameConfig.DEFAULT_PANEL);
        PanelManager.Instance.ClosePanel(GameConfig.PAUSE_PANEL);
        Time.timeScale = 1;
    }
    public void Setting()
    {
        SoundManager.Instance.PlayClickSound();
        PanelManager.Instance.OpenPanel(GameConfig.SETTING_PANEL);
    }
    public void BackToMenu()
    {
        SoundManager.Instance.PlayClickSound();
        PanelManager.Instance.CloseAllPanel();
        PanelManager.Instance.OpenPanel(GameConfig.MENU_PANEL);
    }
    public void CountdownToContinue()
    {
        
    }
}
