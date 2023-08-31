using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
   private CharacterController controller; 
   [SerializeField] private float playerSpeed = 2.0f;
   [SerializeField] private float jumpHeight = 1.0f;
   [SerializeField] private float gravityValue = -9.8f;
   private Vector2 _playerInput;
   private Vector2 playerVelocity;
   private bool jump;
   private bool isGrounded;
   private bool shoot;
   [SerializeField] private float bulletSpeed = 5;
   [SerializeField] private GameObject bulletPrefab;
   [SerializeField] private Transform firePoint;
   public void playerShoot(InputAction.CallbackContext context)
   {
    shoot = context.action.triggered;
   }

   public void playerMove(InputAction.CallbackContext context)
   {

    _playerInput = context.ReadValue<Vector2>();
    Debug.Log(_playerInput);

   }

   public void playerJump(InputAction.CallbackContext context)
   {
    jump = context.action.triggered;
   }

   private void Start ()
    {
        controller = gameObject.GetComponent<CharacterController>();

    }


    void Update()
    {
        isGrounded = controller.isGrounded;
        if(isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }

        Vector3 move =  new Vector3(_playerInput.x , 0, _playerInput.y);
        controller.Move(move* Time.deltaTime * playerSpeed); 

        if(jump && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if(shoot)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody Bulletrb = bullet.GetComponent<Rigidbody>();
        Bulletrb.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
    }
    }

}