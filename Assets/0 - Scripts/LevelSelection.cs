using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{


    [SerializeField] LoadingSlider loadingSlider;
    [SerializeField] GameObject loadingPanel;


     void Start()
    {
        loadingPanel.SetActive(false);
    }

     
    public void LevelSelected(string levelSelected)
    {
        if (Adsmanager.Instance)
        {
            Adsmanager.Instance.ShowIntersitial();
        }

        if(loadingSlider != null)
        {
            loadingSlider.SetLevelToLoad(levelSelected);
            loadingPanel.SetActive(true);
            this.gameObject.SetActive(false);
 
        }

    }
}
