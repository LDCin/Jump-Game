using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    private int _score = 0;
    public bool _isShownPerfect = false;
    public int _scoreLimit = 11;
    public override void Awake()
    {
        base.Awake();
        _score = 0;
        UpdateScore(0);
    }
    public void UpdateScore(int scoreDelta)
    {
        SetScore(_score + scoreDelta);
        PlayerPrefs.SetInt(GameConfig.SCORE, _score);
    }
    public void UpdateHighScore()
    {
        if (_score > GameConfig.GET_HIGH_SCORE)
        {
            PlayerPrefs.SetInt("HighScore", _score);
        }
    }
    public int GetScore()
    {
        return _score;
    }
    public void SetScore(int newScore)
    {
        _score = newScore;
    }
}