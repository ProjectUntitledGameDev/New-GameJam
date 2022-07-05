using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public List<GameObject> cellObjList;
    public List<GameObject> topCells;
    public List<GameObject> botCells;
    private GridConstruct grid;
    public Sprite cell;
    public int gridWidth;
    public int gridHeight;
    public float cellSize;
    // Start is called before the first frame update
    void Awake()
    {
        grid = new GridConstruct(gridWidth, gridHeight, cellSize);
        //new x = x + height; (To move it over you just +/- the height from the current index. 2nd pos in row 1 + height will equal the 2nd pos in 2nd row.)
        for (int i = 0; i < gridWidth; i++)
        {
            topCells.Add(cellObjList[((i + 1) * gridHeight) - 1]);
            cellObjList[((i + 1) * gridHeight) - 1].GetComponent<Cell>().index = (i + 1) * gridHeight;
        }
        for (int i = 0; i < gridWidth; i++)
        {
            botCells.Add(cellObjList[(i * gridHeight)]);
            botCells[i].GetComponent<Cell>().botRow = true;
        }

    }
}
