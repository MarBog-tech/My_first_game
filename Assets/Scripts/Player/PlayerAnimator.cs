using System;
using UnityEngine;

namespace Player
{
    public class PlayerAnimator: MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void AnimatorPlayer(Vector2 direction, string horizontal, string vertical, bool move)
        {
            _animator.SetFloat(horizontal, direction.x);
            _animator.SetFloat(vertical, direction.y);
            _animator.SetBool("IsMoving", move);
            Flip(direction.x);
        }
        
        public void AnimatorAttack(Vector2 direction, string horizontal, string vertical)
        {
            _animator.SetFloat(horizontal, direction.x);
            _animator.SetFloat(vertical, direction.y);
            _animator.SetTrigger("Attack");
            Flip(direction.x);
        }

        private void Flip(float directionX)
        {
            if (directionX < 0)
                _spriteRenderer.flipX = true;
            else if(directionX > 0)
                _spriteRenderer.flipX = false;

        }
    }
}