using System;
using UnityEngine;
using Animation;
using Core.Movement.Data;
using Movement.Controller;
using StatsSystem.Interfaces;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] private DirectionalMoverData _directionalMoverData;
        private Rigidbody2D _rigidbody;
        private DirectionalMover _directionalMover;

        public void Initialize(IStatValueGiver statValueGiver)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _directionalMover = new DirectionalMover(_rigidbody,_directionalMoverData, statValueGiver);
        }

        public void Move(Vector2 direction) => _directionalMover.Move(direction);

        public void StartAttack(Vector2 direction)
        {
            _directionalMoverData.Animation.AnimationAttack( direction, "lastMoveX", "lastMoveY");
        }
    }
}
