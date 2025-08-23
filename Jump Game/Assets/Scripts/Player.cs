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
        GameConfig.camPositionMovement = transform.position.y;
    }
    // private void Update()
    // {
    //     Vector3 pos = transform.position;
    //     pos.x = Mathf.Clamp(pos.x, GameConfig.leftCam, GameConfig.rightCam);
    // }
    private void Update()
    {
        ChangeState();
        if (Input.touchCount == 1 && !_isFalling & _obstacle != null)
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
    }
    private void ChangeState()
    {
        if (gameObject.transform.parent != null)
        {
            _isFalling = false;
        }
        else _isFalling = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GameConfig.OBSTACLE_TAG))
        {
            _obstacle = collision.gameObject.GetComponent<Obstacle>();
            gameObject.transform.parent = _obstacle.transform;
            _isFalling = false;
            GameManager.Instance.SpawnAfterJump();
            GameManager.Instance.GainScore();
            CameraController._instance.ChangeTargetTo(transform.position.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameConfig.DEAD_ZONE_TAG))
        {
            GameManager.Instance.GameOver();
        }
    }
}

