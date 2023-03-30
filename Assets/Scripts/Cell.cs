using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public GridPosition gridPosition;

    void Awake()
    {
        gridPosition = new GridPosition(0, 0);
    }

    public void SetCoords(int x, int z)
    {
        gridPosition.x = x;
        gridPosition.z = z;
    }

    public GridPosition GetCoords()
    {
        return gridPosition;
    }


}
