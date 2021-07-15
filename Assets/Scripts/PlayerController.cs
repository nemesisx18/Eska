using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    [SerializeField]
    private float jumpTime = 0;

    private PlayerMotor motor;
    
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        if (PauseMenu.IsOn)
        {
            motor.Move(Vector3.zero);
            motor.Rotate(Vector3.zero);
            motor.RotateCamera(0f);
            
            return;
        }
        
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        //Apply movement
        motor.Move(_velocity);

        //Calculate rotation as a 3D vector
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        //Apply rotation
        motor.Rotate(_rotation);

        //Calculate rotation as a 3D vector
        float _xRot = Input.GetAxisRaw("Mouse Y");

        float _cameraRotationX = _xRot * lookSensitivity;

        //Apply camera rotation
        motor.RotateCamera(_cameraRotationX);

        //Apply jump
        if (jumpTime == 0)
        {
            if (Input.GetButtonDown("Jump"))
            {
                motor.Jump();
                jumpTime += 1;
            }
        }
        //Reset jump
        if (motor.isGrounded == true)
        {
            jumpTime = 0;
        }

        if (Input.GetButton("Walk"))
        {
            Vector3 _velocityWalk = (_movHorizontal + _movVertical).normalized * 2f;

            motor.Move(_velocityWalk);
        }
    }
}
