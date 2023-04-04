using UnityEngine;
using UnityEngine.UI;

namespace InputReader
{
    public class GameUIInputView : MonoBehaviour, IEntityInputSource
    {
        [SerializeField] private Joystick _Joystick;
        [SerializeField] private Button _attackButton;
        
        public bool Attack { get; private set; }
        public float HorizontalDirection => _Joystick.Horizontal;
        public float VerticalDirection => _Joystick.Vertical;

        private void Awake()
        {
            _attackButton.onClick.AddListener(()=> Attack = true);
        }

        private void OnDestroy()
        {
            _attackButton.onClick.RemoveAllListeners();
        }
        
        public void ResetOneTimeActions() => Attack = false;
    }
}