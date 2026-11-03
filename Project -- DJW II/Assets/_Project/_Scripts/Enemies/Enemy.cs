using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject xpPrefab;
    private bool morto;

    public GameTimer gameTimer;
    private float proximoIntervalo = 300f;

    public int health = 100;
    public int danContato = 10;
    public float ColdownPHit = 0.5f;

	
    float tempproxhit; 

    public void TakeDamage(int amount)
    {
        if (morto) return;

        health -= amount;
        if (health > 0) return;

        morto = true;

        if (xpPrefab != null)
        {
            GameObject drop = Instantiate(xpPrefab,transform.position,Quaternion.identity);

            if (drop.TryGetComponent<XP>(out var xp))
            xp.gameTimer = gameTimer;
        }

            Destroy(gameObject);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Time.time < tempproxhit) return;
        if (!other.TryGetComponent(out PlayerHealth player)) return;

        player.TakeDamage(danContato); 
        tempproxhit = Time.time + ColdownPHit; 
    }
    
    void Update()
    {
        if (gameTimer != null && gameTimer.TempoDecorrido >= proximoIntervalo)
        {
        health += 20;
        danContato *= 2;
        ColdownPHit += 0.5f;
        proximoIntervalo += 300f;

        Debug.Log("Dano de contato dos inimigos: " + danContato);
        }
    }
}
