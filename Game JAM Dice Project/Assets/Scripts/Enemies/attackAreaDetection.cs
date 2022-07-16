using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackAreaDetection : MonoBehaviour
{
    public GameObject playerDice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ennemy")
        {
            playerDice.GetComponent<DiceController>().endangeredEnnemies.Add(other.gameObject);
        }
    }
}
