using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedDoors : MonoBehaviour
{
    public Animator door;
    public GameObject lockOB;
    public GameObject keyOB;
    public GameObject openText;
    public GameObject closeText;
    public GameObject lockedText;


    public AudioSource doorSound;

    private bool inReach;
    private bool doorisOpen;
    private bool doorisClosed;
    public bool locked;
    public bool unlocked;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && doorisClosed)
        {
            inReach = true;
            openText.SetActive(true);
        }

        if (other.gameObject.tag == "Player" && doorisOpen)
        {
            inReach = true;
            closeText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inReach = false;
            openText.SetActive(false);
            lockedText.SetActive(false);
            closeText.SetActive(false);
        }
    }

    private void Start()
    {
        inReach = false;
        doorisClosed = true;
        doorisOpen = false;
        closeText.SetActive(false );
        openText.SetActive(false ) ;
    }

    private void Update()
    {
        if (lockOB.activeInHierarchy)
        {
            locked = true;
            unlocked = false;
        }
        else
        {
            unlocked = true;
            locked = false;
        }

        if (inReach && keyOB.activeInHierarchy && Input.GetKeyDown(KeyCode.E))
        {
            locked = false;
            keyOB.SetActive(false );
            StartCoroutine(unlockDoor());
        }

        if (inReach && doorisClosed && unlocked && Input.GetKeyDown(KeyCode.E))
        {
            door.SetBool("Open", true);
            door.SetBool("Closed", false);
            openText.SetActive(false );
            doorisOpen =true;
            doorisClosed=false;
            doorSound.Play();
        }

        else if (inReach && doorisOpen && unlocked && Input.GetKeyDown(KeyCode.E))
        {
            door.SetBool("Open", false) ;
            door.SetBool("Closed", true) ;
            closeText.SetActive(false ) ;
            doorSound.Play() ;
            doorisClosed =true;
            doorisOpen=false;
        }

        if (inReach && locked && Input.GetKeyDown(KeyCode.E))
        {
            openText.SetActive(false ) ;
            lockedText.SetActive(true ) ;
            doorSound.Play();
        }
    }


    IEnumerator unlockDoor()
    {
        yield return new WaitForSeconds(0.5f);
        {
            unlocked = true;
            lockOB.SetActive(false);
        }
    }
}
