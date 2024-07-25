using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEndPanel : MonoBehaviour
{
 
    Interstitial interstitial;


    [SerializeField] GameObject UiControlls;
    void Start()
    {
 
        interstitial = FindObjectOfType<Interstitial>();
    }

      void Update()
    {
        if(this.gameObject.activeInHierarchy)
        {
            UiControlls.SetActive(false);
        }
    }
    public void PressHomeButton()
    {
        Time.timeScale = 1.0f;
        if (AudioManager.GetInstance() != null)
        {
            AudioManager.GetInstance().PlayTouchSoundEffect();
        }
        if (GameManager.GetInstance() != null)
        {
            GameManager.GetInstance().LoadNextScene("Main Menu");
        }
    }

    public void PressReloadButton()
    {
        Time.timeScale = 1.0f;
        if (GameManager.GetInstance() != null)
        {
            if (Adsmanager.Instance)
            {
                Adsmanager.Instance.ShowIntersitial();
            }
                GameManager.GetInstance().ReloadGame();
        }
    }

}
