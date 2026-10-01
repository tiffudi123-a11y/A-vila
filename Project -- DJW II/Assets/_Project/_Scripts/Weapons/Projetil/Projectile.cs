using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float speed = 12f;
    public int damage = 20;
    public float tvidaprojetil = 3f;

    void Start() => Destroy(gameObject, tvidaprojetil);

    void Update() => transform.Translate(Vector3.up * speed * Time.deltaTime);

    void OnTriggerEnter2D(Collider2D other)
    { 
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy == null) return;

        enemy.TakeDamage(damage);
        Destroy(gameObject);
    }
}
