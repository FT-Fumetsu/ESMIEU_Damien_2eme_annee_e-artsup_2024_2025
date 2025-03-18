using UnityEngine;

namespace Bullet
{
    [RequireComponent (typeof (Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _bulletSpeed = 5f;
        [SerializeField] private Rigidbody2D _rigidbody;

        private void Update()
        {
            BulletSpeed();
        }
        private void OnBecameInvisible()
        {
            Debug.Log("Invisible");
            Destroy(gameObject);
        }

        public void BulletSpeed()
        {
            _rigidbody.velocity = new Vector2(0, _bulletSpeed);
        }
    }
}