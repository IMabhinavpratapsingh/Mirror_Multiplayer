
using Mirror;

using UnityEngine;

public class PlayerShoot : NetworkBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform cameraa;
    [SerializeField] Transform body;

    OrbitCamera cam;

    // void Start()
    // {
    //     if (!isLocalPlayer)
    //     {
    //         cameraa.GetComponent<AudioListener>().enabled = false;
    //     }
    // }
    public override void OnStartLocalPlayer()
    {
        cameraa = this.gameObject.GetComponent<PlayerMovement>().GetCam();
    }
    

    void OnEnable()
    {
        GamePlayUI.shoot += shoot;
        
    }
    void OnDisable()
    {
        GamePlayUI.shoot -= shoot;
    }
    void shoot()
    {


        if (!isLocalPlayer) return;
        


        Vector3 dir = cameraa.forward;
        CmdShoot(dir);
    }

    [Command]
    void CmdShoot(Vector3 dir)
    {

        GameObject obj = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
        NetworkServer.Spawn(obj);
        obj.GetComponent<Projectile>().Init(dir);
    }



}
