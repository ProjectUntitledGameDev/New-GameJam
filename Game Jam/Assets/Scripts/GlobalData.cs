using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GlobalData : MonoBehaviour
{
    public Color color;
    public Vector3 spawnPos;
    private void Awake()
    {
        spawnPos = Vector3.zero;
    }
}
