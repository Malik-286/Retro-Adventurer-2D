using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSlider : MonoBehaviour
{
    [SerializeField] Slider loadingSlider;

    [SerializeField] TextMeshProUGUI loadingText;
    [SerializeField] float loadingTime = 5;
    [SerializeField] string levelToLoad;

    float currentValue;
    GameManager gameManager;

      void Start()
    {
        gameManager  = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        currentValue += Time.deltaTime / loadingTime;
        loadingSlider.value  = Mathf.Clamp01(currentValue);  
        loadingText.text = "Loading..."+(int)(loadingSlider.value* 100)+ "%";

        if(loadingSlider.value >= 1)
        {
            if(gameManager != null)
            {
                StartCoroutine(HideLoadingSlider());
                gameManager.LoadNextScene(levelToLoad);                
            }
        }
    }

    IEnumerator HideLoadingSlider()
    {
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
    }

}
