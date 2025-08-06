using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _existCount = 2;
    [SerializeField] private float _moveSpeed = 1.0f;
    private Rigidbody2D _rb;
    private Vector2 _dir;
    private bool _hasPlayer = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _dir = Vector2.right;
    }

    private void Update()
    {
        _rb.velocity = _dir * _moveSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (_hasPlayer) _existCount--;
            if (_existCount <= 0)
            {
                BreakObstacle();
                return;
            }
            _dir = new Vector2(-_dir.x, _dir.y);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            _hasPlayer = true;
        }
    }

    public void BreakObstacle()
    {
        gameObject.SetActive(false);
        Debug.Log("Break");
    }
}
