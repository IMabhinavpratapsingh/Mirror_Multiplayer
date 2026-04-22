using UnityEngine;

public class OrbitCamera : MonoBehaviour
{

    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -5);

    [HideInInspector] public Quaternion orbitRotation = Quaternion.identity;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

    }

    void LateUpdate()
    {
       if(target != null)
        {
            
            transform.position = target.position + orbitRotation * offset;
            transform.LookAt(target);
        } 
    }
}
