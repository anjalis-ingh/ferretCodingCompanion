using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;

    Message [] currentMessages;
    Actor [] currentActors;
    AudioSource audioSource;
    int activeMessage = 0;
    public static bool isActive = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        backgroundBox.transform.localScale = Vector3.zero;
    }

    // dialogue is now starting, display the first message 
    public void OpenDialogue(Message [] messages, Actor [] actors) {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;

        Debug.Log("Started conversation! Loaded Messages: " + messages.Length);
        DisplayMessage();
        // audio and transition features 
        audioSource.Play();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
    }

    // display the appropriate message for each actor 
    void DisplayMessage() {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actordID];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        AnimateTextColor();
    }

    // display the next message 
    public void NextMessage() {
        activeMessage++;
        if (activeMessage < currentMessages.Length) {
            DisplayMessage();
        }
        // last message sent, conversation has now ended 
        else {
            Debug.Log("Conversation ended!");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;
            audioSource.Stop();
        }
    }

    // text animation 
    void AnimateTextColor() {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }

    // initiate next dialogue 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true) {
            NextMessage();
            audioSource.Play();
        }
    }
}
