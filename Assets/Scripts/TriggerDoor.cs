using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    bool DoorOpen = false;
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public List<Collider2D> detectedObjs = new List<Collider2D>();

    // detect when object enters the the range of the object
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player") == true) {
            DoorOpen = true;
            animator.SetBool("DoorOpen", DoorOpen);
        }
    }

    // detect when object leaves the range of the object 
    void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player") == true) {
            DoorOpen = false;
            animator.SetBool("DoorOpen", DoorOpen);
        }
    }

}
