using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Cell cell in HexMap.Instance.GetCellList())
        {
            Debug.Log(cell.GetCoords().x + " , " + cell.GetCoords().z);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
