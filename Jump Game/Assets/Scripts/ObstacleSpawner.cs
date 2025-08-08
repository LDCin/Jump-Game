using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private ObstaclePool _obstaclePool;
    private int _existNumber = 3;
    private Vector2 _lastSpawnPos = new Vector2(0, 1);
    private void Start()
    {
        for (int i = 0; i < _existNumber; i++)
        {
            Obstacle obstacle = _obstaclePool.GetObstacle();
            obstacle.gameObject.SetActive(true);

            obstacle.gameObject.transform.position = _lastSpawnPos;
            _lastSpawnPos -= new Vector2(Random.Range(-2, 2), 3f);
        }
    }

}