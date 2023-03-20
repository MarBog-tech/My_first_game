using System;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField] private PlayerEntity _playerEntity;
    [SerializeField] private PlayerAnimator _playerAnimator;

    private Vector2 _direction;
    private Vector2 _lastMove = Vector2.down;
    private SpriteRenderer _spriteRenderer;
    private bool _canMove = true;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (_canMove)
        {
            if(_direction != Vector2.zero){
                _playerEntity.MovePlayer(_direction);
                _playerAnimator.AnimatorPlayer(_direction, "horizontal", "vertical", true);
                _lastMove = _direction;
            }
            else
            {
                _playerAnimator.AnimatorPlayer(_direction, "horizontal", "vertical", false);
                _playerAnimator.AnimatorPlayer(_lastMove, "lastMoveX", "lastMoveY", false);
            }

            if (_direction.x < 0)
                _spriteRenderer.flipX = true;
            else if(_direction.x > 0)
                _spriteRenderer.flipX = false;
        }
    }
    
    void OnMove(InputValue movementValue)
    {
        _direction = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
        _playerAnimator.AnimatorAttack(_lastMove, "lastMoveX", "lastMoveY");
    }

    void LockMovement()
    {
        _canMove = false;
    }
    
    void UnLockMovement()
    {
        _canMove = true;
    }
}
