using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private float _horizontalMovement;
    private bool _isFacingRight = true;
    private Rigidbody2D _rb;
    private bool _isGround = true;

    [SerializeField] private Animator animator;
    
    public static bool IsDead;

    [Range(0, 10f)] public float speed = 1f;
    [Range(0, 15f)] public float jumpForce = 8f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _isGround = true;

        if (other.gameObject.CompareTag("Enemy"))
        {
            IsDead = true;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        _horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;

        if ((_horizontalMovement < 0 && _isFacingRight) || (_horizontalMovement > 0 && !_isFacingRight))
        {
            Flip();
        }

        animator.SetFloat("HorizontalMove", Mathf.Abs(_horizontalMovement));

        if (Input.GetKeyDown(KeyCode.W) && _isGround)
        {
            _isGround = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 100 * jumpForce, 0));
        }

        if (!_isGround)
        {
            animator.SetBool("Jumping", true);
        }
        else
        {
            animator.SetBool("Jumping", false);
        }
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(_horizontalMovement, _rb.velocity.y);
        _rb.velocity = targetVelocity;
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;

        Vector3 flipped = transform.localScale;
        flipped.x *= -1;
        transform.localScale = flipped;
    }
}