using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singelton<GameManager> 
{
   


    [SerializeField] float waitTime = 3f;

    
    void Start()
    {
        
    }

    public void ReloadGame()
    {
       string currentScene = SceneManager.GetActiveScene().name;
        LoadNextScene(currentScene);
    }

    

    public void QuitGame()
    {


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
