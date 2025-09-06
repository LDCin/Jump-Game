using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _existCount = 2;
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private float _realSpeed = 1.0f;
    [SerializeField] private bool _enableBlink = false;
    [SerializeField] private float _blinkGap = 0.5f;
    [SerializeField] private bool _enableFast = false;
    [SerializeField] private float _extraSpeed;

    private SpriteRenderer _spriteRenderer;
    private Sprite _beforeBreakSprite;
    private Sprite _afterBreakSprite;
    private int _currentExistCount;
    private Collider2D _col;
    private Vector2 _dir;
    private bool _hasPlayer = false;
    private Vector3 _colSize;
    private bool _isFirst = false;

    // BLINK
    private float _blinkTimer = 0f;
    private bool _isVisible = true;

    private void Awake()
    {
        _col = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        EnableColliderObstacle();
        _currentExistCount = _existCount;
        _colSize = _col.bounds.size;
        SetFirst(false);
    }

    private void OnEnable()
    {
        _spriteRenderer.enabled = true;
        PickRandomType();
        _dir = Random.Range(0, 100) < 50 ? Vector2.right : Vector2.left;
        _hasPlayer = false;
        _blinkTimer = 0f;
        _isVisible = true;
        if (_enableFast)
        {
            _realSpeed = _moveSpeed + _extraSpeed;
        }
        else _realSpeed = _moveSpeed;
    }

    public virtual void Update()
    {
        if (_isFirst == false)
        {
            ReturnToPool();
            ChangeDirection();
            transform.Translate(_dir * _realSpeed * Time.deltaTime);
        }

        if (_enableBlink)
        {
            _blinkTimer += Time.deltaTime;
            if (_blinkTimer >= _blinkGap)
            {
                _blinkTimer = 0f;
                _isVisible = !_isVisible;
                _spriteRenderer.enabled = _isVisible;
            }
        }
    }
    private void PickRandomType()
    {
        int type = Random.Range(1, 4);
        if (_isFirst) type = 1;
        if (type == 1)
        {
            _enableBlink = false;
            _enableFast = false;
        }
        else if (type == 2)
        {
            _enableFast = false;
            _enableBlink = true;
        }
        else if (type == 3)
        {
            _enableBlink = false;
            _enableFast = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GameConfig.PLAYER_TAG))
        {
            _hasPlayer = true;
        }
    }
    public void SetFirst(bool value)
    {
        _isFirst = value;
    }
    private void ChangeDirection()
    {
        if (transform.position.x - _colSize.x / 2 <= GameConfig.leftCam || transform.position.x + _colSize.x / 2 >= GameConfig.rightCam)
        {
            if (_hasPlayer)
            {
                _currentExistCount--;
                if (_currentExistCount == 1) SoundManager.Instance.PlayBreakSound();
                _spriteRenderer.sprite = _afterBreakSprite;
            }
            if (_currentExistCount <= 0)
            {
                BreakObstacle();
                return;
            }
            _dir = new Vector2(-_dir.x, _dir.y);
        }
    }
    public void SetSprite(MapData mapData)
    {
        _beforeBreakSprite = mapData.obstacleBeforeImage;
        _spriteRenderer.sprite = _beforeBreakSprite;
        _afterBreakSprite = mapData.obstacleAfterImage;
    }

    public void RestoreObstacle()
    {
        _hasPlayer = false;
        _currentExistCount = _existCount;
        EnableColliderObstacle();
    }
    public void BreakObstacle()
    {
        if (transform.childCount > 1)
        {
            Transform child = transform.GetChild(1);
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
