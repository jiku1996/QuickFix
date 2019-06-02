using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Messages
{
    //[TextArea(3, 10)]
    public TextAsset textFile;
    public string[] sentences; //dialogues to be displayed, values are in the inspector

    void Start()
    {
        for (int i = 0; i < sentences.Length; i++)
        {
            sentences[i] = "";
        }
        if (textFile != null)
        {
            sentences = (textFile.text.Split('\n'));
        }
    }
}
