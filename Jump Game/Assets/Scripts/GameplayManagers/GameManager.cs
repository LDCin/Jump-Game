using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ObstacleSpawner _obstacleSpawner;
    [SerializeField] private GameObject _deadZone;
    public static GameManager _instance;
    private void Awake()
    {
        _instance = this;
        Time.timeScale = 0;
    }
    private void Start()
    {
        PanelManager._instance.CloseAllPanel();
        PanelManager._instance.OpenPanel(GameConfig.MENU_PANEL);
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
        PanelManager._instance.OpenPanel(GameConfig.GAME_OVER_PANEL);
        Time.timeScale = 0;
    }
    public void PauseGame()
    {
        PanelManager._instance.OpenPanel(GameConfig.PAUSE_PANEL);
        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(GameConfig.GAME_SCENE);
    }
}
