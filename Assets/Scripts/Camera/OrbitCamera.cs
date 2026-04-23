using UnityEngine;
using ETouch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using UnityEngine.InputSystem.EnhancedTouch;

public class OrbitCamera : MonoBehaviour
{

    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -5);

    [Header("Zoom Settings")]
    [SerializeField] float zoomSpeed = 0.05f;
    [SerializeField] float minZoom = 2f;
    [SerializeField] float maxZoom = 20f; 

    private float currentZoomDistance; 
    [HideInInspector] public Quaternion orbitRotation = Quaternion.identity;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        currentZoomDistance = Mathf.Abs(offset.z); 
    
        if(currentZoomDistance == 0) currentZoomDistance = 5f;

    }

    void LateUpdate()
    {
       if(target != null)
        {
            var touches = ETouch.activeTouches;
            if (touches.Count == 2)
            {
                var touch0 = touches[0];
                var touch1 = touches[1];

                Vector2 prevPos0 = touch0.screenPosition - touch0.delta;
                Vector2 prevPos1 = touch1.screenPosition - touch1.delta;

                float prevMagnitude = ( prevPos0 - prevPos1).magnitude;
                float currentMagnitude = (touch0.screenPosition - touch1.screenPosition).magnitude;

                float difference = currentMagnitude - prevMagnitude;
                currentZoomDistance = Mathf.Clamp(currentZoomDistance - (difference*zoomSpeed),minZoom,maxZoom);
            }
            Vector3 finalOffset = new Vector3(offset.x , offset.y , -currentZoomDistance);
            transform.position = target.position + orbitRotation * finalOffset;
            transform.LookAt(target);
        }    
    }
}
