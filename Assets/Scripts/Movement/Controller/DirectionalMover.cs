using System.Security.Cryptography.X509Certificates;
using Core.Movement.Data;
using StatsSystem.Enum;
using StatsSystem.Interfaces;
using UnityEngine;

namespace Movement.Controller
{
    public class DirectionalMover : MonoBehaviour

    {
        private readonly Rigidbody2D _rigidbody;
        private readonly DirectionalMoverData _directionalMoverData;
        private readonly IStatValueGiver _statValueGiver;

        private bool _canMove = true;
        private Vector2 _lastMove = Vector2.down;


        public DirectionalMover(Rigidbody2D rigidbody2D, DirectionalMoverData directionalMoverData,
            IStatValueGiver statValueGiver)
        {
            _rigidbody = rigidbody2D;
            _directionalMoverData = directionalMoverData;
            _statValueGiver = statValueGiver;
        }

        public void Move(Vector2 direction)
        {
            if (_canMove)
            {
                if (direction != Vector2.zero)
                {
                    _rigidbody.MovePosition(
                        _rigidbody.position + direction * _statValueGiver.GetStatValue(StatType.Speed) *
                        Time.fixedDeltaTime);
                    _directionalMoverData.Animation.AnimationMovement(direction, "horizontal", "vertical", true);
                    _lastMove = direction;
                }
                else
                {
                    _directionalMoverData.Animation.AnimationMovement(direction, "horizontal", "vertical", false);
                    _directionalMoverData.Animation.AnimationMovement(_lastMove, "lastMoveX", "lastMoveY", false);
                }
            }
        }
        
        // void LockMovement()
        // {
        //     _canMove = false;
        // }
        //
        // void UnLockMovement()
        // {
        //     _canMove = true;
        // }
    }
}