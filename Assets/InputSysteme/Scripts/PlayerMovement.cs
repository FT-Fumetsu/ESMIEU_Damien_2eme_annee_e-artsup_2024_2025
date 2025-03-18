using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _playerSpeed = 5f;

        private Vector2 _moveInput;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            PlayerVelocity();
        }

        public void Move(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>();
            Debug.Log(_moveInput.ToString());
        }

        private void PlayerVelocity()
        {
            _rigidbody.velocity = _moveInput * _playerSpeed;
        }
    }
}