using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : Panel
{
    public void RestartGame()
    {
        Close();
        SceneManager.LoadScene(GameConfig.GAME_SCENE);
    }
    public void BackToMenu()
    {
        Close();
        PanelManager.Instance.OpenPanel(GameConfig.MENU_PANEL);
        SceneManager.LoadScene(GameConfig.MENU_SCENE);
    }
}