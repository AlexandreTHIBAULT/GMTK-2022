using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackAreaDetection : MonoBehaviour
{
    public GameObject playerDice;
    // Start is called before the first frame update
    void Start()
    {
        playerDice = GameObject.Find("PlayerDice");
        Debug.Log(playerDice);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("out");
        if (other.gameObject.tag == "Ennemy")
        {
            playerDice.GetComponent<DiceController>().endangeredEnnemies.Clear();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        if (other.gameObject.tag == "Ennemy")
        {
            playerDice.GetComponent<DiceController>().endangeredEnnemies.Add(other.gameObject);
        }
    }

}
