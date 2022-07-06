using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using TMPro;
using Photon.Pun;

public class RoomInformation : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI text;

    public Player Player { get; private set; }
    void Start()
    {
        SetInfo(Player);
    }

    public void SetInfo(Player player)
    {
        Player = player;
        SetPlayerInfo(player);
    }
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        base.OnPlayerPropertiesUpdate(targetPlayer, changedProps);
        if(targetPlayer != null && targetPlayer == Player)
        {
            if (changedProps.ContainsKey("Name"))
            {
                SetPlayerInfo(targetPlayer);
            }
        }
    }
    private void SetPlayerInfo(Player player)
    {
        if (player.CustomProperties.ContainsKey("Name"))
        {
            string name = (string)player.CustomProperties["Name"];
        }

        text.text = name;
    }

}
