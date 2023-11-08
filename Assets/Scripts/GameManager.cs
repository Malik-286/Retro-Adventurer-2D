using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singelton<GameManager> 
{
   


    [SerializeField] float waitTime = 3f;

    KillsCounter killsCounter;

 


    
    void Start()
    {
       killsCounter = FindObjectOfType<KillsCounter>();
         
    }

   

 

    public int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    public void ReloadGame()
    {
        Time.timeScale = 1.0f;
        if (killsCounter != null)
        {
            killsCounter.ResetKillsCount();
        }
        string currentScene = SceneManager.GetActiveScene().name;
        LoadNextScene(currentScene);
    }

    public string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }



    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadNextScene(string sceneToLoad)
    {
        StartCoroutine(LoadingNextScene(sceneToLoad));
    }


    IEnumerator LoadingNextScene(string sceneToLoad)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneToLoad);
    }
   


}
