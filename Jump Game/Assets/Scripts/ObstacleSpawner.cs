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
        _lastSpawnPos.y = GameConfig.topCam - _spawnDistance;
        _lastSpawnPos.x = 0;
        // _obstaclePool.SetObstacleIsActive(_existNumber);
        _obstaclePool.ResetPool();
        for (int i = 0; i < _existNumber; i++)
        {
            SpawnObstacle();
        }
    }
    // private void Start()
    // {
    //     _lastSpawnPos.y = GameConfig.topCam - _spawnDistance;
    //     _lastSpawnPos.x = 0;
    //     _obstaclePool.SetObstacleIsActive(_existNumber);
    //     for (int i = 0; i < _existNumber; i++)
    //     {
    //         SpawnObstacle();
    //     }
    // }
    public void SpawnObstacle()
    {
        Obstacle obstacle = _obstaclePool.GetObstacle();
        obstacle.gameObject.SetActive(true);
        if (_distanceOffset == 0) _distanceOffset = obstacle.GetCollider2D().bounds.size.x / 2;
        obstacle.gameObject.transform.position = _lastSpawnPos;
        _lastSpawnPos = new Vector2(Random.Range(GameConfig.leftCam + _distanceOffset, GameConfig.rightCam - _distanceOffset), _lastSpawnPos.y - _spawnDistance);
    }
    
}