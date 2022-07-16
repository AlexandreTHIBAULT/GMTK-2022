using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceController : MonoBehaviour
{
    [SerializeField] private float rollSpeed = 3;
    private bool isMoving;
    [HideInInspector] public Clock clock;
    private void Start()
    {
        clock = GameObject.Find("GameManager").GetComponent<Clock>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isMoving) return;

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
        }

        isMoving = false;
    }

}
