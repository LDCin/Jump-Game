using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ObstacleSpawner _obstacleSpawner;
    [SerializeField] private GameObject _deadZone;
    [SerializeField] private ScoreController _scoreController;
    public static GameManager _instance;
    private void Awake()
    {
        _instance = this;
        Time.timeScale = 1;
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
        OpenGameOverPanel();
        Time.timeScale = 0;
    }
    public void PauseGame()
    {

        Time.timeScale = 0f;
    }
    // Demo
    public void OpenGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
    }
    [SerializeField] private GameObject _gameOverPanel;
    public void RestartGame()
    {
        SceneManager.LoadScene(GameConfig.GAME_SCENE);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(GameConfig.MENU_SCENE);
    }
}
