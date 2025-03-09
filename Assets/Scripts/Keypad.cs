using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public GameObject player;
    public GameObject keypadOB;
    //public GameObject hud;
    public GameObject inv;

    public GameObject animateOB;
    public Animator ANI;

    public Text textOB;
    public string answer = "1";

    public bool animate;

     void Start()
    {
        animate = false;
    }

    public void Number(int number)
    {
        textOB.text += number.ToString();
        
    }

    public void Enter()
    {
        if(textOB.text == answer)
        {
            
            textOB.text = "Right";
        }
        else
        {
            
            textOB.text = "Wrong";
        }
    }

    public void Clear()
    {
        textOB.text = "";
        
    }

    public void Exit()
    {
        keypadOB.SetActive(false);
        inv.SetActive(true);
        //hud.SetActive(true );
        player.GetComponent<CameraController>().enabled = true;
    }

    public void Update()
    {
        if (textOB.text == "Right" )
        {
            animate = true;
            ANI.SetBool("animate", true);
            //Debug.Log("it's open");
        }
        if (keypadOB.activeInHierarchy)
        {
            //hud.SetActive(false );
            inv.SetActive(false );
            player.GetComponent<CameraController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
