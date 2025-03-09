using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public Animator door;
    public GameObject openText;

    public AudioSource doorSound;

    public bool inReach;

    void Start()
    {
        inReach = false;
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inReach = true;
            openText.SetActive(true);
        }
    }

     void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }

    void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            DoorOpens();
        }
        else
        {
            DoorCloses();
        }
        
    }

    void DoorOpens()
    {
        door.SetBool("Open", false);
        door.SetBool("Closed", true);
        doorSound.Play();
    }
    void DoorCloses()
    {
        door.SetBool("Open", true);
        door.SetBool("Closed", false);
        doorSound.Play();
    }
   
}
