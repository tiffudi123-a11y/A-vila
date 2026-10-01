using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public Transform player;
    public int maxEnemies = 15;
    public int minporvz = 2;
    public int maxporvz = 4;
    public float intervspawn = 2f;
    public float dminspawn = 12f;
    public float maxdspawn = 16f;

    float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0f) return;
        timer = intervspawn;

        
        int count = Mathf.Min(Random.Range(minporvz, maxporvz + 1), maxEnemies - transform.childCount);

        for (int i = 0; i < count; i++)
        {
            Vector2 offset = Random.insideUnitCircle.normalized * Random.Range(dminspawn, maxdspawn);
            Enemy e = Instantiate(enemyPrefab, (Vector2)player.position + offset, Quaternion.identity, transform);
            e.GetComponent<EnemyMovement>().target = player;
        }
    }
}
