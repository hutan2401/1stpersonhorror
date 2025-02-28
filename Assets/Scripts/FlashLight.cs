using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject flashLight;

    public AudioSource turnOn;
    public AudioSource turnOff;

    public bool on;
    public bool off;

    private void Start()
    {
        off = true;
        flashLight.SetActive(false);
    }

    private void Update()
    {
        if (off && Input.GetButtonDown("F"))
        {
            flashLight.SetActive(true);
            turnOn.Play();
            off = false;
            on = true;
        }
        else if (on && Input.GetButtonDown("F"))
        {
            flashLight.SetActive(false);
            turnOff.Play();
            off = true;
            on = false;
        }
    }
}
