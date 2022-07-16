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

        transform.position = grid.GetWorldPosition(3,3);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer ("Plane")) {
                    Debug.Log(hit.point.z);
                    Debug.Log(grid.GetGridPosition(hit.point.x, hit.point.z));
                    transform.position = grid.GetGridPosition(hit.point.x, hit.point.z);
                }
                
            }
        }
    }
}
