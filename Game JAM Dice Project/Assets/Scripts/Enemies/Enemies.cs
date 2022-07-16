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

    void Start()
    {
        dice = GameObject.Find("PlayerDice");
        clock = GameObject.Find("GameManager").GetComponent<Clock>();
        //Pour tester
        transform.position = dice.GetComponent<DiceController>().grid.GetWorldPosition(1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        

        

    }

    IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        clock.UpdateClock();

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

        var anchor = transform.position + (Vector3.down + dir)  * 0.5f;
        var axis = Vector3.Cross(Vector3.up, dir);
        StartCoroutine(Roll(anchor, axis));

    }

    public void showDirection()
    {
        directionSquare.transform.position = transform.position + feelDirection - new Vector3(0, 0.5f, 0);
        directionSquare.GetComponent<MeshRenderer>().enabled = true;
    }
}
