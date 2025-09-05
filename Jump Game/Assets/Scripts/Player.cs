using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1.0f;
    [SerializeField] private Obstacle _obstacle;

    [SerializeField] private GameObject headObject;
    [SerializeField] private GameObject bodyObject;
    [SerializeField] private GameObject leftArmObject;
    [SerializeField] private GameObject rightArmObject;
    [SerializeField] private GameObject leftLegObject;
    [SerializeField] private GameObject rightLegObject;

    private string _characterName;
    private Rigidbody2D _rb;
    private bool _isFalling = false;
    private bool _firstJump = true;
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
        _animator.SetTrigger("Jump");
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
    private void LoadCharacter()
    {
        CharacterData player = CustomManager.Instance.GetCharacter(GameConfig.CURRENT_CHARACTER_NAME);
        _characterName = player.characterName;

        headObject.GetComponent<SpriteRenderer>().sprite = player.head;
        bodyObject.GetComponent<SpriteRenderer>().sprite = player.body;
        leftArmObject.GetComponent<SpriteRenderer>().sprite = player.leftArm;
        rightArmObject.GetComponent<SpriteRenderer>().sprite = player.rightArm;
        leftLegObject.GetComponent<SpriteRenderer>().sprite = player.leftLeg;
        rightLegObject.GetComponent<SpriteRenderer>().sprite = player.rightLeg;

        _animator.runtimeAnimatorController = player.characterAnimatorController;
    }
}

