using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    private GlobalData gd;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 temp = new Vector3((PhotonNetwork.CountOfPlayers - 1) * 300, 0, 0);
        PhotonNetwork.Instantiate(playerPrefab.name, temp, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
