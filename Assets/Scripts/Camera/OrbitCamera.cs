using UnityEngine;

public class OrbitCamera : MonoBehaviour
{

    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -5);
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

    }

    void LateUpdate()
    {
        if ( target == null)
        {
            Debug.Log("pivot nahi mila");
        }
       if(target != null)
        {
            Debug.Log("pivot mil rha hai " + target.position);
            // transform.position = target.position + target.rotation * offset;
            
        } 
    }
}
