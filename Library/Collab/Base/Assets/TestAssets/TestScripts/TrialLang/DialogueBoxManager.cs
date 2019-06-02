using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBoxManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogueTxt;
    [SerializeField] Animator anim;

    [SerializeField] TextAsset scriptFile;
    [TextArea(3,10)]
    private string[] sentences;
    private Queue<string> dialogues;

    [SerializeField] AudioSource talk;
    bool play;


    void Start()
    {
        play = true;
        anim.SetBool("startConvo", true);
        dialogues = new Queue<string>();
        if(scriptFile != null)
        {
            sentences = (scriptFile.text.Split('\n'));
        }

        dialogues.Clear();
        foreach (string s in sentences)
        {
            dialogues.Enqueue(s);
        }

        DisplayMessages();

    }

    

    public void DisplayMessages()
    {
        if(dialogues.Count == 0)
        {
            EndDialogue();
            return;
        }
        string d = dialogues.Dequeue();
        StopAllCoroutines();
        StartCoroutine(SingleLetters(d));
    }

    IEnumerator SingleLetters(string dialogues)
    {
        talk.Play();
        dialogueTxt.GetComponent<TextMeshProUGUI>().text = "";
        foreach(char let in dialogues.ToCharArray())
        {
            dialogueTxt.GetComponent<TextMeshProUGUI>().text += let;
            yield return null;
        }
    }

    void EndDialogue()
    {
        anim.SetBool("startConvo", false);
    }
}
