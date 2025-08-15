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
    // private void Update()
    // {
    //     Vector3 pos = transform.position;
    //     pos.x = Mathf.Clamp(pos.x, GameConfig.leftCam, GameConfig.rightCam);
    // }
    private void FixedUpdate()
    {
        if (Input.touchCount == 1 && !_isFalling)
        {
            _obstacle.DisableColliderObstacle();
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
            GameManager._instance.SpawnAfterJump();
            GameManager._instance.GainScore();
            CameraController._instance.ChangeTargetTo(transform.position.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameConfig.DEAD_ZONE_TAG))
        {
            GameManager._instance.GameOver();
        }
    }
}

