using UnityEngine;

public class XP : MonoBehaviour
{
    public GameTimer gameTimer;

    public int quantidadeXP = 10;
    private float proximoIntervalo = 300f;


    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerXP player = other.GetComponentInParent<PlayerXP>();

        if (player == null) return;

        player.AdicionarXP(quantidadeXP);
        
        Destroy(gameObject);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTimer != null && gameTimer.TempoDecorrido >= proximoIntervalo)
    	{
        	quantidadeXP += 10;
        	
        	proximoIntervalo += 300f;
    	}
    }
}
