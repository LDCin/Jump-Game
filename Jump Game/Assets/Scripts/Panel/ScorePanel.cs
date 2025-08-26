using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score = -2;
    private void Awake()
    {
        _score = -1;
        _scoreText.text = (_score + 1).ToString();
    }
    private void Update()
    {
        if (_score.ToString() != _scoreText.text)
        {
            _scoreText.text = _score.ToString();
        }
    }
    public void UpdateHighScore()
    {
        if (_score > GameConfig.HIGH_SCORE)
        {
            PlayerPrefs.SetInt("HighScore", _score);
        }
    }
}