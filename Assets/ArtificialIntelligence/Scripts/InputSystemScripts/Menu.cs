using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Input;

namespace Menu
{
    public class Menu : MonoBehaviour
    {
        [Header("Menu References")]
        [SerializeField] private GameObject _pauseMenuGameObject;
        [SerializeField] private GameObject _optionsMenuGameObject;
        [SerializeField] private GameObject _inventoryMenuGameObject;
        [SerializeField] private GameObject _pauseFirstButtonGameObject;
        [SerializeField] private GameObject _optionsFirstButtonGameObject;
        [SerializeField] private GameObject _optionsClosedButtonGameObject;
        [SerializeField] private GameObject _inventoryFirstButtonGameObject;
        [SerializeField] private GameObject _inventoryClosedButtonGameObject;

        [Header("Scripts References")]
        [SerializeField] private SwitchActionMap _switchActionMap;

        private void Start()
        {
            _pauseMenuGameObject.SetActive(false);
            _optionsMenuGameObject.SetActive(false);
            _inventoryMenuGameObject.SetActive(false);
        }

        public void OpenMenu(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Debug.Log("Echap Menu" + context.phase);
                _pauseMenuGameObject.SetActive(true);

                //set a new selected object
                EventSystem.current.SetSelectedGameObject(_pauseFirstButtonGameObject);
            }
        }

        public void BackInMenu(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                if (_pauseMenuGameObject.activeInHierarchy)
                {
                    ClosePauseMenu();
                }

                else if (_optionsMenuGameObject.activeInHierarchy)
                {
                    CloseOptionMenu();
                }

                else if (_inventoryMenuGameObject.activeInHierarchy)
                {
                    CloseInventoryMenu();
                }
            }
        }

        public void OpenInventory()
        {
            _inventoryMenuGameObject.SetActive(true);
            _pauseMenuGameObject.SetActive(false);

            //set a new selected object
            EventSystem.current.SetSelectedGameObject(_inventoryFirstButtonGameObject);
        }

        public void OpenOptions()
        {
            _optionsMenuGameObject.SetActive(true);
            _pauseMenuGameObject.SetActive(false);

            //set a new selected object
            EventSystem.current.SetSelectedGameObject(_optionsFirstButtonGameObject);
        }

        public void ClosePauseMenu()
        {
            Debug.Log("Echap Menu true to false");
            _pauseMenuGameObject.SetActive(false);

            _switchActionMap.SwitchOnPlayerActionMap();
        }

        private void CloseOptionMenu()
        {
            _optionsMenuGameObject.SetActive(false);
            _pauseMenuGameObject.SetActive(true);

            //set a new selected object
            EventSystem.current.SetSelectedGameObject(_optionsClosedButtonGameObject);
        }

        private void CloseInventoryMenu()
        {
            _inventoryMenuGameObject.SetActive(false);
            _pauseMenuGameObject.SetActive(true);

            //set a new selected object
            EventSystem.current.SetSelectedGameObject(_inventoryClosedButtonGameObject);
        }
    }
}