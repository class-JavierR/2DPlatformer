using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    private int health = 100;
    private int score = 0;
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
     private Rigidbody2D rb;
    private bool isGrounded = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateUI();
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
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {   //check for collision against an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 10;
            UpdateUI();
            
            if (health <= 0)
            {
                GameOver();
            }
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
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            score += 10;
            Destroy(other.gameObject);
            UpdateUI();
        }
    }
    //update ui with score and health
    void UpdateUI()
    {
        healthText.text = "Health: " + health;
        scoreText.text = "Score: " + score;
    }
    void GameOver()
    {
        // Save score before loading GameOver scene
        PlayerPrefs.SetInt("FinalScore", score);
        SceneManager.LoadScene(3);
    }
}
