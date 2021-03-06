using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomName;

    private RoomsCanvases _roomsCanvases;
    public void FirstInitialized(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }

    public void OnClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }
        RoomOptions options = new RoomOptions();
        options.BroadcastPropsChangeToAll = true;
        options.PublishUserId = true;
        options.MaxPlayers = 5;
        if(_roomName.text != "")
        {
            PhotonNetwork.JoinOrCreateRoom(_roomName.text, options, TypedLobby.Default);
        }
        else
        {
            PhotonNetwork.JoinOrCreateRoom(PhotonNetwork.NickName.Substring(0 , PhotonNetwork.NickName.Length-3) + "'s game", options, TypedLobby.Default);
        }

    }

    
    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room Succesfully.", this);
        Debug.Log(PhotonNetwork.CurrentRoom.Name, this);
        _roomsCanvases.CurrentRoomCanvas.Show();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room Creation Failed: "+ message, this);
    }
}
