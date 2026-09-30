using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public float restartDelay = 2f;

    int health;
    bool dead;

    void Awake() => health = maxHealth;

    public void TakeDamage(int amount)
    {
        if (dead) return;

        health = Mathf.Max(0, health - amount);
        if (health == 0)
        {
            dead = true;
            Invoke(nameof(Restart), restartDelay);
        }
    }
    void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
