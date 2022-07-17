using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waves : MonoBehaviour
{
    private int nbEnnemyPerWave = 2;
    
    public GameObject fireEnnemy;
    public GameObject waterEnnemy;
    public GameObject plantEnnemy;
    public Sprite fireSprite;
    public Sprite waterSprite;
    public Sprite plantSprite;

    public List<int> newWave;
    public List<int> newWavePositionX;
    public List<int> newWavePositionZ;

    // Start is called before the first frame update
    void Start()
    {
        SetNextWave();

        NewWave(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewWave(int waveNb)
    {
        //print("edsrztg");
        for(int i=0;i<nbEnnemyPerWave;i++){
            //print("edsrztg2222");
            GameObject ennemy = new GameObject();
            if(newWave[i]==0) ennemy=Instantiate(fireEnnemy, new Vector3(0, 0, 0), Quaternion.identity);
            else if(newWave[i]==1) ennemy=Instantiate(waterEnnemy, new Vector3(0, 0, 0), Quaternion.identity);
            else if(newWave[i]==2) ennemy=Instantiate(plantEnnemy, new Vector3(0, 0, 0), Quaternion.identity);

            ennemy.GetComponent<Enemies>().SetPosition();
        }

        
        if(waveNb==0) nbEnnemyPerWave = 1;
        else if(waveNb==1) nbEnnemyPerWave = 2;
        else nbEnnemyPerWave = 3;

        SetNextWave();
    }

    private void SetNextWave() {
        newWave.Clear();
        for(int i=0;i<nbEnnemyPerWave;i++){
            newWave.Add(Random.Range(0,3));
            Debug.Log(newWave[i]);

            if(newWave[i]==0) GameObject.Find("Next"+i.ToString()).GetComponent<Image>().sprite = fireSprite;
            else if(newWave[i]==1) GameObject.Find("Next"+i.ToString()).GetComponent<Image>().sprite = waterSprite;
            else if(newWave[i]==2) GameObject.Find("Next"+i.ToString()).GetComponent<Image>().sprite = plantSprite;
            GameObject.Find("Next"+i.ToString()).GetComponent<Image>().enabled = true;
        }
        for(int i=nbEnnemyPerWave; i<3; i++){
            GameObject.Find("Next"+i.ToString()).GetComponent<Image>().enabled = false;
        }
        
        //GameObject.Find("Next0").GetComponent<Image>().sprite = fireSprite;
    }
}
