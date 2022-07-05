using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
public class CreateAndJoin : MonoBehaviourPunCallbacks
{
    public TMP_InputField createLobby, joinLobby;
    // Start is called before the first frame update

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createLobby.text);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinLobby.text);
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.LoadLevel("BenScene");
    }
}
