using UnityEngine;
using Valve.VR;
public class PlayerMovementVR : MonoBehaviour
{
    public bool UseDancePad;

    public Transform vrCamera;
    public SteamVR_Action_Vector2 joyStickAction;
    public float speed = 10.0f;
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;
    public bool canJump = true;
    public float jumpHeight = 2.0f;
    private bool grounded = false;


    Rigidbody rigidbody;


    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
        rigidbody.useGravity = false;
    }

    void Movement(Vector3 move)
    {
        //transform.position += vrCamera.transform.forward * speed * Time.deltaTime;
        rigidbody.AddForce(move);
    }

    void Update()
    {
        if (UseDancePad)
        {
            DancePadMovement();
        }
    }

    void FixedUpdate()
    {
        if (grounded)
        {
            if (!UseDancePad)
            {
                // Calculate how fast we should be moving
                Vector2 joyStickValue = joyStickAction.GetAxis(SteamVR_Input_Sources.Any);
                Vector3 targetVelocity = new Vector3(joyStickValue.x, 0, joyStickValue.y);
                targetVelocity = transform.TransformDirection(targetVelocity);
                targetVelocity *= speed;

                // Apply a force that attempts to reach our target velocity
                Vector3 velocity = rigidbody.velocity;
                Vector3 velocityChange = (targetVelocity - velocity);
                velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
                velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
                velocityChange.y = 0;
                rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
                //Debug.Log(velocityChange);

                // Jump
                if (canJump && Input.GetButton("Jump"))
                {
                    rigidbody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
                    rigidbody.AddForce(new Vector3(0, -gravity * rigidbody.mass, 0));
                    grounded = false;
                }
            }
        }

        // We apply gravity manually for more tuning control

    }

    void DancePadMovement()
    {
        if (Input.GetKey(KeyCode.JoystickButton2))
        {
            //Forward
            Debug.Log("Forward");
            
            Movement(new Vector3(-2000f,0,0));
        }
        if (Input.GetKey(KeyCode.JoystickButton3))
        {
            Debug.Log("Right");
            Movement(new Vector3(0, 0, 2000f));
        }

        if (Input.GetKey(KeyCode.JoystickButton0))
        {
            Debug.Log("Left");
            Movement(new Vector3(0, 0, -2000f));
        }
        if (Input.GetKey(KeyCode.JoystickButton1))
        {
            Debug.Log("Back");
            Movement(new Vector3(2000f, 0, 0));
        }
    }

    void OnCollisionStay()
    {
        grounded = true;
    }

    float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }
}