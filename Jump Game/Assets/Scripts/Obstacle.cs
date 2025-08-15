using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _existCount = 2;
    [SerializeField] private float _moveSpeed = 1.0f;
    private Collider2D _col;
    private Vector2 _dir;
    private bool _hasPlayer = false;

    private void Awake()
    {
        _col = GetComponent<Collider2D>();
        EnableColliderObstacle();
    }
    private void OnEnable()
    {
        if (Random.Range(0, 100) < 50)
        {
            _dir = Vector2.right;
        }
        else _dir = Vector2.left;
    }

    private void Update()
    {
        ReturnToPool();
        ChangeDirection();
        transform.Translate(_dir * _moveSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GameConfig.PLAYER_TAG))
        {
            _hasPlayer = true;
        }
    }
    private void ChangeDirection()
    {
        if (_col.bounds.min.x <= GameConfig.leftCam || _col.bounds.max.x >= GameConfig.rightCam)
        {
            if (_hasPlayer) _existCount--;
            if (_existCount <= 0)
            {
                BreakObstacle();
                return;
            }
            _dir = new Vector2(-_dir.x, _dir.y);
        }
    }
    private void ReturnToPool()
    {
        if (_col.transform.position.y >= GameConfig.topCam)
        {
            _hasPlayer = false;
            EnableColliderObstacle();
            BreakObstacle();
        }
    }
    public void DisableColliderObstacle()
    {
        _col.enabled = false;
    }
    public void EnableColliderObstacle()
    {
        _col.enabled = true;
    }
    public void BreakObstacle()
    {
        if (transform.childCount > 0)
        {
            Transform child = transform.GetChild(0);
            child.parent = null;
        }
        gameObject.SetActive(false);
        Debug.Log("Break");
    }
    public Collider2D GetCollider2D()
    {
        return _col;
    }
}
