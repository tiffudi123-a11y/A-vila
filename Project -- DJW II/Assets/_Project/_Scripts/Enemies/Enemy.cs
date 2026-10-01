using UnityEngine;

public class Enemy : MonoBehaviour
{
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
}
