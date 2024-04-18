using UnityEngine;

public class Player : MonoBehaviour
{
   public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public float jump;

    private bool reverseState;
    float jumpCooldown = 1.0f;
    float timeSinceJump = 0.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        reverseState = false;
    }
    void Update()
    {
        timeSinceJump += Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
        {
            // Move right
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        // Check if the A key is pressed
        else if (Input.GetKey(KeyCode.A))
        {
            // Move left
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !reverseState){
            transform.position = new Vector2(transform.position.x, transform.position.y - 4f);
            rb.gravityScale = -3;
            reverseState = true;
        } else if (Input.GetKeyDown(KeyCode.Space) && reverseState == true){
            transform.position = new Vector2(transform.position.x, transform.position.y + 4f);
            rb.gravityScale = 3;
            reverseState = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && !reverseState && timeSinceJump > jumpCooldown)
            {
            timeSinceJump = 0;
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            }
        if (Input.GetKeyDown(KeyCode.LeftShift) && reverseState && timeSinceJump > jumpCooldown)
            {
                timeSinceJump = 0;
                rb.AddForce(new Vector2(rb.velocity.x, -jump));
            }
    }
}