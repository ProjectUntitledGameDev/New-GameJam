using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class GridConstructor
{
    private int width;
    private int height;
    private int[,] gridArray;
    public GameObject[,] cellArray;
    private float cellSize;
    private Vector3 centrePoint;
    private int cells;
    public GridConstructor(int _width, int _height, float _cellSize)
    {
        cells = 0;
        this.width = _width;
        this.height = _height;
        this.cellSize = _cellSize;
        gridArray = new int[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                Debug.DrawLine(GetPos(x, y), GetPos(x, y + 1), Color.red, 10000f);
                Debug.DrawLine(GetPos(x, y), GetPos(x + 1, y), Color.red, 10000f);
                centrePoint = new Vector3(cellSize, cellSize) * .5f;
                CreateCellObj(null, GetPos(x, y) + new Vector3(cellSize, cellSize) * 0.5f, cells, x, y);
            }
        Debug.DrawLine(GetPos(0, height), GetPos(width, height), Color.red, 10000f);
        Debug.DrawLine(GetPos(width, 0), GetPos(width, height), Color.red, 10000f);
    }

    private Vector3 GetPos(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }
    public static GameObject CreateCellObj(Transform parent, Vector3 localPos, int cells, int x, int y)
    {
        GameObject gameObject = new GameObject("CellObj", typeof(SpriteRenderer), typeof(Cell));
        gameObject.GetComponent<Cell>().index = cells;
        cells++;
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPos;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
        gameObject.GetComponent<Cell>().x = x;
        gameObject.GetComponent<Cell>().y = y;
        return gameObject;
    }

}