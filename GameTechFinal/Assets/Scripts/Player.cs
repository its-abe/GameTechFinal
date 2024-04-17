using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Check if the D key is pressed
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
    }
}
