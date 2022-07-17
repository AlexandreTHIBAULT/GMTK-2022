using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using System.IO;
public class GameOver : MonoBehaviour
{
    [HideInInspector] public Clock score;

    private TextMeshProUGUI scoreT;
    
    public TextAsset best;
    private List<string> bestLines;
    private string completeFile;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        score = GameObject.Find("GameManager").GetComponent<Clock>();
        scoreT = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        scoreT.text = "Score : "+score.score.ToString();
    }

    public void ResetGame()
    {
        updateBest();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart");
        
    }

    private void updateBest()
    {
        print("update best");

        /*completeFile = best.text;

        bestLines = new List<string>();

        bestLines.AddRange(
            completeFile.Split("\n"[0]) );
       
        print(int.Parse(bestLines[0]));
        print(int.Parse(bestLines[1]));
    
        best.text = "1\n1";*/

        string path = "Assets/Datas/best.txt";

        StreamReader reader = new StreamReader(path); 
        completeFile = reader.ReadToEnd();
        bestLines = new List<string>();

        bestLines.AddRange(
            completeFile.Split("\n"[0]) );
       
        int bestScore = int.Parse(bestLines[0]);
        int bestWave = int.Parse(bestLines[1]);
        print(bestScore);
        print(bestWave);

        reader.Close();

        File.WriteAllText(path, string.Empty);

        StreamWriter writer = new StreamWriter(path, true);

        int scoreN = GameObject.Find("GameManager").GetComponent<Clock>().score;
        if(bestScore<scoreN) writer.WriteLine(scoreN.ToString());
        else writer.WriteLine(bestScore.ToString());
        
        int waveN = GameObject.Find("GameManager").GetComponent<Clock>().waveNb;
        if(bestScore<waveN) writer.WriteLine(waveN.ToString());
        else writer.WriteLine(bestWave.ToString());

        /*writer.WriteLine("1");
        writer.WriteLine("1");*/
        writer.Close();

        /*AssetDatabase.ImportAsset(path); 
        TextAsset asset = Resources.Load("best");

        //Print the text from the file
        Debug.Log(asset.text);*/
    }
}
