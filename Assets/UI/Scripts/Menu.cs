using UnityEngine;
using UnityEngine.EventSystems;

namespace Menu
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private KeyCode _echap;
        [SerializeField] private GameObject _echapMenu;
        [SerializeField] private GameObject _optionsMenu;
        [SerializeField] private GameObject _inventoryMenu;

        [SerializeField] private GameObject _pauseFirstButton, _optionsFirstButton, _optionsClosedButton, _inventoryFirstButton;

        private void Start()
        {
            _echapMenu.SetActive(false);
            _optionsMenu.SetActive(false);
            _inventoryMenu.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(_echap))
            {
                if (_echapMenu.activeInHierarchy)
                {
                    Debug.Log("Echap Menu true to false");
                    _echapMenu.SetActive(false);
                }

                else if (_optionsMenu.activeInHierarchy)
                {
                    _optionsMenu.SetActive(false);
                    _echapMenu.SetActive(true);

                    //set a new selected object
                    EventSystem.current.SetSelectedGameObject(_optionsClosedButton);
                }

                else if (_inventoryMenu.activeInHierarchy)
                {
                    _inventoryMenu.SetActive(false);
                    _echapMenu.SetActive(true);
                }

                else
                {
                    Debug.Log("Echap Menu false to true");
                    _echapMenu.SetActive(true);

                    //set a new selected object
                    EventSystem.current.SetSelectedGameObject(_pauseFirstButton);
                }

            }
        }

        public void OpenInventory()
        {
            _inventoryMenu.SetActive(true);
            _echapMenu.SetActive(false);

            //set a new selected object
            EventSystem.current.SetSelectedGameObject(_inventoryFirstButton);
        }

        public void OpenOptions()
        {
            _optionsMenu.SetActive(true);
            _echapMenu.SetActive(false);

            //set a new selected object
            EventSystem.current.SetSelectedGameObject(_optionsFirstButton);
        }
    }
}