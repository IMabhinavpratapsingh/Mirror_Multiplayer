
using Mirror;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : NetworkBehaviour
{
    public int maxHealth = 100;

    [SyncVar(hook = nameof(OnHealthChanged))]
    int currentHealth;
    Vector3 startPos;
    public override void OnStartServer()
    {
        
        currentHealth = maxHealth;  
        
        startPos = this.gameObject.transform.position;
        
    }
    void Start()
    {
        startPos = transform.position;
    }
    
    
    public void TakeDamage(int amount)
    {
        if(!isServer) return;
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth,0,maxHealth);
        if (currentHealth <= 0)
        {
            currentHealth = maxHealth;
            RpcRespawn();
        }
    }

   void OnHealthChanged(int oldValue, int newValue)
    {
        if(!isLocalPlayer) return;

        Slider sl = GamePlayUI.instance.HealthBar;
        sl.interactable = false;
        sl.value = (float)newValue / maxHealth;

        if(newValue <= 30)
        {
            sl.fillRect.GetComponent<Image>().color = Color.red;
        }
    } 

    [ClientRpc]
    void RpcRespawn()
    {
        GamePlayUI.instance.HealthBar.fillRect.GetComponent<Image>().color = Color.white;
        
        transform.position =  startPos;

        if (TryGetComponent(out Rigidbody rb))
        {
            rb.linearVelocity = Vector3.zero;
        }
    }

    
    
}
