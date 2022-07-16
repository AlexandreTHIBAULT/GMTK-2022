using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GridComponent grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = new GridComponent(7, 1f);
        Debug.Log(grid.GetWorldPosition(0, 0));

        transform.position = grid.GetWorldPosition(3,4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
