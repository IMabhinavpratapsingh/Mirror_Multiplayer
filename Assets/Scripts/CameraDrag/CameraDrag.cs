
using UnityEngine;
using Mirror;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.EventSystems;

public class CameraDrag : NetworkBehaviour
{
    [SerializeField] Transform pivotY;
    [SerializeField] float sensitivity = 0.2f;


    OrbitCamera orbitCam;

    private int fingerId = -1;

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
            if (touch.phase == UnityEngine.InputSystem.TouchPhase.Began)
            {
                if(touch.startScreenPosition.x > Screen.width / 2)
                {
                    if (!EventSystem.current.IsPointerOverGameObject(touch.touchId))
                    {
                        fingerId = touch.touchId;
                    }
                }
            }
            
            if ( touch.touchId == fingerId)
            {
                if (touch.phase == UnityEngine.InputSystem.TouchPhase.Moved)
                {
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
            
            if (touch.phase == UnityEngine.InputSystem.TouchPhase.Ended || touch.phase == UnityEngine.InputSystem.TouchPhase.Canceled)
            {
                fingerId = -1;
            }
        }
    }
}
