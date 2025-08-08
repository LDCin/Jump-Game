using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController _instance;
    [SerializeField] private float _moveSpeed = 1.0f;
    private float _target;
    private Vector2 _pos;
    private bool _canMove = false;
    private void Awake()
    {
        _instance = this;
        _pos = transform.position;
    }
    private void Update()
    {
        if (_canMove)
        {
            MoveToTarget();
        }
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
        Vector2 pos = transform.position;
        pos.y = Mathf.MoveTowards(pos.y, _target, _moveSpeed * Time.deltaTime);
        transform.position = pos;
        if (Mathf.Abs(pos.y - _target) < 0.01f)
        {
            _canMove = false;
        }
    }
}
