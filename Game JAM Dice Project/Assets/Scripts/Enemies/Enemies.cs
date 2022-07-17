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

    public void SetPosition(int x, int z){
        dice = GameObject.Find("PlayerDice");             
        transform.position = dice.GetComponent<DiceController>().grid.GetWorldPosition(x, z);
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
            gameOverCanvas.enabled = true;
            gameOverCanvas.GetComponent<GameOver>().UpdateScore();
            Time.timeScale = 0;
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
}
