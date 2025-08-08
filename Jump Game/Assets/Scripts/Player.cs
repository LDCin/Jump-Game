using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1.0f;
    [SerializeField] private Obstacle _obstacle;
    private Rigidbody2D _rb;
    private bool _isFalling = false;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (Input.touchCount == 1 && !_isFalling)
        {
            _obstacle.disableColliderObstacle();
            Jump();
            Debug.Log("Touch Screen!");
        }
    }
    private void Jump()
    {
        gameObject.transform.parent = null;
        _rb.velocity = Vector2.up * _jumpForce;
        _isFalling = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GameConfig.OBSTACLE_TAG))
        {
            _obstacle = collision.gameObject.GetComponent<Obstacle>();
            gameObject.transform.parent = _obstacle.transform;
            _isFalling = false;
            if (gameObject.transform.parent != null)
            {
                Debug.Log("Set Parent Successfully!");
            }
            CameraController._instance.ChangeTargetTo(transform.position.y);
        }
    }
}

