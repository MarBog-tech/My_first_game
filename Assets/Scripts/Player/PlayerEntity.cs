using UnityEngine;

namespace Player
{
    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private Animator _animator;
        [SerializeField] private bool _faceRight;

        private Rigidbody2D _rigidbody;
    
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
        
        }

        public void MovePlayer(Vector2 direction)
        {
            _rigidbody.MovePosition(_rigidbody.position + direction * _moveSpeed * Time.fixedDeltaTime);
        }

        public void AnimatorPlayer(Vector2 direction)
        {
            _animator.SetFloat("horizontal", direction.x);
            SetDirection(direction.x);
            _animator.SetFloat("vertical", direction.y);
            _animator.SetFloat("speed", direction.sqrMagnitude);
        }

        private void SetDirection(float direction)
        {
            if ((_faceRight && direction < 0) ||
                (!_faceRight && direction > 0))
                Flip();
        }

        private void Flip()
        {
            transform.Rotate(0,180,0);
            _faceRight = !_faceRight;
        }
    }
}
