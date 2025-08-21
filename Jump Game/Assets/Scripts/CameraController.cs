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
    private void InitBound() {
        _leftCamBoundBox = _leftCamBound.GetComponent<BoxCollider2D>();
        _rightCamBoundBox = _rightCamBound.GetComponent<BoxCollider2D>();
        _deadZoneBox = _deadZone.GetComponent<BoxCollider2D>();
    }
    private void UpdateCamBound()
    {
        _leftCamBoundBox.size = new Vector2(0.2f, GameConfig.halfHeight * 2);
        _rightCamBoundBox.size = new Vector2(0.2f, GameConfig.halfHeight * 2);
        _deadZoneBox.size = new Vector2(GameConfig.halfWidth * 2, 0.2f);
        _leftCamBound.transform.position = new Vector3(GameConfig.leftCam, GameConfig.camPosition.y, 0);
        _rightCamBound.transform.position = new Vector3(GameConfig.rightCam, GameConfig.camPosition.y, 0);
        _deadZone.transform.position = new Vector3(GameConfig.camPosition.x, GameConfig.botCam, 0);
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
