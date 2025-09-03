using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

//[RequireComponent (typeof(Animator))]

public class Movimentação : MonoBehaviour

{
    Troca_Personagens troca;
    public float moveSpeed = 3f;
    public float jumpForce = 1f;
    private Rigidbody2D rb;
    private bool IsGrounded;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    private float moveInput;

    void Start()

    {
        troca = FindObjectOfType(typeof(Troca_Personagens)) as Troca_Personagens;
        rb = GetComponent<Rigidbody2D>();

    }



    void Update()

    {
        moveInput = Input.GetAxis("Horizontal");
        Movimentacao();
        Jump();

    }

    void Movimentacao()

    {

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (moveInput > 0)

        {

            transform.localScale = new Vector3(1, 1, 1);

        }

        else if (moveInput < 0)

        {
            transform.localScale = new Vector3(-1, 1, 1);

        }

    }

    void Jump()

    {

        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && IsGrounded)

        {

            rb.AddForceY(jumpForce * 300);

        }

    }

    void OnDrawGizmosSelected()

    {

        if (groundCheck != null)

        {

            Gizmos.color = Color.yellow;

            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);

        }

    }

}

