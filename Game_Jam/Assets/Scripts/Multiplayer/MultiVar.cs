using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiVar : MonoBehaviour
{
    private ExitGames.Client.Photon.Hashtable myProperties = new ExitGames.Client.Photon.Hashtable();
    // Start is called before the first frame update
    public void SetName(string name)
    {
        myProperties["Name"] = name;
        PhotonNetwork.SetPlayerCustomProperties(myProperties);
    }
}
