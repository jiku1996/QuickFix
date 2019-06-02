using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject dialogueBox, testButton;

    public Messages dialogue;
    void Start()
    {
        dialogueBox.SetActive(false);
    }
    public void TriggerDialogue()
    {
        testButton.SetActive(false);
        dialogueBox.SetActive(true);
        FindObjectOfType<DialogueBox>().StartDialogue(dialogue);
    }

}
