using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Launch : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        print("Connecting to server");
        //AuthenticationValues authValues = new AuthenticationValues("0");
        //PhotonNetwork.AuthValues = authValues;
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;       
        PhotonNetwork.ConnectUsingSettings();

    }
    public override void OnConnectedToMaster()
    {
        //MasterManager.DebugConsole.AddText("Connected to photon.", this);
        Debug.Log("connected to photon" , this);
        print(PhotonNetwork.LocalPlayer.NickName);
        //Debug.Log("My nickname is " + PhotonNetwork.LocalPlayer.NickName, this);
        if (!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Failed to connected photon" + cause.ToString(), this);

    }



    public override void OnJoinedLobby()
    {
        print("Joined lobby");
    }
}
