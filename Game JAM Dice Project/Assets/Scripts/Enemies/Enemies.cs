using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private float rollSpeed = 3;
    [HideInInspector] public Clock clock;
    public GridComponent grid;
    public DiceColorDetector diceColorDetector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        void Assemble(Vector3 dir)
        {
            var anchor = transform.position + (Vector3.down + dir)  * 0.5f;
            var axis = Vector3.Cross(Vector3.up, dir);
            StartCoroutine(Roll(anchor, axis));
            
        }

    }

    IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        clock.UpdateClock();

        for (int i = 0; i < (90 / rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
            diceColorDetector.updateColor();
        }

        
    }
}
