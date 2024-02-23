using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f; // forward speed
    public float jumpForce = 10.0f; // jump force
    public float dodgeSpeed = 7.5f; // left right movement speed
    private Rigidbody rb;
    private bool isGrounded; 
    private int groundContactCount = 0;
    public GameObject PlayerObject;

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
            PlayerObject.GetComponent<Animator>().Play("Jump");
            StartCoroutine(JumpSequence());
        }
        
        // left right movement using x axis ( A/D key )
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f); 
        transform.Translate(movement * dodgeSpeed * Time.deltaTime);
       
    }

     void OnCollisionEnter(Collision collision) // to check and count when player collide with ground
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundContactCount++; 
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Ground") && groundContactCount > 0)
        {
            groundContactCount--; // reduce ground contact count
            if (groundContactCount == 0)
            {
                isGrounded = false;
            }
        }
    }
  
    IEnumerator JumpSequence()
{
    yield return new WaitForSeconds(0.45f);
    isGrounded = true;
    yield return new WaitForSeconds(0.45f);
    isGrounded = false;
    PlayerObject.GetComponent<Animator>().Play("Running"); // Corrected case
}
}