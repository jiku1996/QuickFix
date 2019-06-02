using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{

    //UI
    public TextMeshProUGUI dialogueText;
    public Animator anim;

    //audio
    [SerializeField] AudioSource talk;
    bool play;

    //dialogueMessages
    private Queue<string> sentences;
    void Start()
    {
        play = true;
        sentences = new Queue<string>();
    }

    public void StartDialogue (Messages dialogue)
    {
        anim.SetBool("startConvo", true);
        sentences.Clear();
        foreach(string mess in dialogue.sentences)
        {
            sentences.Enqueue(mess);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(SingleLetters(sentence));
        }
    }

    IEnumerator SingleLetters (string sentence)
    {
        talk.Play();
        dialogueText.GetComponent<TextMeshProUGUI>().text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.GetComponent<TextMeshProUGUI>().text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        anim.SetBool("startConvo", false);
    }
}

