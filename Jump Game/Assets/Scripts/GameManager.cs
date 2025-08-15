using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ObstacleSpawner _obstacleSpawner;
    [SerializeField] private GameObject _deadZone;
    [SerializeField] private ScoreController _scoreController;
    public static GameManager _instance;
    private void Awake()
    {
        _instance = this;
    }
    public void SpawnAfterJump()
    {
        _obstacleSpawner.SpawnObstacle();
    }
    public void GainScore()
    {
        _scoreController.GainPoint();
    }
    public void GameOver()
    {
        Time.timeScale = 0;
    }
}
