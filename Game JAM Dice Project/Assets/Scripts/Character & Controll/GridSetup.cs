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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
