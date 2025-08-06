using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    [SerializeField] private List<Obstacle> _obstacleList;
    [SerializeField] private Obstacle _obstaclePrefab;
    [SerializeField] private int _poolSize = 5;

    private void Start()
    {
        _obstacleList = new List<Obstacle>();
        Vector2 spawnPosition = transform.position;
        for (int i = 0; i < _poolSize; i++)
        {
            Obstacle obstacle = Instantiate(_obstaclePrefab, spawnPosition, Quaternion.identity);
            _obstacleList.Add(obstacle);
            obstacle.gameObject.SetActive(false);
            spawnPosition -= new Vector2(Random.Range(-1f, 1f), 3);
        }
        ShowPool();
    }
    private void ShowPool()
    {
        foreach (var obstacle in _obstacleList)
        {
            obstacle.gameObject.SetActive(true);
        }
    }
}
