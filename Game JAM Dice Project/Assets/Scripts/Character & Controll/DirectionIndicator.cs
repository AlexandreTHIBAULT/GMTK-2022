using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionIndicator : MonoBehaviour
{

    private RaycastHit hit;
    private GameObject dice;

    // Start is called before the first frame update
    void Start()
    {
        dice = GameObject.Find("PlayerDice");
        //diceGrid = dice.GetComponent<DiceController>().grid;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer ("Plane")) {
                //Debug.Log(hit.point.z);
                Vector3 hitClickGridPos =  dice.GetComponent<DiceController>().grid.GetGridPosition(hit.point.x, hit.point.z);
                Vector3 diceGridPos = dice.GetComponent<DiceController>().grid.GetGridPosition(dice.transform.position.x, dice.transform.position.z);
                //Debug.Log(diceGridPos);
                
                if (hitClickGridPos.x < diceGridPos.x && hitClickGridPos.z==diceGridPos.z) {
                    transform.position = diceGridPos + new Vector3(-1,-0.5f,0);
                    GetComponent<MeshRenderer>().enabled = true;
                }
                else if (hitClickGridPos.x > diceGridPos.x && hitClickGridPos.z==diceGridPos.z) {
                    transform.position = diceGridPos + new Vector3(1,-0.5f,0);
                    GetComponent<MeshRenderer>().enabled = true;
                }
                else if (hitClickGridPos.z < diceGridPos.z && hitClickGridPos.x==diceGridPos.x) {
                    transform.position = diceGridPos + new Vector3(0,-0.5f,-1);
                    GetComponent<MeshRenderer>().enabled = true;
                }
                else if (hitClickGridPos.z > diceGridPos.z && hitClickGridPos.x==diceGridPos.x) {
                    transform.position = diceGridPos + new Vector3(0,-0.5f,1);
                    GetComponent<MeshRenderer>().enabled = true;
                }
                else GetComponent<MeshRenderer>().enabled = false;

                //transform.position = grid.GetGridPosition(hit.point.x, hit.point.z);
            }
            else GetComponent<MeshRenderer>().enabled = false;   
        } else GetComponent<MeshRenderer>().enabled = false;
    }
}
