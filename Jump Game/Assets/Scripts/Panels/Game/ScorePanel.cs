using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : Panel
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Image _perfectEffect;
    [SerializeField] private float _timeExist;
    private float _currentTimeExist = 2;
    public void Update()
    {
        _scoreText.text = GameConfig.GET_SCORE.ToString();
        if (ScoreManager.Instance._isShownPerfect)
        {
            ShowPerfectEffect();
            _currentTimeExist += Time.deltaTime;
        }
        if (_currentTimeExist >= _timeExist)
        {
            HidePerfectEffect();
        }
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
}