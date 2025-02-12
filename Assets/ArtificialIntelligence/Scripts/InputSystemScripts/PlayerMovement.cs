using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Vector2 _moveInput;

        private void Update()
        {
            _rigidbody.velocity = _moveInput * _speed;
        }

        public void Move(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>();
        }
    }
}