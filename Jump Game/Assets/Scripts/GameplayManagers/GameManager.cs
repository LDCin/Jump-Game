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
        Time.timeScale = 0;
    }
    private void Start()
    {
        PanelManager.Instance.CloseAllPanel();
        PanelManager.Instance.OpenPanel(GameConfig.MENU_PANEL);
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
    public void PauseGame()
    {
        PanelManager.Instance.OpenPanel(GameConfig.PAUSE_PANEL);
        Time.timeScale = 0;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(GameConfig.GAME_SCENE);
    }
}
