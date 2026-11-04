using UnityEngine;

public class MenuBau : MonoBehaviour
{
    [SerializeField] private GameObject painelBau;

    private int escolhasPendentes;
    private float velocidaAnterior;

    void Awake()
    {
        painelBau.SetActive(false);
    }

    public void Abrir()
    {
        escolhasPendentes++;
        if (escolhasPendentes > 1) return;

        velocidaAnterior = Time.timeScale;
        painelBau.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Escolher()
    {
        if (escolhasPendentes <= 0) return;
        escolhasPendentes--;
        if (escolhasPendentes > 0) return;

        painelBau.SetActive(false);
        Time.timeScale = velocidaAnterior;

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
