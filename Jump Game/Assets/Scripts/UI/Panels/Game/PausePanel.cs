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
    IEnumerator CountdownCoroutine()
    {
        _animator.SetTrigger("Countdown");
        yield return new WaitForSecondsRealtime(3.5f);
        PanelManager.Instance.OpenPanel(GameConfig.DEFAULT_PANEL);
        Time.timeScale = 1;
        Close();
    }
    public void ShowCountdownBoard()
    {
        _countdownBoard.SetActive(true);
    }
    public void HideCountdownBoard()
    {
        _countdownBoard.SetActive(false);
    }
    public void Resume()
    {
        SoundManager.Instance.PlayClickSound();
        StartCoroutine(CountdownCoroutine());
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
}
