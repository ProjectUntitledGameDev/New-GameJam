using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class CreateAndJoin : MonoBehaviourPunCallbacks
{
    public TMP_InputField createLobby, joinLobby;
    // Start is called before the first frame update

    public void CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 5;
        PhotonNetwork.CreateRoom(createLobby.text, options, TypedLobby.Default);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinLobby.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Room");
    }
}
