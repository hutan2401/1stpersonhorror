using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Light light0;

    public float minTime;
    public float maxTime;
    public float timer;

    private void Start()
    {
        timer = Random.Range(minTime, maxTime);
    }


    private void Update()
    {
        LightFlickering();
    }

    void LightFlickering()
    {
        if(timer > 0) 
            timer -= Time.deltaTime;

        if(timer <= 0)
        {
            light0.enabled = !light0.enabled;
            timer = Random .Range(minTime, maxTime);
            
        }
        
    }
}
