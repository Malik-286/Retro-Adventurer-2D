using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelCompletionPanel : MonoBehaviour
{

    [SerializeField] GameObject[] otherPanels;
    [SerializeField] TextMeshProUGUI levelCompletedText;
    [SerializeField] TextMeshProUGUI totalKillsText;
    [SerializeField] string nextSceneToLoad;



     KillsCounter killsCounter;
 

    void Start()
    {
        killsCounter = FindObjectOfType<KillsCounter>();
     }
    void Update()
    {
        UpdateTexts();

        foreach (GameObject panels in otherPanels)
        {
            panels.SetActive(false);
        }

    }


    void UpdateTexts()
    {
        levelCompletedText.text = GameManager.GetInstance().GetActiveSceneName() + " Completed !";
        totalKillsText.text = "Total Kills:  " + killsCounter.GetCurrentSceneKills().ToString("0");
    }

    public void PressHomeButton()
    {

        if (AudioManager.GetInstance() != null)
        {
            AudioManager.GetInstance().PlayTouchSoundEffect();
        }
        if (GameManager.GetInstance() != null)
        {
             GameManager.GetInstance().LoadNextScene("Main Menu");
        }
       
    }

    public void PressNextLevelButton()
    {

        if (AudioManager.GetInstance() != null)
        {
            AudioManager.GetInstance().PlayTouchSoundEffect();
        }
        if (GameManager.GetInstance() != null)
        {
             GameManager.GetInstance().LoadNextScene(nextSceneToLoad);
        }
    }
}
