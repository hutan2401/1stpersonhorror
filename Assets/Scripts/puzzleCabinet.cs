using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

public class puzzleCabinet : MonoBehaviour
{
    public Animator cabine;
    
    public GameObject openText;

    public bool inReach;
    public bool isMove;

    private void Start()
    {
        inReach = false;
        openText.SetActive(false);
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


            cabine.SetBool("move", true);
            openText.SetActive(false);
            
            isMove = true;
        }
        else if ( inReach && Input.GetKeyDown(KeyCode.E))
        {
            openText.SetActive(false);
            
        }

        if (isMove)
        {
            cabine.GetComponent<BoxCollider>().enabled = false;
            cabine.GetComponent<puzzleCabinet>().enabled = false;
        }
    }
}
