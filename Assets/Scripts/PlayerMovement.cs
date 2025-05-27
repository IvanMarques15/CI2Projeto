using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Captura das setas do teclado
        movement.x = Input.GetAxisRaw("Horizontal"); // Esquerda (-1), Direita (+1)
        movement.y = Input.GetAxisRaw("Vertical");   // Baixo (-1), Cima (+1)
    }

    void FixedUpdate()
    {
        // Movimentação baseada na física
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
