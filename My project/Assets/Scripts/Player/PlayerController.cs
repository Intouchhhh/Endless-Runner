using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f; // forward speed
    public float jumpForce = 9.0f; // jump force
    public float dodgeSpeed = 7.5f; // left right movement speed
    private Rigidbody rb;
    private bool isGrounded; 
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Horizontal movement (make the player move foward)
        transform.Translate(Vector3.forward  * Time.deltaTime * speed, Space.World);

        //Jump (space key)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        
        // left right movement using x axis ( A/D key )
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f); 
        transform.Translate(movement * dodgeSpeed * Time.deltaTime);
       
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if player is collied with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Check if player is no longer on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
  
}