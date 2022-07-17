using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    public GameObject combo;
    public GameObject x2;
    public GameObject x3;
    public GameObject x4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void showCombo(int i)
    {
        StartCoroutine(comboShow(i));
    }

    IEnumerator comboShow(float i)
    {
        if (i>1) combo.SetActive(true);
        if (i == 2)
        {
            x2.SetActive(true);
           
        }
        else if (i == 3)
        {
            x3.SetActive(true);
        }
        else if (i == 4)
        {
            x4.SetActive(true);
        }

        yield return new WaitForSeconds(i/2);
        combo.SetActive(false);
        x2.SetActive(false);
        x3.SetActive(false);
        x4.SetActive(false);
    }
}
