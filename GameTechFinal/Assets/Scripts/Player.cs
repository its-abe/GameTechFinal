using UnityEngine;

public class Player : MonoBehaviour
{
   public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public float jump;
    private Animator m_Animator;
    private bool jumping;
    private Transform trans;

    private bool reverseState;
    float jumpCooldown = 1.0f;
    float timeSinceJump = 0.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_Animator = GetComponentInChildren<Animator>();
        trans = GameObject.Find("Graphics").transform;
        reverseState = false;
        jumping = false;
    }
    void Update()
    {
        timeSinceJump += Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            m_Animator.SetBool("walking", true);
            trans.rotation = Quaternion.Euler(0, 180, 0);
        }
        // Check if the A key is pressed
        else if (Input.GetKey(KeyCode.A))
        {
            // Move left
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            m_Animator.SetBool("walking", true);
            trans.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !reverseState){
            transform.position = new Vector2(transform.position.x, transform.position.y - 4f);
            rb.gravityScale = -3;
            reverseState = true;
            trans.rotation = Quaternion.Euler(0, 0, 180);
        } else if (Input.GetKeyDown(KeyCode.Space) && reverseState == true){
            transform.position = new Vector2(transform.position.x, transform.position.y + 4f);
            rb.gravityScale = 3;
            reverseState = false;
            trans.rotation = Quaternion.Euler(0, 0, 0);
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
        if (timeSinceJump <= jumpCooldown){
            m_Animator.SetBool("jumping", true);
        } else {
            m_Animator.SetBool("jumping", false);
            jumping = false;
        }
        if (!Input.anyKey && !jumping){
            m_Animator.SetBool("walking", false);
        }
    }
}