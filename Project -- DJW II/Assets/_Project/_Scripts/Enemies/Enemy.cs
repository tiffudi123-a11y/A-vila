using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameTimer gameTimer;
    private float proximoIntervalo = 300f;

    public int health = 100;
    public int dancontato = 10;
    public float ColdownPHit = 0.5f;

	
    float tempproxhit; 

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0) Destroy(gameObject);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Time.time < tempproxhit) return;
        if (!other.TryGetComponent(out PlayerHealth player)) return;

        player.TakeDamage(dancontato);
        tempproxhit = Time.time + ColdownPHit; 
    }
    
    void Update()
    {
   	if (gameTimer.timer >= proximoIntervalo)
        {
            health += 20;
	    danContato *= 2;
	    coldownHit += 0.5f;
            proximoIntervalo += 300f;

            Debug.Log("Nível dos inimigos: " + nivelInimigo);
        }

    }
}
