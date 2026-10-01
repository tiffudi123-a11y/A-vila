using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject projectilePrefab;
    public float tsegundo = 3f;
    public float dtplayer = 0.6f;

    Camera cam;
    float ttemp = 1;

    void Start() => cam = Camera.main;

    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            Vector2 mouse = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 dir = mouse - (Vector2)transform.position;

            if (dir.sqrMagnitude > 0.01f)
            {
                transform.up = dir; // aponta para o mouse (sprite desenhado para cima)
                transform.position = Vector2.MoveTowards(transform.position, mouse, moveSpeed * Time.deltaTime);
            }
        }

        
        ttemp -= Time.deltaTime;
        if (ttemp <= 0f)
        {
            Instantiate(projectilePrefab, transform.position + transform.up * dtplayer, transform.rotation);
            ttemp = 1f / tsegundo;
        }
    }
}
