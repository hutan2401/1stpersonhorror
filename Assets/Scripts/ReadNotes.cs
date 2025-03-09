using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadNotes : MonoBehaviour
{
    public GameObject player;
    public GameObject noteUI;
    
    public GameObject inv;

    public GameObject pickUpText;

    public AudioSource pickUpSound;

    public bool inReach;

    void Start()
    {
        noteUI.SetActive(false);
        
        inv.SetActive(true);
        pickUpText.SetActive(false);

        inReach = false;
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inReach = true;
            pickUpText.SetActive(true);
        }
    }

     void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }

     void Update()
    {
        
            if(Input.GetKeyDown(KeyCode.R) && inReach)
        {
            noteUI.SetActive(true);
            pickUpSound.Play();

            inv.SetActive(false);
            //player.GetComponent<MovementController>().enabled = false;
            player.GetComponent<CameraController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }

    }

    public void ExitButton()
    {
        
        
            noteUI.SetActive(false);

            inv.SetActive(false);
            //player.GetComponent<MovementController>().enabled = true;
            player.GetComponent<CameraController>().enabled = true;
        
        
    }
}
