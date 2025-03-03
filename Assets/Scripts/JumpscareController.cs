using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareController : MonoBehaviour
{
    [SerializeField] private Animator jumpscareAnim;
    //public AudioClip jumpscareClip;
    [SerializeField] private AudioSource jumpsource;
    [SerializeField] private GameObject jumpscareTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jumpscareAnim.Play("jumpscare");
            jumpsource.Play();
            StartCoroutine(CloseJumpscare());
        }
    }
    private IEnumerator CloseJumpscare()
    {
        yield return new WaitForSeconds(2);
        jumpscareTrigger.SetActive(false );
    }
}
