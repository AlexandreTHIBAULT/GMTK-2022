using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private float rollSpeed = 3;

    public GameObject mainCamera;

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
        mainCamera = GameObject.Find("Main Camera");
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

            //Spawn sur les bords : 
            //
            var line = Random.Range(0, 4);
            var dist = Random.Range(0, 6);
            if(line==0){
                x = 0;
                z = dist;
            }
            else if(line==1){
                x = 6;
                z = 6-dist;
            }
            else if(line==2){
                z = 6;
                x = dist;
            }
            else {
                z = 0;
                x = 6-dist;
            }

            //x = Random.Range(0, 7);
            //z = Random.Range(0, 7);
            //print(x);
            //print(z);
            foreach(GameObject ennemy in ennemies) {
                Vector3 ennemyGridPosition = grid.GetGridPosition(ennemy.transform.position.x, ennemy.transform.position.z);
                Vector3 selfGridPosition = grid.GetGridPosition(x, z);
                Vector3 diceGridPosition = grid.GetGridPosition(dice.transform.position.x, dice.transform.position.z);
                //print(ennemyGridPosition);
                if(ennemy!=gameObject && 
                    (ennemyGridPosition==selfGridPosition ||
                    ennemyGridPosition+ennemy.GetComponent<Enemies>().feelDirection==selfGridPosition ||
                    diceGridPosition==selfGridPosition ||
                    (diceGridPosition.x==selfGridPosition.x && diceGridPosition.z==selfGridPosition.z-1) ||
                    (diceGridPosition.x==selfGridPosition.x && diceGridPosition.z==selfGridPosition.z+1) ||
                    (diceGridPosition.z==selfGridPosition.z && diceGridPosition.x==selfGridPosition.x-1) ||
                    (diceGridPosition.z==selfGridPosition.z && diceGridPosition.x==selfGridPosition.x+1) ) ) valPosition = false;
            }
            
            //print("----");
        }
        
        transform.position = grid.GetWorldPosition(x, z);
    }


    IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        mainCamera.GetComponent<SoundManager>().PlaySoundEnnemyRolling();
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
            mainCamera.GetComponent<ShakeCamera>().start = true;
            mainCamera.GetComponent<SoundManager>().playSoundGameOver();
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
