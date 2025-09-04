using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ZombieMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Animator animator;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // pega o Animator do zumbi
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        // movimenta o zumbi
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // ajusta direção (flip horizontal)
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // atualiza parâmetro de animação
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
    }
}
