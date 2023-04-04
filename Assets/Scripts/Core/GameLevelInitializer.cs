using System;
using System.Collections.Generic;
using Core.Services.ProjectUpdater;
using InputReader;
using Player;
using StatsSystem;
using UnityEngine;

namespace Core
{
    public class GameLevelInitializer : MonoBehaviour
    {
        [SerializeField] private PlayerEntity _playerEntity;
        [SerializeField] private GameUIInputView _gameUIInputView;
        [SerializeField] private StatsStorage _statsStorage;

        private ExternalDeviceInputReader _externalDeviceInput;
        private PlayerSystem _playerSystem;
        private ProjectUpdater _projectUpdater;

        private List<IDisposable> _disposables;

        private bool _onPause = false;
        
        private void Awake()
        {
            _disposables = new List<IDisposable>();
            if (ProjectUpdater.Instance == null)
                _projectUpdater = new GameObject().AddComponent<ProjectUpdater>();
            else 
                _projectUpdater = ProjectUpdater.Instance as ProjectUpdater;
            
            _externalDeviceInput = new ExternalDeviceInputReader();
            _disposables.Add(_externalDeviceInput);
            
            _playerSystem = new PlayerSystem(_playerEntity, new List<IEntityInputSource>
            {
                _gameUIInputView,
                _externalDeviceInput
            });
            _disposables.Add(_playerSystem);
        }

        private void OnDestroy()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}