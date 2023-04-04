using UnityEngine;

namespace Animation
{
    public class AnimationController: MonoBehaviour
    {
        [SerializeField] private Animator _animation;
        
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _animation = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void AnimationMovement(Vector2 direction, string horizontal, string vertical, bool move)
        {
            _animation.SetFloat(horizontal, direction.x);
            _animation.SetFloat(vertical, direction.y);
            _animation.SetBool("IsMoving", move);
            Flip(direction.x);
        }
        
        public void AnimationAttack(Vector2 direction, string horizontal, string vertical)
        {
            _animation.SetFloat(horizontal, direction.x);
            _animation.SetFloat(vertical, direction.y);
            _animation.SetTrigger("Attack");
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