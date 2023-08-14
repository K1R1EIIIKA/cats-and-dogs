using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Test : MonoBehaviour
{

    private float HorizontalMove = 0f;
    private bool FacingRight = true;

    Rigidbody2D rb;
    SpriteRenderer sr;

    [Header("Player Animation Settings")]
    public Animator animator;

    [Space]
    [Header("Ground Checker Settings")]
    public bool isGround = true;
    [Range(-5f, 5f)] public float checkgroundOffsety = -1.8f;
    [Range(0f, 5f)] public float checkgroundRasius= 0.3f;

    [Header("Player Movement Settings")]
    [Range(0, 10f)] public float speed = 1f;
    [Range(0, 15f)] public float jumpForce = 8f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       

        HorizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        if (HorizontalMove < 0 && FacingRight)
        {
            Flip();
        }
        else if(HorizontalMove > 0 && !FacingRight)
        {
            Flip();
            
        }

        animator.SetFloat("HorizontalMove", Mathf.Abs(HorizontalMove));

        if (Input.GetKeyDown(KeyCode.W) && isGround == true)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
        if (isGround == false)
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
        Vector2 targetVelocity = new Vector2(HorizontalMove, rb.velocity.y);
        rb.velocity = targetVelocity;

        Checkgtound();

    }

    private void Flip()
    {
        FacingRight = !FacingRight;

        Vector3 theSale = transform.localScale;
        theSale.x *= -1;
        transform.localScale = theSale;
    }

    private void Checkgtound()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y + checkgroundOffsety), checkgroundRasius);

        if (colliders.Length > 1) { 
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }
}
