using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    [SerializeField] private MenuBau menuBau;

    public int XPAtual { get; private set; }
    public int nivel {get; private set;} = 1;

    public void AdicionarXP(int quantidade)
    {
        if (quantidade <= 0) return;

        XPAtual += quantidade;

        while (XPAtual >= 300)
        {
            XPAtual -= 300;
            nivel++;

            if (menuBau != null)
            menuBau.Abrir();

            Debug.Log("Subiu para o nivel " + nivel);
        }

        Debug.Log($"nivel: {nivel} | XP: {XPAtual}/300");
    }
}