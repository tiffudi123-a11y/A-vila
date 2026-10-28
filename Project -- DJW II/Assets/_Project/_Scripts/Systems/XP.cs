using UnityEngine;

public class XP : MonoBehaviour
{

    public int quantidadeXP = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerXP player))
        {
            player.AdicionarXP(quantidadeXP);
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
