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
        SoundManager.Instance.PlayGameOverSound();
        _scoreText.text = GameConfig.GET_SCORE.ToString();
    }
    public void RestartGame()
    {
        SoundManager.Instance.PlayClickSound();
        Close();
        SceneManager.LoadScene(GameConfig.GAME_SCENE);
    }
    public void BackToMenu()
    {
        SoundManager.Instance.PlayClickSound();
        Close();
        PanelManager.Instance.CloseAllPanel();
        SceneManager.LoadScene(GameConfig.MENU_SCENE);
        PanelManager.Instance.OpenPanel(GameConfig.MENU_PANEL);
    }
}