using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceController : MonoBehaviour
{
    [SerializeField] private float rollSpeed = 3;
    private bool isMoving;
    [HideInInspector] public Clock clock;
    private GridComponent grid;
    public DiceColorDetector diceColorDetector;

    private void Start()
    {
        clock = GameObject.Find("GameManager").GetComponent<Clock>();
        diceColorDetector = gameObject.GetComponent<DiceColorDetector>();
        grid = new GridComponent(7, 1f);
        transform.position = grid.GetWorldPosition(3,3);
    }
    // Update is called once per frame
    void Update()
    {
        if (isMoving) return;

        //Mouse Movement
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer ("Plane")) {
                    //Debug.Log(hit.point.z);
                    Vector3 hitClickGridPos =  grid.GetGridPosition(hit.point.x, hit.point.z);
                    Vector3 diceGridPos = grid.GetGridPosition(transform.position.x, transform.position.z);
                    
                    if (hitClickGridPos.x < diceGridPos.x && hitClickGridPos.z==diceGridPos.z) {
                        Assemble(Vector3.left);
                    } else if (hitClickGridPos.x > diceGridPos.x && hitClickGridPos.z==diceGridPos.z) {
                        Assemble(Vector3.right);
                    } else if (hitClickGridPos.z < diceGridPos.z && hitClickGridPos.x==diceGridPos.x) {
                        Assemble(Vector3.back);
                    } else if (hitClickGridPos.z > diceGridPos.z && hitClickGridPos.x==diceGridPos.x) {
                        Assemble(Vector3.forward);
                    }

                    //transform.position = grid.GetGridPosition(hit.point.x, hit.point.z);
                }
                
            }
        }

        //Key Movement
        if (Input.GetKeyDown(KeyCode.Z)) Assemble(Vector3.forward);
        if (Input.GetKeyDown(KeyCode.Q)) Assemble(Vector3.left);
        if (Input.GetKeyDown(KeyCode.S)) Assemble(Vector3.back);
        if (Input.GetKeyDown(KeyCode.D)) Assemble(Vector3.right);

        void Assemble(Vector3 dir)
        {
            var anchor = transform.position + (Vector3.down + dir)  * 0.5f;
            var axis = Vector3.Cross(Vector3.up, dir);
            StartCoroutine(Roll(anchor, axis));
            
        }

        
    }

    IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        isMoving = true;
        clock.UpdateClock();

        for (int i = 0; i < (90 / rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
            diceColorDetector.updateColor();
        }

        isMoving = false;
    }

}
