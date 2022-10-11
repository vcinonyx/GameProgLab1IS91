using UnityEngine;

public class SquareMovement : MonoBehaviour
{
    private const float Speed = 4f;
    private const float Jump = 6.6f;
    private const float CheckRadius = 0.4f;
    private Vector2 _move;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        Debug.Log("Awake");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _move.x = Input.GetAxis("Horizontal");

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (_move != Vector2.zero)
        {
            transform.Translate(Speed * Time.fixedDeltaTime * _move);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, CheckRadius, groundLayer);
    }
}
