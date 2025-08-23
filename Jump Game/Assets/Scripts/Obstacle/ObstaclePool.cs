using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    [SerializeField] private List<Obstacle> _obstacleList;
    [SerializeField] private Obstacle _obstaclePrefab;
    [SerializeField] private int _poolSize = 10;
    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        _obstacleList = new List<Obstacle>(0);
        for (int i = 0; i < _poolSize; i++)
        {
            Obstacle obstacle = Instantiate(_obstaclePrefab);
            _obstacleList.Add(obstacle);
            obstacle.gameObject.SetActive(false);
        }
    }
    public Obstacle GetObstacle()
    {
        if (_obstacleList == null) Init();
        foreach (var obstacle in _obstacleList)
        {
            if (!obstacle.gameObject.activeInHierarchy)
            {
                return obstacle;
            }
        }
        Obstacle newObstacle = Instantiate(_obstaclePrefab);
        _obstacleList.Add(newObstacle);
        newObstacle.gameObject.SetActive(false);
        return newObstacle;
    }
    public int GetNumberOfObstacleIsActive()
    {
        int count = 0;
        foreach (var obstacle in _obstacleList)
        {
            if (obstacle.gameObject.activeInHierarchy)
            {
                count++;
            }
        }
        return count;
    }
    public void ResetPool()
    {
        foreach (var obstacle in _obstacleList)
        {
            obstacle.gameObject.SetActive(false);
        }
    }
}
