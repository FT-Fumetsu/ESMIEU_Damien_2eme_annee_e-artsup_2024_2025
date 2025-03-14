using UnityEngine;

namespace Spawner
{
    public class EnemySpawn : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private float _spawnInterval = 2f;

        public void Start()
        {
            InvokeRepeating(nameof(SpawnEnemy), 0f, _spawnInterval);
        }

        public void SpawnEnemy()
        {
            float screenHalfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
            float spawnX = Random.Range(-screenHalfWidth, screenHalfWidth);
            float spawnY = Camera.main.orthographicSize + 1f;

            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}