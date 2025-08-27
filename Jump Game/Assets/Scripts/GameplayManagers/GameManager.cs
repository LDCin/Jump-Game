using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private ObstacleSpawner _obstacleSpawner;
    public override void Awake()
    {
        base.Awake();
        InitObstacleSpawner();
        Time.timeScale = 1;
    }
    public void Start()
    {
        ScoreManager.Instance.SetScore(0);
        ScoreManager.Instance.UpdateScore(0);
        PanelManager.Instance.OpenPanel(GameConfig.DEFAULT_PANEL);
        PanelManager.Instance.OpenPanel(GameConfig.SCORE_PANEL);
    }
    public void InitObstacleSpawner()
    {
        ObstacleSpawner obstacleSpawner = Resources.Load<ObstacleSpawner>(GameConfig.OBSTACLE_PATH + GameConfig.OBSTACLE_SPAWNER);
        ObstacleSpawner newObstacleSpawner = Instantiate(obstacleSpawner, transform);
        _obstacleSpawner = newObstacleSpawner;
    }
    public void SpawnAfterJump()
    {
        _obstacleSpawner.SpawnObstacle();
    }
    public void GainScore(int scoreDelta)
    {
        ScoreManager.Instance.UpdateScore(scoreDelta);
        ScoreManager.Instance.UpdateHighScore();
    }
    public void GameOver()
    {
        PanelManager.Instance.OpenPanel(GameConfig.GAME_OVER_PANEL);
        Time.timeScale = 0;
    }
    public void RestartGame()
    {
        SoundManager.Instance.PlayClickSound();
        SceneManager.LoadScene(GameConfig.GAME_SCENE);
    }
}
