using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score = -1;
    private void Awake()
    {
        _score = 0;
        _scoreText.text = (_score + 1).ToString();
    }
    public void GainPoint()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }
    public void UpdateHighScore()
    {
        if (_score > GameConfig.HIGH_SCORE)
        {
            PlayerPrefs.SetInt("HighScore", _score);
        }
    }
}