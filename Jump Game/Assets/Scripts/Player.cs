using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1.0f;
    [SerializeField] private Obstacle _obstacle;
    private Rigidbody2D _rb;
    private bool _isFalling = false;
    private bool _firstJump = true;
    private Collider2D _col;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<Collider2D>();
        GameConfig.camPositionMovement = transform.position.y;
    }
    private void Update()
    {
        ChangeState();
        if (Input.touchCount == 1)
        {
            if (_firstJump)
            {
                _obstacle.SetFirst(false);
                _firstJump = false;
                return;
            }
            else if (!_isFalling && _obstacle != null)
            {
                _obstacle.DisableColliderObstacle();
                Jump();
                Debug.Log("Touch Screen!");
            }
        }
    }
    private void Jump()
    {
        SoundManager.Instance.PlayJumpSound();
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
            if (Mathf.Abs(_col.bounds.size.x - _obstacle.GetCollider2D().bounds.size.x) <= 0.5 && !_firstJump)
            {
                GameManager.Instance.JumpPerfectly();
            }
            gameObject.transform.parent = _obstacle.transform;
            _isFalling = false;
            GameManager.Instance.SpawnAfterJump();
            if (!_firstJump) GameManager.Instance.GainScore(1);
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

