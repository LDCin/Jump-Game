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
    private bool _enableType = false;

    private SpriteRenderer _spriteRenderer;
    private Sprite _beforeBreakSprite;
    private Sprite _afterBreakSprite;
    private int _currentExistCount;
    private BoxCollider2D _col;
    private Vector2 _dir;
    private bool _hasPlayer = false;
    private Vector3 _colSize;
    private bool _isFirst = false;

    // BLINK
    private float _blinkTimer = 0f;
    private bool _isVisible = true;

    private void Awake()
    {
        _col = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        EnableColliderObstacle();
        _currentExistCount = _existCount;
        _colSize = _col.bounds.size;
        _enableType = false;
        SetFirst(false);
    }

    private void OnEnable()
    {
        _spriteRenderer.enabled = true;
        _col.size = _spriteRenderer.size;
        PickRandomType();
        _dir = Random.Range(0, 100) < 50 ? Vector2.right : Vector2.left;
        _hasPlayer = false;

        _blinkTimer = 0f;
        _isVisible = true;
        Color c = _spriteRenderer.color;
        c.a = 1f;
        _spriteRenderer.color = c;

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
            float alpha = Mathf.PingPong(_blinkTimer, _blinkGap) / _blinkGap;
            Color c = _spriteRenderer.color;
            c.a = alpha;
            _spriteRenderer.color = c;
        }
    }
    public void EnableChangeType()
    {
        _enableType = true;
    }
    private void PickRandomType()
    {
        int type = Random.Range(1, 4);
        if (_isFirst || !_enableType) type = 1;
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
    public void SetHasPlayer()
    {
        _hasPlayer = !_hasPlayer;
    }
    private void ChangeDirection()
    {
        float leftLimit = GameConfig.LEFT_CAM + GameConfig.WALL_SIZE.x + 0.1f;
        float rightLimit = GameConfig.RIGHT_CAM - GameConfig.WALL_SIZE.x - 0.1f;

        float halfWidth = _colSize.x / 2f;
        float posX = transform.position.x;

        if (posX - halfWidth <= leftLimit || posX + halfWidth >= rightLimit)
        {
            if (_hasPlayer)
            {
                _currentExistCount--;
                if (_currentExistCount == 1 && _hasPlayer)
                    SoundManager.Instance.PlayBreakSound();

                _spriteRenderer.sprite = _afterBreakSprite;
            }

            if (_currentExistCount <= 0)
            {
                BreakObstacle();
                return;
            }

            _dir = new Vector2(-_dir.x, _dir.y);

            if (posX - halfWidth <= leftLimit)
                posX = leftLimit + halfWidth;
            else if (posX + halfWidth >= rightLimit)
                posX = rightLimit - halfWidth;
            transform.position = new Vector3(posX, transform.position.y, transform.position.z);
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
        SetHasPlayer();
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
        if (transform.position.y >= GameConfig.TOP_CAM)
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
}
