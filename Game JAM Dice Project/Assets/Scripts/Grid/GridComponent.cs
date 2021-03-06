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

    }

    public Vector3 GetWorldPosition(int x, int z) {
        return new  Vector3(x + 0.5f, 0.5f, z + 0.5f) * cellSize;
    }

    public Vector3 GetGridPosition(float x, float z) {
        return GetWorldPosition(Mathf.FloorToInt(x/cellSize), Mathf.FloorToInt(z/cellSize));
    }
}
