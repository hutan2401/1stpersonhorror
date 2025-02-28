using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject onOB;
    public GameObject offOB;

    public GameObject lightText;

    public GameObject lightOB;
    public GameObject lightOB2;

    public AudioSource switchClick;

    public bool lightAreOn;
    public bool lightAreOff;
    public bool inReach;

    void Start()
    {
        inReach = false;
        lightAreOn = false;
        lightAreOff = true;
        onOB.SetActive(false);
        offOB.SetActive(true);
        lightOB.SetActive(false);
        lightOB2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inReach = true;
            lightText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inReach = false;
            lightText.SetActive(false);
        }
    }

    void Update()
    {
        if(lightAreOn && inReach && Input.GetKeyDown(KeyCode.E))
        {
            lightOB.SetActive(false);
            lightOB2.SetActive(false);
            onOB.SetActive(false);
            offOB.SetActive(true);
            switchClick.Play();
            lightAreOff = true;
            lightAreOn = false;
        }

        else if (lightAreOff && inReach && Input.GetKeyDown(KeyCode.E))
        {
            lightOB.SetActive(true);
            lightOB2.SetActive(true);
            onOB.SetActive(true);
            offOB.SetActive(false);
            switchClick.Play();
            lightAreOff = false;
            lightAreOn = true;
        }
    }
}
