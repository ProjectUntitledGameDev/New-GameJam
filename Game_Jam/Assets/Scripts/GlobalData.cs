using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class GlobalData : MonoBehaviourPun
{
    public Color color;
    public Vector3 spawnPos;
    private void Awake()
    {
        spawnPos = Vector3.zero;
    }



    [PunRPC]
    public void ReadyUp(bool ready)
    {
        
    }

}
