using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogTrigger trigger;

    // if player approaches an NPC (box collider), trigger dialogue to start 
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player") == true)
            trigger.StartDialogue();
    }
}
