using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private PlayerEntity _playerEntity;

    private Vector2 _direction;
    // Update is called once per frame
    void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.y = Input.GetAxisRaw("Vertical");

        _playerEntity.AnimatorPlayer(_direction);
    }

    private void FixedUpdate()
    {
        _playerEntity.MovePlayer(_direction);
    }
}
