using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
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

    [Header("Som de Passos")]
    public AudioClip somPassos;      // arraste no Inspector
    private AudioSource audioSource;

    void Start()
    {
        troca = FindObjectOfType(typeof(Troca_Personagens)) as Troca_Personagens;
        rb = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.loop = true; // deixa o som contínuo
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        Movimentacao();
        Jump();

        ControlarSomPassos();
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

    void ControlarSomPassos()
    {
        if (IsGrounded && Mathf.Abs(moveInput) > 0.1f)
        {
            if (!audioSource.isPlaying && somPassos != null)
            {
                audioSource.clip = somPassos;
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
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
