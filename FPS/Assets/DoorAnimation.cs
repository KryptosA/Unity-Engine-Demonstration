using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour {

    private Animator doorAnim = null;

    void Start()
    {
        doorAnim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        doorAnim.SetBool("character_nearby", true);
        Debug.Log("true");
    }

   void OnTriggerExit(Collider other)
    {
        doorAnim.SetBool("character_nearby", false);
        Debug.Log("false");
    }
}
