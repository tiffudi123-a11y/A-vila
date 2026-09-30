using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public Transform player;
    public int maxEnemies = 10;
    public float spawnInterval = 1f;
    public float extraDistance = 2f;

    Camera cam;
    float nextSpawnTime;

    void Start() => cam = Camera.main;

    void Update()
    {
        if (player == null || enemyPrefab == null) return;

        
        if (Enemy.Alive < maxEnemies && Time.time >= nextSpawnTime)
        {
            Spawn();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void Spawn()
    {
        float halfH = cam.orthographicSize;
        float halfW = halfH * cam.aspect;
        float radius = Mathf.Sqrt(halfW * halfW + halfH * halfH) + extraDistance;

        Vector2 pos = (Vector2)player.position + Random.insideUnitCircle.normalized * radius;
        Enemy e = Instantiate(enemyPrefab, pos, Quaternion.identity);
        e.SetTarget(player);
    }
}
