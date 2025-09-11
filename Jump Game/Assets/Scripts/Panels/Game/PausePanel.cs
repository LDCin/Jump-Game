using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : Panel
{
    [SerializeField] private GameObject _pauseBoard;
    [SerializeField] private GameObject _countdownBoard;
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    // private void OnEnable()
    // {
    //     _animator.SetTrigger("PopUp");
    // }
    public void Resume()
    {
        SoundManager.Instance.PlayClickSound();
        // _countdownBoard.SetActive(true);
        _animator.SetTrigger("Countdown");
    }
    public void Restart()
    {
        SceneManager.LoadScene(GameConfig.GAME_SCENE);
        Close();
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
    public void CountDownFinish()
    {
        Close();
        PanelManager.Instance.OpenPanel(GameConfig.DEFAULT_PANEL);
        Time.timeScale = 1;
    }
}
