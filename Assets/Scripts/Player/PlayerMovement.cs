using UnityEngine;
using Mirror;

using System;



public class PlayerMovement : NetworkBehaviour
{

    JoystickScript joystick;
    [SerializeField] Transform body;
    [SerializeField] Transform cameraa;
    [SerializeField] Transform pivoty;
    Rigidbody rb;
    [SerializeField] float Speed = 5f;
    [SerializeField] float rotationSpeed = 10f;

    Quaternion targetRotation;

    OrbitCamera cam;
    public static event Action<OrbitCamera> SetCamera;
    void Start()
    {
        if (!isLocalPlayer)
        {
            // cameraa.GetComponent<Camera>().enabled = false;
            // cameraa.GetComponent<AudioListener>().enabled = false;
            enabled = false; // script bhi band
            return;
        }

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        joystick = FindAnyObjectByType<JoystickScript>();

    }

    public override  void OnStartLocalPlayer()
    {    
        cam = FindAnyObjectByType<OrbitCamera>(FindObjectsInactive.Include);
        if ( cam == null)
        {
            Debug.Log("Camera not found");
            return;
        }
        
        cam.target = pivoty.transform;
        cameraa = cam.transform;  
        SetCamera?.Invoke(cam);
    }
    
    public Transform GetCam()
    {
        if (cam)
        {
            return cam.transform;
        }
        return null;
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer) return;
        if (!joystick) return;

        Vector2 input = joystick.Output();
        if (input.magnitude > 0.1f)
        {
            Vector3 forward = cameraa.transform.forward;
            Vector3 right = cameraa.transform.right;

            forward.y = 0;
            right.y = 0;

            forward.Normalize();
            right.Normalize();


            Vector3 move = forward * input.y + right * input.x;

            
            targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation,rotationSpeed*Time.deltaTime);
            

            Vector3 vel = rb.linearVelocity;
            vel.x = move.x * Speed;
            vel.z = move.z * Speed;
            rb.linearVelocity = vel;
        }
        else
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y , 0);
            
        }
    }
    
}
