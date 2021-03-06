using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkInstantier : MonoBehaviourPunCallbacks
{
    public PhotonView pw;
    private void Start()
    {
        StartGame();
    }


    public Transform[] spawnPoints;

    void StartGame()
    {

        Player[] players = PhotonNetwork.PlayerList;
        for (int i = 0; i < players.Length; i++)
        {
            if (pw.IsMine==true)
                photonView.RPC("RPCStartGame", players[i], spawnPoints[i].position, spawnPoints[i].rotation);
        }
    }

    [PunRPC]
    void RPCStartGame(Vector3 spawnPos,Quaternion spawnRot)
    {
        PhotonNetwork.Instantiate("Player",spawnPos,spawnRot,0);
    }

}
