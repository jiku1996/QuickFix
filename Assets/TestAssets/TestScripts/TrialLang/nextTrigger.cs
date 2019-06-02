using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextTrigger : MonoBehaviour
{
    public void TriggerNextSentence()
    {
        FindObjectOfType<DialogueBoxManager>().DisplayMessages();
    }
}
