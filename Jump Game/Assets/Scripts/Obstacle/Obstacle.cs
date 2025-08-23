using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _existCount = 2;
    [SerializeField] private float _moveSpeed = 1.0f;
    private int _currentExistCount;
    private Collider2D _col;
    private Vector2 _dir;
    private bool _hasPlayer = false;
    private Vector3 _colSize;

    private void Awake()
    {
        _col = GetComponent<Collider2D>();
        EnableColliderObstacle();
        _currentExistCount = _existCount;
        _colSize = _col.bounds.size;
    }
    private void OnEnable()
    {
        if (Random.Range(0, 100) < 50)
        {
            _dir = Vector2.right;
        }
        else _dir = Vector2.left;
        _hasPlayer = false;
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
        if (transform.position.x - _colSize.x / 2 <= GameConfig.leftCam || transform.position.x + _colSize.x / 2 >= GameConfig.rightCam)
        {
            if (_hasPlayer) _currentExistCount--;
            if (_currentExistCount <= 0)
            {
                BreakObstacle();
                return;
            }
            _dir = new Vector2(-_dir.x, _dir.y);
        }
    }
    public void RestoreObstacle()
    {
        _hasPlayer = false;
        _currentExistCount = _existCount;
        EnableColliderObstacle();
    }
    public void BreakObstacle()
    {
        if (transform.childCount > 0)
        {
            Transform child = transform.GetChild(0);
            child.parent = null;
        }
        RestoreObstacle();
        gameObject.SetActive(false);
        Debug.Log("Break");
    }
    private void ReturnToPool()
    {
        if (transform.position.y >= GameConfig.topCam)
        {
            BreakObstacle();
            Debug.Log("Return To Pool!");
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
    public Collider2D GetCollider2D()
    {
        return _col;
    }
    public void GetHasPlayer()
    {
        if (_hasPlayer) Debug.Log("True");
        else Debug.Log("False");
    }
}
