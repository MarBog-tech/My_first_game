using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private PlayerEntity _playerEntity;

    private Vector2 _direction;

    private Vector2 _lastMove;
    // Update is called once per frame
    void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.y = Input.GetAxisRaw("Vertical");
        if (_direction.x != 0 || _direction.y != 0)
            _lastMove = _direction;

        _playerEntity.AnimatorPlayer(_direction ,_lastMove);
    }

    private void FixedUpdate()
    {
        _playerEntity.MovePlayer(_direction);
    }
}
