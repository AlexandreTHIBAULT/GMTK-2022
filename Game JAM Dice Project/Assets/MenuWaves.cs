using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEditor;
public class MenuWaves : MonoBehaviour
{
    public TextAsset best;
    private List<string> bestLines;
    private string completeFile;
    // Start is called before the first frame update
    void Start()
    {
        


        string path = "Assets/Datas/best.txt";

        StreamReader reader = new StreamReader(path); 
        completeFile = reader.ReadToEnd();
        bestLines = new List<string>();

        bestLines.AddRange(
            completeFile.Split("\n"[0]) );
       
        //int bestWave = int.Parse(bestLines[1]);
        //print(bestWave);

        gameObject.GetComponent<TextMeshProUGUI>().text = "Best wave : "+bestLines[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
