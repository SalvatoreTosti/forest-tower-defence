using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfiller : MonoBehaviour
{

    public GameObject emptyTile;
    public Vector3 gridStart;
    public int gridWidth = 3;
    public int gridHeight = 3;

    void Start()
    {
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                Vector3 position = new Vector3(i, j, 0);
            }
        }
    }
}
