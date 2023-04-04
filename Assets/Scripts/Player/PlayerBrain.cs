using System;
using System.Collections.Generic;
using System.Linq;
using Core.Services.ProjectUpdater;
using InputReader;
using UnityEngine;

namespace Player
{
    public class PlayerBrain : IDisposable
    {
        private readonly PlayerEntity _playerEntity;
        private readonly List<IEntityInputSource> _inputSources;
        
        private Vector2 _direction;

        public PlayerBrain(PlayerEntity playerEntity, List<IEntityInputSource> inputSources)
        {
            _playerEntity = playerEntity;
            _inputSources = inputSources;
            ProjectUpdater.Instance.FixedUpdateCalled += OnFixedUpdate;
        }

        public void Dispose() => ProjectUpdater.Instance.FixedUpdateCalled -= OnFixedUpdate;
        
        private void OnFixedUpdate()
        {
            _direction.x = GetHorizontalDirection();
            _direction.y = GetVerticalDirection();
            _playerEntity.Move(_direction);
            

            if (IsAttack)
                _playerEntity.StartAttack(_direction);

            foreach (var inputSource in _inputSources)
            {
                inputSource.ResetOneTimeActions();
            }
        }

        private float GetHorizontalDirection()
        {
            foreach (var inputSource in _inputSources)
            {
                if (inputSource.HorizontalDirection == 0)
                    continue;
                return inputSource.HorizontalDirection;
            }

            return 0;
        }

        private float GetVerticalDirection()
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