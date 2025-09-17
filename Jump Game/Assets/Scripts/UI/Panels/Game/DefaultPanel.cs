using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DefaultPanel : Panel
{
    public static DefaultPanel Instance;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Image _perfectEffect;
    [SerializeField] private float _timeExist;
    private float _currentTimeExist = 2;
    private void Awake()
    {
        Instance = this;
    }
    public void Update()
    {
        if (ScoreManager.Instance._isShownPerfect)
        {
            Debug.Log("TIME " + _currentTimeExist);
            ShowPerfectEffect();
            _currentTimeExist += Time.deltaTime;
        }
        if (_currentTimeExist >= _timeExist)
        {
            Debug.Log("TIME2 " + _currentTimeExist);
            HidePerfectEffect();
        }
    }
    public void UpdateScoreText()
    {
        _scoreText.text = GameConfig.GET_SCORE.ToString();
    }
    private void OnEnable()
    {
        _scoreText.text = GameConfig.GET_SCORE.ToString();
    }
    public void ShowPerfectEffect()
    {
        _perfectEffect.gameObject.SetActive(true);
    }
    public void HidePerfectEffect()
    {
        _perfectEffect.gameObject.SetActive(false);
        ScoreManager.Instance._isShownPerfect = false;
        _currentTimeExist = 0;
    }
    public void PauseGame()
    {
        SoundManager.Instance.PlayClickSound();
        PanelManager.Instance.ClosePanel(GameConfig.DEFAULT_PANEL);
        PanelManager.Instance.OpenPanel(GameConfig.PAUSE_PANEL);
        Time.timeScale = 0;
    }
}
