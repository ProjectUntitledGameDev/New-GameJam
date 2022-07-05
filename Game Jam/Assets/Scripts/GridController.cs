using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public List<GameObject> cellObjList;
    private GameObject[,] cellArray;
    private GridConstructor grid;
    private GlobalData gd;
    public Sprite cell;
    public int gridWidth;
    public int gridHeight;
    public float cellSize;

    void Awake()
    {
        cellArray = new GameObject[gridWidth, gridHeight];
        gd = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalData>();
        grid = new GridConstructor(gridWidth, gridHeight, cellSize);
    }
    private void Start()
    {
        for (int i = 0; i <= (cellObjList.Count - 1); i++)
        {
            cellArray[cellObjList[i].GetComponent<Cell>().x, cellObjList[i].GetComponent<Cell>().y] = cellObjList[i];
        }
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartUpdateColour(GetMouseWorldPos(), gd.color);
        }
    }

    public static Vector3 GetMouseWorldPos()
    {
        Vector3 v3 = GetMouseWorldPosWithZ(Input.mousePosition, Camera.main);
        v3.z = 0f;
        return v3;
    }
    public static Vector3 GetMouseWorldPosWithZ(Vector3 screenPos, Camera mainCam)
    {
        Vector3 worldPos = mainCam.ScreenToWorldPoint(screenPos);
        return worldPos;
    }


    private void GetXY(Vector3 worldPos, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPos.x / cellSize);
        y = Mathf.FloorToInt(worldPos.y / cellSize);
    }

    public void StartUpdateColour(Vector3 worldPos, Color colour)
    {
        int x, y;
        GetXY(worldPos, out x, out y);
        UpdateColour(x, y, colour);
    }
    public void UpdateColour(int x, int y, Color colour)
    {
        if (x >= 0 && y >= 0 && x < gridWidth && y < gridHeight)
        {
            cellArray[x, y].GetComponent<SpriteRenderer>().color = colour;
            cellArray[x, y].GetComponent<Cell>().SaveColour();
        }
    }

    public void Restart()
    {
        for (int i = 0; i <= (cellObjList.Count - 1); i++)
        {
            cellObjList[i].GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void SaveImage()
    {
        for (int i = 0; i <= (cellObjList.Count - 1); i++)
        {
            PlayerPrefs.SetFloat("rCell" + i, cellObjList[i].GetComponent<SpriteRenderer>().color.r);
            PlayerPrefs.SetFloat("gCell" + i, cellObjList[i].GetComponent<SpriteRenderer>().color.g);
            PlayerPrefs.SetFloat("bCell" + i, cellObjList[i].GetComponent<SpriteRenderer>().color.b);
        }
    }
    public void LoadImage()
    {
        for (int i = 0; i <= (cellObjList.Count - 1); i++)
        {
            Color temp = new Color(PlayerPrefs.GetFloat("rCell" + i), PlayerPrefs.GetFloat("gCell" + i),PlayerPrefs.GetFloat("bCell" + i));
            cellObjList[i].GetComponent<SpriteRenderer>().color = temp;
        }
    }
}
