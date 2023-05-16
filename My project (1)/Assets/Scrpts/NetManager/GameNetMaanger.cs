using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class GameNetMaanger : NetworkManager
{
   public override void OnStartServer()
   {
      Debug.Log("Server Started!");
   }

   public override void OnStopServer()
   {
      Debug.Log("Server Stopped!");
   }

   public override void OnServerAddPlayer(NetworkConnectionToClient conn)
   {
      base.OnServerAddPlayer(conn);
   }
   
   public void FixedUpdate()
   {
      if (Input.GetKeyDown(KeyCode.C))
      {
         
      }
   }

   public void RandomPlayer()
   {
      
   }
}
