using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1.0f;
    [SerializeField] private Obstacle _obstacle;

    [SerializeField] private GameObject _headObject;
    [SerializeField] private GameObject _bodyObject;
    [SerializeField] private GameObject _leftArmObject;
    [SerializeField] private GameObject _rightArmObject;
    [SerializeField] private GameObject _tailObject;
    [SerializeField] private GameObject _leftLegObject;
    [SerializeField] private GameObject _rightLegObject;

    private string _characterName;
    private Rigidbody2D _rb;
    private bool _isFalling = false;
    private bool _firstJump = true;
    private int _scoreToAdd = 0;

    private Collider2D _col;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        LoadCharacter();
        GameConfig.CAM_POSITION_MOVEMENT = transform.position.y;
    }
    private void Update()
    {
        ChangeState();
        if (Input.touchCount > 0)
        {
            if (!UIHelper.Instance.IsPointerOverUI())
            {
                Debug.Log("Jump!");
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
    }
    private void Jump()
    {
        SoundManager.Instance.PlayJumpSound();
        _animator.SetTrigger("Jump");
        _obstacle.SetHasPlayer();
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
            Debug.Log("Set player as children!");
            float playerCenterX = _col.bounds.center.x;
            float obstacleCenterX = _obstacle.GetCollider2D().bounds.center.x;

            if (Mathf.Abs(playerCenterX - obstacleCenterX) <= 0.05f && !_firstJump)
            {
                Debug.Log("PERFECT");
                GameManager.Instance.JumpPerfectly();
            }
            gameObject.transform.parent = _obstacle.transform;
            _isFalling = false;
            GameManager.Instance.SpawnAfterJump();
            if (!_firstJump && _scoreToAdd > 0)
            {
                GameManager.Instance.GainScore(_scoreToAdd - 1);
                _scoreToAdd = 0;
            }
            CameraController._instance.ChangeTargetTo(transform.position.y - 3.0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameConfig.DEAD_ZONE_TAG))
        {
            GameManager.Instance.GameOver();
        }
        else if (collision.gameObject.CompareTag(GameConfig.SCORE_ZONE_TAG) && !_firstJump)
        {
            _scoreToAdd++;
        }
    }
    private void LoadCharacter()
    {
        GameManager.Instance.LoadPlayer(_headObject, _bodyObject, _leftArmObject, _rightArmObject, _tailObject, _leftLegObject, _rightLegObject, _animator);
    }
}

