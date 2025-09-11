using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController _instance;
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] public GameObject _leftCamBound;
    [SerializeField] public GameObject _rightCamBound;
    [SerializeField] public GameObject _deadZone;
    private float _target;
    private Vector2 _pos;
    private bool _canMove = false;
    private BoxCollider2D _leftCamBoundBox;
    private BoxCollider2D _rightCamBoundBox;
    private BoxCollider2D _deadZoneBox;
    private SpriteRenderer _leftCamSprite;
    private SpriteRenderer _rightCamSprite;
    private void Awake()
    {
        _instance = this;
        _pos = transform.position;
    }
    private void Start()
    {
        InitBound();
        UpdateCamBound();
    }
    private void Update()
    {
        if (_canMove)
        {
            MoveToTarget();
            // UpdateCamBound();
        }
    }
    private void FixedUpdate()
    {
        UpdateCamBound();
    }
    private void InitBound()
    {
        _leftCamBoundBox = _leftCamBound.GetComponent<BoxCollider2D>();
        _rightCamBoundBox = _rightCamBound.GetComponent<BoxCollider2D>();
        _deadZoneBox = _deadZone.GetComponent<BoxCollider2D>();

        _leftCamSprite = _leftCamBound.GetComponent<SpriteRenderer>();
        _rightCamSprite = _rightCamBound.GetComponent<SpriteRenderer>();
    }
    private void UpdateCamBound()
    {
        _leftCamBoundBox.size = GameConfig.WALL_SIZE;
        _rightCamBoundBox.size = GameConfig.WALL_SIZE;
        _deadZoneBox.size = new Vector2(GameConfig.HALF_WIDTH * 2, 0.2f);

        _leftCamBound.transform.position = new Vector3(GameConfig.LEFT_CAM, GameConfig.CAM_POSITION.y, 0);
        _rightCamBound.transform.position = new Vector3(GameConfig.RIGHT_CAM, GameConfig.CAM_POSITION.y, 0);
        _deadZone.transform.position = new Vector3(GameConfig.CAM_POSITION.x, GameConfig.BOT_CAM, 0);

        _leftCamSprite.size = _leftCamBoundBox.size;
        _rightCamSprite.size = _rightCamBoundBox.size;
        _rightCamSprite.flipX = true;
    }
    public void ChangeTargetTo(float y)
    {
        if (y < _pos.y)
        {
            _target = y;
            _canMove = true;
        }
    }
    private void MoveToTarget()
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.MoveTowards(pos.y, _target, _moveSpeed * Time.deltaTime);
        transform.position = pos;
        if (Mathf.Abs(pos.y - _target) < 0.01f)
        {
            _canMove = false;
        }
    }
    // private void UpdateCamBound()
    // {
    //     GameConfig.camPosition = transform.position;
    //     GameConfig.topCam = GameConfig.camPosition.y + GameConfig.halfHeight;
    // }
}
