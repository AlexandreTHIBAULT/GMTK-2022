using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceController : MonoBehaviour
{
    [SerializeField] private float rollSpeed = 3;
    private bool isMoving;
    [HideInInspector] public Clock clock;
    public GridComponent grid;
    public DiceColorDetector diceColorDetector;

    //composants d'attaque
    [HideInInspector] public List<GameObject> endangeredEnnemies;

    public Vector3[] ennemyGoal;

    public bool updateEnnemies;

    private void Start()
    {
        clock = GameObject.Find("GameManager").GetComponent<Clock>();
        diceColorDetector = gameObject.GetComponent<DiceColorDetector>();
        grid = new GridComponent(7, 1f);
        transform.position = grid.GetWorldPosition(3,3);

        ennemyGoal = new Vector3[3];
        updateEnnemies = true;
        //UpdateEnnemiesFeel();
    }
    // Update is called once per frame
    void Update()
    {
        if (isMoving) return;
        if(updateEnnemies){
            UpdateEnnemiesFeel();
            updateEnnemies = false;
        }
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

                    GameObject[] ennemies;
                    ennemies = GameObject.FindGameObjectsWithTag("Ennemy");
                 
                    if (hitClickGridPos.x < diceGridPos.x && hitClickGridPos.z==diceGridPos.z) {
                        //Check if ennemy in the case
                        bool possible = true;
                        foreach(GameObject ennemy in ennemies) {
                            Vector3 ennemyGridPosition = grid.GetGridPosition(ennemy.transform.position.x, ennemy.transform.position.z);
                            possible = possible && (ennemyGridPosition!=diceGridPos+Vector3.left);
                        }
                        if(possible) Assemble(Vector3.left);
                    } else if (hitClickGridPos.x > diceGridPos.x && hitClickGridPos.z==diceGridPos.z) {
                        bool possible = true;
                        foreach(GameObject ennemy in ennemies) {
                            Vector3 ennemyGridPosition = grid.GetGridPosition(ennemy.transform.position.x, ennemy.transform.position.z);
                            possible = possible && (ennemyGridPosition!=diceGridPos+Vector3.right);
                        }
                        if(possible) Assemble(Vector3.right);
                    } else if (hitClickGridPos.z < diceGridPos.z && hitClickGridPos.x==diceGridPos.x) {
                        bool possible = true;
                        foreach(GameObject ennemy in ennemies) {
                            Vector3 ennemyGridPosition = grid.GetGridPosition(ennemy.transform.position.x, ennemy.transform.position.z);
                            possible = possible && (ennemyGridPosition!=diceGridPos+Vector3.back);
                        }
                        if(possible) Assemble(Vector3.back);
                    } else if (hitClickGridPos.z > diceGridPos.z && hitClickGridPos.x==diceGridPos.x) {
                        bool possible = true;
                        foreach(GameObject ennemy in ennemies) {
                            Vector3 ennemyGridPosition = grid.GetGridPosition(ennemy.transform.position.x, ennemy.transform.position.z);
                            possible = possible && (ennemyGridPosition!=diceGridPos+Vector3.forward);
                        }
                        if(possible) Assemble(Vector3.forward);
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
            
            GameObject[] ennemies;
            ennemies = GameObject.FindGameObjectsWithTag("Ennemy");
            foreach(GameObject ennemy in ennemies) {
                ennemy.GetComponent<Enemies>().Move();
            }
            updateEnnemies = true;
        }

        void Attack(ColorEnum colorAttack)
        {
            foreach(GameObject ennemy in endangeredEnnemies)
            {
                Destroy(ennemy);
            }
        }

        
    }

    void UpdateEnnemiesFeel() {
        //Ennemies directionf
        GameObject[] ennemies;
        ennemies = GameObject.FindGameObjectsWithTag("Ennemy");

        foreach(GameObject ennemy in ennemies) {
            if( Mathf.Abs(transform.position.x - ennemy.transform.position.x) < Mathf.Abs(transform.position.z - ennemy.transform.position.z)){
                if(transform.position.z < ennemy.transform.position.z) {
                    ennemy.GetComponent<Enemies>().feelDirection = new Vector3(0, 0, -1);
                }
                else {
                    ennemy.GetComponent<Enemies>().feelDirection = new Vector3(0, 0, 1);
                }
                
            }
            else if( Mathf.Abs(transform.position.x - ennemy.transform.position.x) > Mathf.Abs(transform.position.z - ennemy.transform.position.z)){
                if(transform.position.x < ennemy.transform.position.x) {
                    ennemy.GetComponent<Enemies>().feelDirection = new Vector3(-1, 0, 0);
                }
                else {
                    ennemy.GetComponent<Enemies>().feelDirection = new Vector3(1, 0, 0);
                }
                
            } else if (Random.Range(0, 1)==1){
                if(transform.position.z < ennemy.transform.position.z) {
                    ennemy.GetComponent<Enemies>().feelDirection = new Vector3(0, 0, -1);
                }
                else {
                    ennemy.GetComponent<Enemies>().feelDirection = new Vector3(0, 0, 1);
                }
            } else {
                if(transform.position.x < ennemy.transform.position.x) {
                    ennemy.GetComponent<Enemies>().feelDirection = new Vector3(-1, 0, 0);
                }
                else {
                    ennemy.GetComponent<Enemies>().feelDirection = new Vector3(1, 0, 0);
                }
            }

            
        }

        foreach(GameObject ennemy in ennemies) {
            Vector3 ennemyGridPosition = grid.GetGridPosition(ennemy.transform.position.x, ennemy.transform.position.z);
            //Debug.Log("------E------------");
            //Debug.Log(ennemyGridPosition);
            foreach(GameObject ennemyB in ennemies){
                Vector3 ennemyBGridPosition = grid.GetGridPosition(ennemyB.transform.position.x, ennemyB.transform.position.z);

                if(ennemyB != ennemy && (
                    (ennemyGridPosition+ennemy.GetComponent<Enemies>().feelDirection)==(ennemyBGridPosition+ennemyB.GetComponent<Enemies>().feelDirection) ||
                    (ennemyGridPosition+ennemy.GetComponent<Enemies>().feelDirection)==(ennemyBGridPosition) ||
                    ( (ennemyGridPosition+ennemy.GetComponent<Enemies>().feelDirection).x>7) ||
                    ( (ennemyGridPosition+ennemy.GetComponent<Enemies>().feelDirection).x<0) ||
                    ( (ennemyGridPosition+ennemy.GetComponent<Enemies>().feelDirection).y>7) ||
                    ( (ennemyGridPosition+ennemy.GetComponent<Enemies>().feelDirection).y<0) )
                    )
                        {
                            ennemy.GetComponent<Enemies>().feelDirection = new Vector3(0, 0, 0);
                        
                }
            }
            
            //Debug.Log(ennemy.GetComponent<Enemies>().feelDirection);
            //Debug.Log("------EF-----------");
            ennemy.GetComponent<Enemies>().showDirection();
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
