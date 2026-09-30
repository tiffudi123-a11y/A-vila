/*using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private  float speed = 2f;
    private Vector2 moveInput;
    private Rigidbody2D rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // GetComponent busca todos os componentes, <> especifica qual voce quer
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //Input.GetAxisRaw le o eixo do input, "Horizontal" ja vem configurado
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput.normalized * speed * Time.fixedDeltaTime);
    }
}
*/