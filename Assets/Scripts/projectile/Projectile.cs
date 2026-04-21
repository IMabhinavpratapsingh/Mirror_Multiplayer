using System.Collections;
using Mirror;
using UnityEngine;

public class Projectile : NetworkBehaviour
{
    [SerializeField] float force =  10f;
    [SerializeField] Rigidbody rb;
    
    public void Init(Vector3 dir)
    {
        rb.linearVelocity = dir * force;
    }
    
    bool hasHit = false;
    void OnCollisionEnter(Collision other)
    {
        if(!isServer) return;
        if(hasHit) return;
        hasHit = true;

        if(other.gameObject.TryGetComponent(out PlayerHealth player))
        {
            player.TakeDamage(35);
            NetworkServer.Destroy(gameObject);
            return;
        }
        
        StartCoroutine(StartTimer());
        

    }
    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(4f);
        NetworkServer.Destroy(gameObject);
    }
}
