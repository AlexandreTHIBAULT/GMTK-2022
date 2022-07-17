using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private float rollSpeed = 3;

    public ColorEnum color;
    [HideInInspector] public Clock clock;
    //public GridComponent grid;
    //public DiceColorDetector diceColorDetector;
    private GameObject dice;
    // Start is called before the first frame update

    public Vector3 feelDirection;

    private GameObject directionSquare;

    private Canvas gameOverCanvas;

    private  GridComponent grid;

    void Start()
    {
        dice = GameObject.Find("PlayerDice");
        clock = GameObject.Find("GameManager").GetComponent<Clock>();

        grid = dice.GetComponent<DiceController>().grid;

        //Position
        

        directionSquare = transform.GetChild(1).gameObject;

        directionSquare.transform.parent = transform.parent;

        gameOverCanvas = GameObject.Find("CanvasGameOver").GetComponent<Canvas>();

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void SetPosition(){
        dice = GameObject.Find("PlayerDice");
        grid = GameObject.Find("PlayerDice").GetComponent<DiceController>().grid;
        GameObject[] ennemies;
        ennemies = GameObject.FindGameObjectsWithTag("Ennemy");
        //Debug.Log(ennemies[0]);

        bool valPosition = false;
        int x = Random.Range(0, 7);
        int z = Random.Range(0, 7);

        while (!valPosition){
            //print("test----");
            valPosition = true;
            x = Random.Range(0, 7);
            z = Random.Range(0, 7);
            //print(x);
            //print(z);
            foreach(GameObject ennemy in ennemies) {
                Vector3 ennemyGridPosition = grid.GetGridPosition(ennemy.transform.position.x, ennemy.transform.position.z);
                Vector3 selfGridPosition = grid.GetGridPosition(x, z);
                Vector3 diceGridPosition = grid.GetGridPosition(dice.transform.position.x, dice.transform.position.z);
                //print(ennemyGridPosition);
                if(ennemy!=gameObject && 
                    (ennemyGridPosition==selfGridPosition ||
                    diceGridPosition==selfGridPosition) ) valPosition = false;
            }
            
            //print("----");
        }
        
        transform.position = grid.GetWorldPosition(x, z);
    }


    IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {

        for (int i = 0; i < (90 / rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
            //diceColorDetector.updateColor();
        }

        //transform.position += feelDirection;
    }

    public void Move()
    {

        Vector3 dir = feelDirection;

        Vector3 target = transform.position + feelDirection;
        Vector3 diceGridPos = dice.GetComponent<DiceController>().grid.GetGridPosition(dice.transform.position.x, dice.transform.position.z);

        if (target == diceGridPos){
            Debug.Log("Game Over");
            GameObject.Find("Main Camera").GetComponent<ShakeCamera>().start = true;
            StartCoroutine(KillPlayer());
            
        }

        var anchor = transform.position + (Vector3.down + dir)  * 0.5f;
        var axis = Vector3.Cross(Vector3.up, dir);
        StartCoroutine(Roll(anchor, axis));

    }

    public void showDirection()
    {
        directionSquare.transform.position = transform.position + feelDirection - new Vector3(0, 0.5f, 0);
        directionSquare.GetComponent<MeshRenderer>().enabled = true;
    }

    public void Death(){
        Destroy(directionSquare);
        Destroy(gameObject);
    }
    IEnumerator KillPlayer()
    {
        Destroy(dice);
        yield return new WaitForSeconds(1);
        gameOverCanvas.enabled = true;
        gameOverCanvas.GetComponent<GameOver>().UpdateScore();
    }

}
