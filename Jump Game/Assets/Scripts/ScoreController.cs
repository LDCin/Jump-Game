using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score = 0;
    private void Awake()
    {
        _score = 0;
        _scoreText.text = _score.ToString();
    }
    
    public void GainPoint()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }
    
}
