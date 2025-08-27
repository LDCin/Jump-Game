using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : Panel
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    public void OnEnable()
    {
        _scoreText.text = GameConfig.GET_SCORE.ToString();
    }
    public void RestartGame()
    {
        Close();
        SceneManager.LoadScene(GameConfig.GAME_SCENE);
    }
    public void BackToMenu()
    {
        Close();
        PanelManager.Instance.CloseAllPanel();
        SceneManager.LoadScene(GameConfig.MENU_SCENE);
        PanelManager.Instance.OpenPanel(GameConfig.MENU_PANEL);
    }
}