using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceController : MonoBehaviour
{
    private Vector3 rotation;
    [SerializeField] private float speed;

    private bool isMoving;

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            var anchor = transform.position + new Vector3(-1, -1, 0);
            var axis = Vector3.Cross(Vector3.up, Vector3.left);
        }
    }

    //IEnumerator Roll(Vector3 anchor, Vector3 axis)
    //{
    //    isMoving = true;

    //    for (int i = 0; i < )
    //}

}
