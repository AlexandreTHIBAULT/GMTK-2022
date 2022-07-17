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
        if (other.gameObject.tag == "Ennemy")
        {
            //playerDice.GetComponent<DiceController>().endangeredEnnemies.Clear();
            playerDice.GetComponent<DiceController>().endangeredEnnemies.Remove(other.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ennemy")
        {
            playerDice.GetComponent<DiceController>().endangeredEnnemies.Add(other.gameObject);
        }
    }

}
