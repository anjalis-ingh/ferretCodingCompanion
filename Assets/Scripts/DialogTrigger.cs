using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    // arrays for messages and actors 
    public Message[] messages;
    public Actor[] actors;

    // assign appropriate actor id and messages for this specifc scneario 
    public void StartDialogue() {
        FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
    }
}

[System.Serializable]
public class Message {
    public int actordID;
    public string message;
}

[System.Serializable]
public class Actor {
    public string name;
    public Sprite sprite;
}