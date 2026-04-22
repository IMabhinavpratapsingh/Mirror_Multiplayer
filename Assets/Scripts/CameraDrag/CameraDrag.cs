
using UnityEngine;
using Mirror;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using UnityEngine.InputSystem.EnhancedTouch;

public class CameraDrag : NetworkBehaviour
{
    [SerializeField] Transform pivotY;
    [SerializeField] float sensitivity = 0.2f;

    OrbitCamera orbitCam;

    // InputSystem_Actions input;

    float xRotation;
    float yRotation;

    // void Awake()
    // {
    //     input = new InputSystem_Actions();
    //     input.Touch.Enable();
    // }

    void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }
    void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    void Start()
    {
        if (!isLocalPlayer)
        {
            enabled = false;
            pivotY.gameObject.SetActive(false);
            return;
        }

        orbitCam = FindAnyObjectByType<OrbitCamera>(FindObjectsInactive.Include);
    }



    void Update()
    {
        if (!isLocalPlayer) return;

        foreach( var touch in Touch.activeTouches)
        {
            if (touch.startScreenPosition.x  <= Screen.width / 2f ) continue;
            
            Vector2 delta = touch.delta;
            
            yRotation += delta.x * sensitivity;
            xRotation -= delta.y * sensitivity;
            xRotation = Mathf.Clamp(xRotation,-40f,30f);

            if (orbitCam != null)
            {
                orbitCam.orbitRotation =  Quaternion.Euler(xRotation,yRotation,0);
            
            }

            
        }

        

    }


}
