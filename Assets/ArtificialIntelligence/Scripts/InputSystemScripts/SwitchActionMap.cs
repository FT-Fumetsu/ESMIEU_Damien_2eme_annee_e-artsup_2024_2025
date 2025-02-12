using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class SwitchActionMap : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;

        public void SwitchOnUIActionMap(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _playerInput.actions.FindActionMap("UI").Enable();
                _playerInput.actions.FindActionMap("Game").Disable();
            }
        }

        public void SwitchOnPlayerActionMap()
        {
            _playerInput.actions.FindActionMap("UI").Disable();
            _playerInput.actions.FindActionMap("Game").Enable();
        }
    }
}