using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeypad : MonoBehaviour
{
    public GameObject keypadOB;
    public GameObject keypadText;

    public bool inReach;

    private void Start()
    {
        
        inReach = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inReach = true;
            keypadText.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inReach = false;
            keypadText.SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            keypadOB.SetActive(true);
        }
    }
}
