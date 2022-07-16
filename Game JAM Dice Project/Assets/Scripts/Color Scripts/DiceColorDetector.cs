using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceColorDetector : MonoBehaviour
{
    public GameObject playerDice;
    public List<GameObject> faces;
    public ColorEnum currentColor;

    // Start is called before the first frame update
    void Start()
    {
        playerDice = GameObject.FindGameObjectWithTag("playerDice");

        foreach (Transform child in playerDice.transform)
        {
            faces.Add(child.gameObject);
        }

        if (playerDice.name == "NeighboorColourDice")
        {
            //faces[0].GetComponent = 
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateColor()
    {
        foreach (GameObject face in faces)
        {
            if (face.GetComponent<FaceScript>().detection) 
            {
                //Debug.Log("coucou");
                currentColor = face.GetComponent<FaceScript>().color;
            }
                
        }
    }
    
}
