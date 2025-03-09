using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithLock : MonoBehaviour
{
    public Animator door;
    public GameObject openText;
    public GameObject KeyINV;

    public AudioSource doorSound;

    public bool inReach;
    public bool unlocked;
    public bool locked;
    public bool hasKey;

    void Start()
    {
        inReach = false;
        hasKey = false;
        unlocked = false;
        locked = true;
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
        if (KeyINV.activeInHierarchy)
        {
            locked = false;
            hasKey = true;
        }
        else
        {
            hasKey = false;
        }
        if (hasKey && inReach && Input.GetKeyDown(KeyCode.E))
        {
            unlocked = true;
            DoorOpen();
        }

        else
        {
            DoorClose();
        }

        if (locked && inReach && Input.GetKeyDown(KeyCode.E))
        {
            doorSound.Play();
        }
    }

    void DoorOpen()
    {
        if(unlocked)
        {
            door.SetBool("Open", false);
            door.SetBool("Closed", true);
            doorSound.Play();
        }
        
    }

    void DoorClose()
    {
        if (unlocked)
        {
            door.SetBool("Open", true);
            door.SetBool("Closed", false);
        }
    }
}
