using UnityEngine;

namespace Bullet
{
    [RequireComponent (typeof (Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _bulletSpeed = 5f;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            AddBulletSpeed();
        }
        private void OnBecameInvisible()
        {
            Debug.Log("Invisible");
            Destroy(gameObject);
        }

        public void AddBulletSpeed()
        {
            _rigidbody2D.velocity = new Vector2(0, _bulletSpeed);
        }
    }
}