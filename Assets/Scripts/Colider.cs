using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    public float moveSpeed = 300f;
    public RectTransform playerTransform;
    public Vector3 initialPosition;

    void Start()
    {
        if (playerTransform == null)
            playerTransform = GetComponent<RectTransform>();

        initialPosition = playerTransform.localPosition;
    }

    void Update()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow)) direction.y += 1;
        if (Input.GetKey(KeyCode.DownArrow)) direction.y -= 1;
        if (Input.GetKey(KeyCode.LeftArrow)) direction.x -= 1;
        if (Input.GetKey(KeyCode.RightArrow)) direction.x += 1;

        playerTransform.localPosition += direction * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Aqui faz o reset da posição quando colide com um obstáculo
        Debug.Log("Colidiu com: " + collision.name);
        playerTransform.localPosition = initialPosition;
    }
}
