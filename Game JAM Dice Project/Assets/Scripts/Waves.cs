using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waves : MonoBehaviour
{
    private int nbEnnemyPerWave = 3;

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

        NewWave();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewWave()
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
        }
        
        //GameObject.Find("Next0").GetComponent<Image>().sprite = fireSprite;
    }
}
