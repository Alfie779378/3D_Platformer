using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 8f;
    public float jumpHeight = 2f;
    public float gravity = -20f;
    private CharacterController controller;
    private Vector3 velocity;
    public Transform cameraTransform;
    public float standingHeight = 2f;
    public float crouchingHeight = 1f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        HandleMovement();
        ApplyGravity();
        HandleJump();
        HandleCrouch();

    }
    void HandleMovement()
    {

    


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        Vector3 normalizedDirection = direction.normalized;

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();


        Vector3 moveDirection = (forward * vertical + right * horizontal).normalized;

        if (moveDirection != Vector3.zero)
        {


            float currentSpeed = moveSpeed;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentSpeed = sprintSpeed;
            }




            controller.Move(moveDirection * currentSpeed * Time.deltaTime);
        }
    }



    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);


        }
        


    }
    void ApplyGravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }




    void HandleCrouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = crouchingHeight;
        }
        else
        {
            controller.height = standingHeight;
        }
    }
}