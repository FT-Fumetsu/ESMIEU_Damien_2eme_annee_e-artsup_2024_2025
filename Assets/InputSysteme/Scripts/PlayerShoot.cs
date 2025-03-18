using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private float _fireRate = 0.5f;
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _bulletSpawnPosition;

        private Transform _player;

        private float _chrono = 0;

        private void Update()
        {
            _player = GetComponent<Transform>();
            _bulletSpawnPosition = _player;
            _chrono += Time.deltaTime;
        }

        public void Shoot(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                if (_chrono >= _fireRate)
                {
                    Instantiate(_bullet, _bulletSpawnPosition);
                    _chrono = 0f;
                }
            }
        }
    }
}