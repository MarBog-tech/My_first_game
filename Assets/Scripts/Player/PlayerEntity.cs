using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _collisionOffset = 0.05f;
        [SerializeField] private ContactFilter2D _movementFilter;
        
        
        private Rigidbody2D _rigidbody;
        private List<RaycastHit2D> _castCollisions = new();

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        public void MovePlayer(Vector2 direction)
        {
            int count = _rigidbody.Cast(
                direction,
                _movementFilter, 
                _castCollisions, 
                _moveSpeed * Time.fixedDeltaTime + _collisionOffset
                );
            if (count == 0)
            {
                _rigidbody.MovePosition(_rigidbody.position + direction * _moveSpeed * Time.fixedDeltaTime);
            }
        }
    }
}
