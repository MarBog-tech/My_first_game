using System;
using UnityEngine;

namespace Player
{
    public class PlayerAnimator: MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void AnimatorPlayer(Vector2 direction, string horizontal, string vertical, bool move)
        {
            _animator.SetFloat(horizontal, direction.x);
            _animator.SetFloat(vertical, direction.y);
            _animator.SetBool("IsMoving", move);
        }
        
        public void AnimatorAttack(Vector2 direction, string horizontal, string vertical)
        {
            _animator.SetFloat(horizontal, direction.x);
            _animator.SetFloat(vertical, direction.y);
            _animator.SetTrigger("Attack");
        }
    }
}