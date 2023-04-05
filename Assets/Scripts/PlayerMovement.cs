using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region GameObjects

    [SerializeField] private CharacterController characterController;
    [SerializeField] private TeleportController teleportController;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    #endregion

    #region Variables

    private const float gravity = -50f;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float speed;
    [SerializeField] private float groundDistance = 0.4f;
    private RaycastHit raycastHit;
    private bool isGrounded;
    
    #endregion
    
    private void OnDrawGizmos()
    {
        // Gizmos.color = Color.magenta;
        // Gizmos.DrawSphere(groundCheck.position, groundDistance);
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        // if freefall and sphere found the ground then set velocity.y = -2
        if (isGrounded && velocity.y < 0) velocity.y = -2f;
        
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        // right -> (1,0,0), forward -> (0,0,1)
        var move = transform.right * x + transform.forward * z;
        // for x and z movement only
        characterController.Move(speed * Time.deltaTime * move);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // sqrt is used to reduce the y component...otherwise player would blow up
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            
            if (Physics.Raycast(ray, out raycastHit))
            {
                teleportController.OnTeleport(raycastHit.point + Vector3.up * 1.7f);
            }
        }
        
        
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}