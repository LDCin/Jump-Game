using System.Collections;
using System.Collections.Generic;
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
    
    private Player _player;
    public override void Awake()
    {
        base.Awake();

        LoadTheme();
        InitObstacleSpawner();
        Time.timeScale = 1;
        LoadPlayer();
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
    // SET UP
    private void LoadPlayer()
    {
        CharacterData playerData = GameConfig.CURRENT_CHARACTER_DATA;

        _player = Instantiate(_playerPrefab, _playerSpawnPosition.transform.position, Quaternion.identity);

        _player.transform.Find("Head").GetComponent<SpriteRenderer>().sprite = playerData.head;
        _player.transform.Find("Body").GetComponent<SpriteRenderer>().sprite = playerData.body;
        _player.transform.Find("LeftArm").GetComponent<SpriteRenderer>().sprite = playerData.leftArm;
        _player.transform.Find("RightArm").GetComponent<SpriteRenderer>().sprite = playerData.rightArm;
        _player.transform.Find("Tail").GetComponent<SpriteRenderer>().sprite = playerData.tail;
        _player.transform.Find("LeftLeg").GetComponent<SpriteRenderer>().sprite = playerData.leftLeg;
        _player.transform.Find("RightLeg").GetComponent<SpriteRenderer>().sprite = playerData.rightLeg;

        Animator animator = _player.GetComponent<Animator>();
        animator.runtimeAnimatorController = playerData.characterAnimatorController;

        GameConfig.CAM_POSITION_MOVEMENT = _player.transform.position.y;
    }
    private void LoadTheme()
    {
        MapData mapData = GameConfig.CURRENT_MAP_DATA;
        _background.transform.GetComponent<SpriteRenderer>().sprite = mapData.backgroundImage;
        _leftWall.transform.GetComponent<SpriteRenderer>().sprite = mapData.leftWallImage;
        _rightWall.transform.GetComponent<SpriteRenderer>().sprite = mapData.rightWallImage;
    }
    public Player GetPlayer()
    {
        return _player;
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
