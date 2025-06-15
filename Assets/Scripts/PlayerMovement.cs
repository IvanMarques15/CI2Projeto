using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private float speedX;
    private float speedY;
    private Vector3 posicaoInicial;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posicaoInicial = transform.position;
    }

    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal");
        speedY = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speedX * moveSpeed, speedY * moveSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisão com: " + collision.gameObject.tag);

        if (collision.gameObject.CompareTag("box"))
        {
            Debug.Log("TOCOU NA BOX");
            transform.position = posicaoInicial;
        }
        else if (collision.gameObject.CompareTag("frango"))
        {
            Debug.Log("TOCOU NO FRANGO");
            SceneManager.LoadScene("Derrota");
        }
        else if (collision.gameObject.CompareTag("melancia"))
        {
            Debug.Log("TOCOU NA MELANCIA");
            
        }
    }
}
