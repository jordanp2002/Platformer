using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float jumpForce = 8f;
    public Transform cameraTransform;
    private Rigidbody rb;
    private bool isGrounded;
    private int jumpCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Move();
        Jump();
    }
    void Move()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W)) moveZ += 1;
        if (Input.GetKey(KeyCode.S)) moveZ -= 1;
        if (Input.GetKey(KeyCode.A)) moveX -= 1;
        if (Input.GetKey(KeyCode.D)) moveX += 1;

        Vector3 moveDirection = cameraTransform.forward * moveZ + cameraTransform.right * moveX;
        moveDirection.y = 0;


        // Snapping Player to moving direction so model don't look straight the whole time
        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection; 
        }
        rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2) 
        {
            //check for two jumps, if over 2 don't jump anymore
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            jumpCount++; 
        }
    }

    void OnCollisionEnter(Collision Ground)
    {
        if (Ground.gameObject.CompareTag("Ground"))
        {   
            //reset jumpcount when hitting ground
            isGrounded = true;
            jumpCount = 0;
        }
    }
    void OnTriggerEnter(Collider Coin)
    {

        //if Coin is triggered by player colliding, incremement score and remove the coin
        if (Coin.CompareTag("Coin"))
        {
            FindFirstObjectByType <Score>().AddScore(); 
            Destroy(Coin.gameObject); 
        }
    }
}


