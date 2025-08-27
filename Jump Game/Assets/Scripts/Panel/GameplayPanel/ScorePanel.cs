using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePanel : Panel
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private void OnEnable()
    {
        _scoreText.text = GameConfig.GET_SCORE.ToString();
    }
    private void Update()
    {
        _scoreText.text = GameConfig.GET_SCORE.ToString();
    }
}