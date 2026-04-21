using Mirror;



public class PlayerSendMessage : NetworkBehaviour
{
    ChatBubble chatBubble;
    void OnEnable()
    {
        GamePlayUI.message += SendMsg;
    }
    void OnDisable()
    {
        GamePlayUI.message -= SendMsg;
    }
    void Start()
    {
        chatBubble = GetComponentInChildren<ChatBubble>();
    }
    public void SendMsg(string words)
    {
        if (!isLocalPlayer) return;
        CmdSendMsg(words);
    }

    [Command]
    void CmdSendMsg(string words)
    {
        RpcReceiveMsg(words);
    }
    [ClientRpc]
    void RpcReceiveMsg(string words)
    {
        
        chatBubble.ShowMessage(words);
    }
}
