using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public interface IPlayer
{
    void StatusUpdate();
}

[RequireComponent(typeof(NetworkTransform))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerMoveMent))]
public class PlayerCore : NetworkBehaviour
{

    public PlayerMoveMent moveMent;
    public PlayerLook playerLook;
    public List<IPlayer> PlayerCompoents = new List<IPlayer>();
    // Start is called before the first frame update
    void Start()
    {
        moveMent = this.GetComponent<PlayerMoveMent>();
    
        playerLook = this.transform.Find("PlayerCameraRoot/Camera").GetComponent<PlayerLook>();
        playerLook.gameObject.SetActive(isLocalPlayer);
        
        PlayerCompoents.Add(playerLook);
        PlayerCompoents.Add(moveMent);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) return;
        
        for (int i = 0; i < PlayerCompoents.Count; i++)
            PlayerCompoents[i].StatusUpdate();
    }

    /// <summary>
    /// 重生
    /// </summary>
    public void Reborn()
    {
        
    }
}
