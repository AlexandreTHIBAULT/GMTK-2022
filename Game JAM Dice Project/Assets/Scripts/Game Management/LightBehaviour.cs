using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    float d;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        d = Random.Range(-1f,1f);
        x = (Random.Range(0, 1)*2)-1;
    }

    // Update is called once per frame
    void Update()
    {
        d += 0.01f;
        GetComponent<Light>().intensity = 4.5f + Mathf.Sin(x*d);
    }
}
