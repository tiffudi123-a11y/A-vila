using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public int TotalXP { get; private set; }

    public void AdicionarXP(int quantidade)
    {
        TotalXP += quantidade;
    }
}
