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

    //private Queue<string> dialogues;
    private List<string> dialogues;
    public int line_num; //line number on textFile

    [SerializeField] AudioSource talk;
    bool play;


    void Start()
    {
        play = true;
        anim.SetBool("startConvo", true);
        #region oldScript
        /*
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
        */
        #endregion

        dialogues = new List<string>();
        if (scriptFile != null)
        {
            sentences = (scriptFile.text.Split('\n'));
        }

        dialogues.Clear();
        foreach (string s in sentences)
        {
            dialogues.Add(s);
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

        //string d = dialogues.Dequeue(); //OLD

        ///////////////////////////////////////////////
        string d = dialogues[line_num];
        /* ^ assigns line dialogue from text file.
         
         EXAMPLE: 
         TEXTFILE:
         0 The quick brown fox jumps over the lazy dog.
         1 The dog died.
         2 The fox laughed.
         3 Wag tularan si Fox, bad siya.
         
         the numbers before each phrases/sentences corresponds to the line number.
         sen_num variable is equal to line number. 
         So if sen_num is 3, dialogueBox will print out sentence 3:
         "Wag tularan si Fox, bad siya."
         */
        ///////////////////////////////////////////////

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
