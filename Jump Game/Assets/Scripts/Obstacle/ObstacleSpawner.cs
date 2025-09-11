using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private ObstaclePool _obstaclePool;
    [SerializeField] private int _existNumber = 3;
    [SerializeField] private float _spawnDistance = 3f;
    private Vector2 _lastSpawnPos;
    private float _distanceOffset = 0;
    private void Awake()
    {
        ObstaclePool obstaclePool = Resources.Load<ObstaclePool>(GameConfig.OBSTACLE_PATH + GameConfig.OBSTACLE_POOL);
        ObstaclePool newObstaclePool = Instantiate(obstaclePool, transform);
        _obstaclePool = newObstaclePool;
        _lastSpawnPos.y = GameConfig.TOP_CAM - _spawnDistance;
        _lastSpawnPos.x = 0;
        _obstaclePool.ResetPool();
        
    }
    private void Start()
    {
        for (int i = 0; i < _existNumber; i++)
        {
            SpawnObstacle();
        }
    }
    private void LoadObstacle(Obstacle obstacle)
    {
        MapData mapData = CustomManager.Instance.GetMap(GameConfig.CURRENT_MAP_NAME);
        obstacle.SetSprite(mapData);
    }
    public void SpawnObstacle()
    {
        Obstacle obstacle = _obstaclePool.GetObstacle();
        if (ScoreManager.Instance.GetScore() >= ScoreManager.Instance._scoreLimit) obstacle.EnableChangeType();
        obstacle.gameObject.SetActive(true);
        LoadObstacle(obstacle);
        if (_distanceOffset == 0) _distanceOffset = obstacle.GetCollider2D().bounds.size.x;
        obstacle.gameObject.transform.position = _lastSpawnPos;
        _lastSpawnPos = new Vector2(Random.Range(GameConfig.LEFT_CAM + _distanceOffset, GameConfig.RIGHT_CAM - _distanceOffset), _lastSpawnPos.y - _spawnDistance);
    }
    
}