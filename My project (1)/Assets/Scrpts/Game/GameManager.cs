using System;
using System.Linq;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class GameManager : NetworkBehaviour
    {
        public GameObject Cube;
        public void Start()
        {
            if (isServer)
            {
                
            }
        }

        public void Update()
        {
            if (isServer)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    CmdCreateBall();
                }
            }
        }

        [Command]
        public void CmdCreateBall()
        {
            var player = RandomPlayer();
            var go = GameObject.Instantiate(Cube, player.identity.gameObject.transform);
            NetworkServer.Spawn(go);
        }

        [ClientRpc]
        public void RpcCreate()
        {
            
        }
        
        public NetworkConnectionToClient RandomPlayer()
        {
            int randomIndex = Random.Range(0, NetworkManager.singleton.numPlayers);
            var player = NetworkServer.connections.Values.ToList();

            return player[randomIndex];
        }
    }
}