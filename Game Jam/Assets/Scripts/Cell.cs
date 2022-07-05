using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private GridController gridController;
    public bool occupied;
    public int index;
    public bool botRow;
    // Start is called before the first frame update
    void Awake()
    {
        gridController = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GridController>();
        gridController.cellObjList.Add(this.gameObject);
        this.GetComponent<SpriteRenderer>().sprite = gridController.cell;
    }
}