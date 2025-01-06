using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSlider : MonoBehaviour
{
    [SerializeField] Slider loadingSlider;

    [SerializeField] TextMeshProUGUI loadingText;
    [SerializeField] float loadingTime;
    [SerializeField] string levelToLoad;

    float currentValue;
 
    void Start()
    {
         loadingTime = Random.Range(1.2f, 3.2f);
    }
    private void OnEnable()
    {
        currentValue = 0;
        StartCoroutine(StartLoading());
    }
    public void SetLevelToLoad(string settingLevelName)
    {
        levelToLoad = settingLevelName;
        Debug.Log(levelToLoad);
    }
    void Update()
    {
         int value = (int)loadingSlider.value;
         loadingText.text = "Loading..." + value + "%";   
    }

    IEnumerator StartLoading()
    {
        yield return new WaitForSeconds(3.2f);
        if (GameManager.GetInstance() != null)
        {
            if (loadingSlider.value == 100)
            {
                GameManager.GetInstance().LoadNextScene(levelToLoad);
            }        
        }
    }


   
}
