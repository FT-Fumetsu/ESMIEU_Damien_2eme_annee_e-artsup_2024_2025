using UnityEngine;

namespace Spawner
{
    public class EnemySpawn : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private float spawnInterval = 2f;

        public void Start()
        {
            InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
        }

        public void SpawnEnemy()
        {
            float screenHalfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
            float spawnX = Random.Range(-screenHalfWidth, screenHalfWidth);
            float spawnY = Camera.main.orthographicSize + 1f;

            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}