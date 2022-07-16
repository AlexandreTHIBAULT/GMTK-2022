using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSetup : MonoBehaviour
{

    public GridComponent grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = new GridComponent(7, 1f);

        
        Debug.Log(grid.GetWorldPosition(1,0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
