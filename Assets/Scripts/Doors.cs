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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inReach = true;
            openText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
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
        else if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            DoorCloses();
        }
        
    }

    void DoorOpens()
    {
        door.SetBool("open", true);
        door.SetBool("closed", false);
        doorSound.Play();
    }
    void DoorCloses()
    {
        door.SetBool("open", false);
        door.SetBool("closed", true);
        doorSound.Play();
    }
   
}
