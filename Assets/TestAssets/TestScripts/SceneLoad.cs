using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{

    [SerializeField] Image loadBar;
    [SerializeField] Text loadPercentage;
    [SerializeField] GameObject loadScreen;
    [SerializeField] TMProTest levelChecker;

    int currentLvl;

    void Start()
    {
        currentLvl = 11;
        
    }
    
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (levelChecker.win)
            {
                currentLvl += 1;
                levelChecker.win = false;
            }
            Debug.Log(currentLvl);
            switch (currentLvl)
            {
                case 11:
                    StartCoroutine(LoadScene(2));
                    break;
                default:
                    StartCoroutine(LoadScene(0));
                    break;
            }
        }
    }

    private IEnumerator LoadScene(int index)
    {
        AsyncOperation CLD = SceneManager.LoadSceneAsync(index);
        loadScreen.SetActive(true);
        while (!CLD.isDone)
        {
            float progress = Mathf.Clamp01(CLD.progress / 0.9f);
            loadBar.fillAmount = progress;
            loadPercentage.text = (progress * 100) + "%";
            yield return null;
        }
        loadScreen.SetActive(false);
    }
}
