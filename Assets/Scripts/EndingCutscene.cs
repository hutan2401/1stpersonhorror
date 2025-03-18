using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCutscene : MonoBehaviour
{
    public GameObject playercam;
    public GameObject cutscenecam;
    public GameObject player;

    public Animator bedmove;
    public Animator bedforce;
    public Animator cameraed;

    public AudioSource endingSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cutscenecam.SetActive(true);
            playercam.SetActive(false);
            player.GetComponent<MovementController>().enabled = false;
            endingSound.Play();
            bedmove.Play("bedmoving");
            bedforce.Play("force");
            cameraed.Play("edscene");
        }
        
    }

   
}
