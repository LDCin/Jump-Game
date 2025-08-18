using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController _instance;
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] public GameObject _leftCamBound;
    [SerializeField] public GameObject _rightCamBound;
    private float _target;
    private Vector2 _pos;
    private bool _canMove = false;
    private void Awake()
    {
        _instance = this;
        _pos = transform.position;
        InitCamBound();
    }
    private void Update()
    {
        if (_canMove)
        {
            MoveToTarget();
            // UpdateCamBound();
        }
    }
    private void InitCamBound()
    {
        _leftCamBound.transform.position = new Vector3(GameConfig.leftCam, transform.position.y, 0);
        _rightCamBound.transform.position = new Vector3(GameConfig.rightCam, transform.position.y, 0);
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
