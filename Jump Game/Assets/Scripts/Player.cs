using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1.0f;
    [SerializeField] private float _fixPositionSpeed = 1.0f;
    private Rigidbody2D _rb;
    private Obstacle _obstacle;
    private bool _isFirst = true;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (Input.touchCount == 1)
        {
            _obstacle.BreakObstacle();
            Jump();
            Debug.Log("Touch Screen!");
        }
        // if (Input.GetMouseButtonDown(0))
        // {
        //     _obstacle.BreakObstacle();
        //     Jump();
        //     Debug.Log("Touch Screen!");
        // }
    }
    private void Jump()
    {
        _rb.velocity = Vector2.up * _jumpForce;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            _obstacle = collision.gameObject.GetComponent<Obstacle>();
            // Rigidbody2D _rbObstacle = _obstacle.GetComponent<Rigidbody2D>();
            // if (!_isFirst)
            // {
            //     _rb.velocity = new Vector2(0, 3) * _fixPositionSpeed;
            //     _rbObstacle.velocity = new Vector2(0, 3) * _fixPositionSpeed;
            // }
            // _isFirst = false;
        }
    }
}

