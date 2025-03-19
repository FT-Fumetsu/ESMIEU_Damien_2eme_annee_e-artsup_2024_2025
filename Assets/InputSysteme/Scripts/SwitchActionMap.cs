using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class SwitchActionMap : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;

        private string _gameActionMap = "Game";
        private string _uiActionMap = "UI";
        public void SwitchOnUIActionMap(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                SwitchActionMaps(_uiActionMap, _gameActionMap);
            }
        }

        public void SwitchOnPlayerActionMap()
        {
            SwitchActionMaps(_gameActionMap, _uiActionMap);
        }

        private void SwitchActionMaps(string nextActionMapName, string oldActionMapName)
        {
            _playerInput.actions.FindActionMap(nextActionMapName).Enable();
            _playerInput.actions.FindActionMap(oldActionMapName).Disable();
        }
    }
}