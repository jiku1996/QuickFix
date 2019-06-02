using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TMProTest : MonoBehaviour
{

    [SerializeField]
    int Level;

    float score;
    TextMeshProUGUI scoreText;

    [SerializeField]
    float minScore;

    [SerializeField]
    TextMeshProUGUI minScoreText;

    [SerializeField]
    Image scoreFiller;

    //Vanessa's
    int delay;
    public bool win, stop;

    // Start is called before the first frame update
    void Start()
    {
        
        win = false; delay = 10; stop = true;
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        minScoreText.text = minScore.ToString();
        scoreText.text = score.ToString();

        scoreFiller.fillAmount = score / minScore;

        if(score >= minScore)
        {
            
            if (stop)
            {
                if (delay != 0)
                {
                    delay--;
                }
                else
                {
                    win = true;
                    stop = false;
                }
            }
            

            if (win)
            {
                SceneManager.LoadScene(Level);
                win = false;
            }

        }
        else
        {
            //failed
        }
    }

    public float Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }
}
