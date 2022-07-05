using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paint : MonoBehaviour
{
    public float colourR, colourG, colourB;
    private GlobalData globalData;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().color = new Color(colourR, colourG, colourB);
        globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalData>();
    }

    public void PickColour()
    {
        globalData.color = new Color(colourR, colourG, colourB);
    }
}
