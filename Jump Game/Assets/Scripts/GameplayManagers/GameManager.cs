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
    public void GainScore()
    {
        PlayerPrefs.SetInt("Score", GameConfig.SCORE);
    }
    public void GameOver()
    {
        PanelManager.Instance.OpenPanel(GameConfig.GAME_OVER_PANEL);
        Time.timeScale = 0;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(GameConfig.GAME_SCENE);
    }
}
