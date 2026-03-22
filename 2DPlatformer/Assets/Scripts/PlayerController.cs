using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
     private Rigidbody2D rb;
    private bool isGrounded = false;
    public static GameManager Instance;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }    
    void Update()
    {
        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        
        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.jumpSound);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {   //check for collision against an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.TakeDamage(10);
        }
        //check for collision against the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; }
    }

    //check if the player is not on the ground
    void OnCollisionExit2D(Collision2D collision)
        {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; }
        }
    //collision against the coins
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            GameManager.Instance?.AddScore(10);
            CoinPoolManager.Instance?.ReturnCoin(collision.gameObject);
        }
    }
}
