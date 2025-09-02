using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : Panel
{
    [SerializeField] private TextMeshProUGUI _highScoreText;
    public void OnEnable()
    {
        Time.timeScale = 0;
        UpdateHighScoreText();
    }
    public void StartGame()
    {
        SoundManager.Instance.PlayClickSound();
        SceneManager.LoadScene(GameConfig.GAME_SCENE);
        PanelManager.Instance.ClosePanel(GameConfig.MENU_PANEL);
    }
    public void Shop()
    {
        SoundManager.Instance.PlayClickSound();
        PanelManager.Instance.OpenPanel(GameConfig.SHOP_PANEL);
    }
    public void Setting()
    {
        SoundManager.Instance.PlayClickSound();
        PanelManager.Instance.OpenPanel(GameConfig.SETTING_PANEL);
    }
    public void NoAds()
    {
        SoundManager.Instance.PlayClickSound();
        PanelManager.Instance.OpenPanel(GameConfig.NOADS_PANEL);
    }
    public void UpdateHighScoreText()
    {
        SoundManager.Instance.PlayClickSound();
        _highScoreText.text = GameConfig.GET_HIGH_SCORE.ToString();
    }
}
