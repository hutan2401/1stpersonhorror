using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCutscene : MonoBehaviour
{
    public GameObject playercam;
    public GameObject cutscenecam;
    

    private void OnTriggerEnter(Collider other)
    {
        cutscenecam.SetActive(true);
        playercam.SetActive(false);
    }
}
