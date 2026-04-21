using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class GameStartUI : MonoBehaviour
{

    [SerializeField] Button hostButton;
    [SerializeField] Button joinButton;

    void Awake()
    {
        hostButton.onClick.AddListener(() =>
        {

            NetworkManager.singleton.StartHost();
        });
        joinButton.onClick.AddListener(() =>
        {

            NetworkManager.singleton.StartClient();
        });
    }



}
