using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridComponent
{

    private int width;
    private float cellSize;
    private int[,] gridArray;
    
    public GridComponent(int width, float cellSize) {
        this.width = width;
        this.cellSize = cellSize;

        gridArray = new int[width,width];

        Debug.Log("grid setup");
    }

    public Vector3 GetWorldPosition(int x, int z) {
        return new  Vector3(x, 0.5f, z) * cellSize;
    }
}
