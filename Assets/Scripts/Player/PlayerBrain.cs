using System;
using System.Collections.Generic;
using System.Linq;
using Player.Interfaces;
using UnityEngine;

namespace Player
{
    public class PlayerBrain
    {
        private readonly PlayerEntity _playerEntity;
        private readonly List<IEntityInputSource> _inputSources;
        
        private Vector2 _direction;

        public PlayerBrain(PlayerEntity playerEntity, List<IEntityInputSource> inputSources)
        {
            _playerEntity = playerEntity;
            _inputSources = inputSources;
        }

        // public PlayerBrain()
        public void OnFixedUpdate()
        {
            _direction.x = GetHorizontalDirection();
            _direction.y = GetVerticalDirection();
            _playerEntity.MovePlayer(_direction);
            

            if (IsAttack)
                _playerEntity.StartAttack();

            foreach (var inputSource in _inputSources)
            {
                inputSource.ResetOneTimeActions();
            }
        }

        public float GetHorizontalDirection()
        {
            foreach (var inputSource in _inputSources)
            {
                if (inputSource.HorizontalDirection == 0)
                    continue;
                return inputSource.HorizontalDirection;
            }

            return 0;
        }
        
        public float GetVerticalDirection()
        {
            foreach (var inputSource in _inputSources)
            {
                if (inputSource.VerticalDirection == 0)
                    continue;
                return inputSource.VerticalDirection;
            }

            return 0;
        }

        private bool IsAttack => _inputSources.Any(source => source.Attack);
    }
}