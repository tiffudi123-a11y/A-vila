using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public Transform target; 

    void Update()
    {
        if (target == null) return;
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
}
