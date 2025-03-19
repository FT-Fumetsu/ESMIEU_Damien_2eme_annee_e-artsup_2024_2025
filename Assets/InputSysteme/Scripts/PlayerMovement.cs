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
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            UpdatePlayerVelocity();
        }

        public void Move(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>();
            Debug.Log(_moveInput.ToString());
        }

        private void UpdatePlayerVelocity()
        {
            _rigidbody2D.velocity = _moveInput * _playerSpeed;
        }
    }
}