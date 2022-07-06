using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class RoomListItem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    public RoomInfo RoomInfo { get; private set; }
    public void SetInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        text.text = roomInfo.MaxPlayers + " ," + roomInfo.Name;
    }
   
}
