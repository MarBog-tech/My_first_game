using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private PlayerAnimator _playerAnimator;
        
        private Vector2 _lastMove = Vector2.down;
        private Rigidbody2D _rigidbody;
        
        private bool _canMove = true;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        public void MovePlayer(Vector2 direction)
        {
            if (_canMove)
            {
                if (direction != Vector2.zero)
                {
                    _rigidbody.MovePosition(_rigidbody.position + direction * _moveSpeed * Time.fixedDeltaTime);
                    _playerAnimator.AnimatorPlayer(direction, "horizontal", "vertical", true);
                    _lastMove = direction;
                }
                else
                {
                    _playerAnimator.AnimatorPlayer(direction, "horizontal", "vertical", false);
                    _playerAnimator.AnimatorPlayer(_lastMove, "lastMoveX", "lastMoveY", false);
                }
            }
        }

        public void StartAttack()
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
}
