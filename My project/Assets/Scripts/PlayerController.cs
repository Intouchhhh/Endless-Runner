using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 10.0f;
    public float dodgeSpeed = 7.5f; 
    private Rigidbody rb;
    private bool isGrounded;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Horizontal movement (make the player move foward)
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        //Jump (space key)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        
        // left right movement using z axis ( A/D key )
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(0.0f, 0.0f, -moveHorizontal);
        transform.Translate(movement * dodgeSpeed * Time.deltaTime);
       
    }

    void OnCollisionEnter(Collision collision)
    {
        //this use to check if the player is on the ground
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Player has collided with the ground.");
        }
        else
        {
            Debug.Log("Collided with: " + collision.collider.name);
        }
    }
}