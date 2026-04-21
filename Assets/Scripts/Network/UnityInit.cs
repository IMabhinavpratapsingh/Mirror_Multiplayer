using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;

public class UnityInit : MonoBehaviour
{
    async void Start()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        Debug.Log("Service readyyyyy");
    }
}
