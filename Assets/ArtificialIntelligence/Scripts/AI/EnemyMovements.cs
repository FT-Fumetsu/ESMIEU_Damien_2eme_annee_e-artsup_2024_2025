using UnityEngine;

namespace StateMachine
{
    public class EnemyMovements : MonoBehaviour
    {

        private void Update()
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}