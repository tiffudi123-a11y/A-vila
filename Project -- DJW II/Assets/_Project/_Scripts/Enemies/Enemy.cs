using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public float moveSpeed = 2.5f;
    public int contactDamage = 10;
    public float damageCooldown = 0.5f; 

    
    public static int Alive { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void ResetStatics() => Alive = 0;

    int health;
    float nextHitTime;
    Rigidbody2D rb;
    Transform target;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0f;
        GetComponent<Collider2D>().isTrigger = true;
        health = maxHealth;
    }

    void OnEnable()  => Alive++;
    void OnDisable() => Alive--;

    public void SetTarget(Transform t) => target = t;

    void FixedUpdate()
    {
        if (target == null) return;
        Vector2 dir = ((Vector2)target.position - rb.position).normalized;
        rb.MovePosition(rb.position + dir * moveSpeed * Time.fixedDeltaTime);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0) Destroy(gameObject);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Time.time < nextHitTime) return;

        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player == null) return;

        player.TakeDamage(contactDamage);
        nextHitTime = Time.time + damageCooldown;
    }
}
