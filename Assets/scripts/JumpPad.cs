using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce;
    private Vector3 velocity;
    public PlayerController characterController;

    private void Start()
    {
        //characterController = GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            characterController = other.GetComponent<PlayerController>();
            characterController.HandleJumpPadJump(jumpForce);
            other.GetComponent<CharacterController>().Move(velocity* Time.deltaTime);
        }
       
    }
}
