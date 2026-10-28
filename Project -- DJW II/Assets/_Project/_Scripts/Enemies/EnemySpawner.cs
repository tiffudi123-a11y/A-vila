using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameTimer gameTimer;
    private float proximoIntervalo = 300f;

    public GameObject XP;
	
    public Enemy enemyPrefab;
    public Transform player;
    public int maxEnemies = 15;
    public int minPorVez = 2;
    public int maxPorVez = 4;
    public float intervspawn = 2f;
    public float dminspawn = 12f;
    public float maxdspawn = 16f;


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

	if (gameTimer.timer >= proximoIntervalo)
        {
            maxPorVz += 20;
            proximoIntervalo += 300f;

            Debug.Log("Nível dos inimigos: " + nivelInimigo);
    }
}
