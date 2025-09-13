using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private ObstacleSpawner _obstacleSpawner;
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private GameObject _playerSpawnPosition;
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _leftWall;
    [SerializeField] private GameObject _rightWall;
    public override void Awake()
    {
        base.Awake();
        LoadTheme();
        InitObstacleSpawner();
        Time.timeScale = 1;
    }
    public void Start()
    {
        ScoreManager.Instance.SetScore(0);
        ScoreManager.Instance.UpdateScore(0);
        PanelManager.Instance.OpenPanel(GameConfig.DEFAULT_PANEL);
    }
    public void InitObstacleSpawner()
    {
        ObstacleSpawner obstacleSpawner = Resources.Load<ObstacleSpawner>(GameConfig.OBSTACLE_PATH + GameConfig.OBSTACLE_SPAWNER);
        ObstacleSpawner newObstacleSpawner = Instantiate(obstacleSpawner, transform);
        _obstacleSpawner = newObstacleSpawner;
    }
    // SET UP
    public void LoadPlayer(GameObject head, GameObject body, GameObject leftArm, GameObject rightArm, GameObject tail, GameObject leftLeg, GameObject rightLeg, Animator animator)
    {
        CharacterData playerData = GameConfig.CURRENT_CHARACTER_DATA;
        
        head.GetComponent<SpriteRenderer>().sprite = playerData.head;

        body.GetComponent<SpriteRenderer>().sprite = playerData.body;
        
        leftArm.GetComponent<SpriteRenderer>().sprite = playerData.leftArm;
        rightArm.GetComponent<SpriteRenderer>().sprite = playerData.rightArm;
        tail.GetComponent<SpriteRenderer>().sprite = playerData.tail;
        leftLeg.GetComponent<SpriteRenderer>().sprite = playerData.leftLeg;
        rightLeg.GetComponent<SpriteRenderer>().sprite = playerData.rightLeg;

        animator.runtimeAnimatorController = playerData.characterAnimatorController;

        GameConfig.CAM_POSITION_MOVEMENT = _playerSpawnPosition.transform.position.y;
    }
    private void LoadTheme()
    {
        MapData mapData = GameConfig.CURRENT_MAP_DATA;
        _background.transform.GetComponent<SpriteRenderer>().sprite = mapData.backgroundImage;
        _leftWall.transform.GetComponent<SpriteRenderer>().sprite = mapData.leftWallImage;
        _rightWall.transform.GetComponent<SpriteRenderer>().sprite = mapData.rightWallImage;
    }

    // GAMEPLAY
    public void SpawnAfterJump()
    {
        _obstacleSpawner.SpawnObstacle();
    }
    public void JumpPerfectly()
    {
        ScoreManager.Instance._isShownPerfect = true;
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
