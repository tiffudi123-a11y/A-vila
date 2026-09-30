using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movimento")]
    public float moveSpeed = 5f;
    public float stopDistance = 0.1f;

    [Header("Tiro")]
    public Projectile projectilePrefab;
    public float fireRate = 3f;        
    public float muzzleOffset = 0.6f;  

    Rigidbody2D rb;
    Camera cam;
    Vector2 moveDir;
    Vector2 aimDir = Vector2.up;       
    float nextShotTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0f;
        cam = Camera.main;
    }
    
    
    // Update is called once per frame
    void Update()
    {
        moveDir = Vector2.zero;

    
        if (IsMouseHeld())
        {
            Vector2 target = cam.ScreenToWorldPoint(GetMouseScreenPos());
            Vector2 toTarget = target - (Vector2)transform.position;

            if (toTarget.magnitude > stopDistance)
            {
                moveDir = toTarget.normalized;
                aimDir = moveDir;
            }
        }


        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (Time.time >= nextShotTime)
        {
            Shoot();
            nextShotTime = Time.time + 1f / fireRate;
        }
    }

    void FixedUpdate()
    { 
        if (moveDir != Vector2.zero)
        rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);
    }

    void Shoot()
    {
        if (projectilePrefab == null) return;
        Vector3 pos = transform.position + (Vector3)(aimDir * muzzleOffset);
        Projectile p = Instantiate(projectilePrefab, pos, transform.rotation);
        p.Init(aimDir);
    }

    static bool IsMouseHeld()
    {
        return Mouse.current != null && Mouse.current.leftButton.isPressed;
    }

    static Vector3 GetMouseScreenPos()
    {
        return Mouse.current != null ? (Vector3)Mouse.current.position.ReadValue() : Vector3.zero;
    }
}
