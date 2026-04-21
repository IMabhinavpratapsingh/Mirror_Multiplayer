
using UnityEngine;
using Mirror;


public class CameraDrag : NetworkBehaviour
{
    [SerializeField] Transform pivotY;


    [SerializeField] float sensitivity = 0.2f;

    InputSystem_Actions input;

    float xRotation;
    float yRotation;

    void Awake()
    {
        input = new InputSystem_Actions();
        input.Touch.Enable();
    }

    void Start()
    {
        if (!isLocalPlayer)
        {
            input.Disable();
            pivotY.gameObject.SetActive(false);

        }
    }



    void Update()
    {
        if (!isLocalPlayer) return;

        Vector2 delta = input.Touch.Delta.ReadValue<Vector2>();
        Vector2 pos = input.Touch.Position.ReadValue<Vector2>();

        if (pos.x > Screen.width / 2)
        {
            yRotation += delta.x * sensitivity ;
            xRotation -= delta.y * sensitivity ;


            xRotation = Mathf.Clamp(xRotation, -40f, 60f);
            pivotY.localRotation = Quaternion.Euler(xRotation, yRotation, 0);

        }

    }


}
