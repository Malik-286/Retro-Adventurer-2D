using hardartcore.CasualGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] LoadingSlider loadingSlider;
    [SerializeField] GameObject loadingPanel;
    [SerializeField] AudioClip whooshSFX;

    [SerializeField] Sprite panel_1_to_10_bg;
    [SerializeField] Sprite panel_11_to_20_bg;
    [SerializeField] Sprite panel_21_to_30_bg;
    [SerializeField] Sprite panel_31_to_40_bg;
    [SerializeField] Sprite panel_41_to_50_bg;


    [SerializeField] Image[] panels_Counts;

    [SerializeField] GameObject[] levelsPanels;

    [SerializeField] Image bgPanel;

      int currentPanelIndex = 0;

    public void OnEnable()
    {
        currentPanelIndex = PlayerPrefs.GetInt("LastPanelIndex", 0);
        UpdatePanels();
    }

    public void OnDisable()
    {
         SaveAndEnableLastPanel();
    }
    void Start()
    {
        loadingPanel.SetActive(false);
        currentPanelIndex = PlayerPrefs.GetInt("LastPanelIndex", 0);
        UpdatePanels();
    }

    void Update()
    {
        ChangePanelsBackGround();
    }

    public void LevelSelected(string levelSelected)
    {
        if (Adsmanager.Instance)
        {
            Adsmanager.Instance.ShowIntersitial();
        }

        if (loadingSlider != null)
        {
            loadingSlider.SetLevelToLoad(levelSelected);
            loadingPanel.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    public void ChangePanelsBackGround()
    {
 
        ResetPanelsCountSize();


        GameObject panel_1_to_10 = GameObject.FindWithTag("1-10");
        GameObject panel_11_to_20 = GameObject.FindWithTag("11-20");
        GameObject panel_21_to_30 = GameObject.FindWithTag("21-30");
        GameObject panel_31_to_40 = GameObject.FindWithTag("31-40");
        GameObject panel_41_to_50 = GameObject.FindWithTag("41-50");

        if (panel_1_to_10 != null && panel_1_to_10.activeInHierarchy)
        {
            bgPanel.sprite = panel_1_to_10_bg;
            panels_Counts[0].transform.localScale = new Vector2(1.1f, 1.1f);
        }
        else if (panel_11_to_20 != null && panel_11_to_20.activeInHierarchy)
        {
            bgPanel.sprite = panel_11_to_20_bg;
            panels_Counts[1].transform.localScale = new Vector2(1.1f, 1.1f);
        }
        else if (panel_21_to_30 != null && panel_21_to_30.activeInHierarchy)
        {
            bgPanel.sprite = panel_21_to_30_bg;
            panels_Counts[2].transform.localScale = new Vector2(1.1f, 1.1f);

        }
        else if (panel_31_to_40 != null && panel_31_to_40.activeInHierarchy)
        {
            bgPanel.sprite = panel_31_to_40_bg;
            panels_Counts[3].transform.localScale = new Vector2(1.1f, 1.1f);

        }
        else if (panel_41_to_50 != null && panel_41_to_50.activeInHierarchy)
        {
            bgPanel.sprite = panel_41_to_50_bg;
            panels_Counts[4].transform.localScale = new Vector2(1.1f, 1.1f);
           

        }
    }

    public void LeftClick()
    {

        if (AudioManager.GetInstance() != null)
        {
            AudioManager.GetInstance().PlaySingleShotAudio(whooshSFX, 1.0f);
        }
        currentPanelIndex--;
        if (currentPanelIndex < 0)
        {
            currentPanelIndex = levelsPanels.Length - 1;
        }
        UpdatePanels();
    }

    public void RightClick()
    {

        if (AudioManager.GetInstance() != null)
        {
            AudioManager.GetInstance().PlaySingleShotAudio(whooshSFX, 1.0f);
        }
        currentPanelIndex++;
        if (currentPanelIndex >= levelsPanels.Length)
        {
            currentPanelIndex = 0;
        }
        UpdatePanels();
    }

      void UpdatePanels()
    {
        for (int i = 0; i < levelsPanels.Length; i++)
        {
            Dialog dialog = levelsPanels[i].GetComponent<Dialog>();
            if (i == currentPanelIndex)
            {
                if (!levelsPanels[i].activeSelf)
                {
                    levelsPanels[i].SetActive(true); // Ensure the panel is active before showing dialog
                }
                dialog.ShowDialog();
            }
            else
            {
                if (levelsPanels[i].activeSelf)
                {
                    dialog.HideDialog();
                }
            }
        }
    }

    public void ResetPanelsCountSize()
    {
        foreach (Image image in panels_Counts)
        {
            image.transform.localScale = new Vector2(0.6f, 0.6f);
        }
    }


    void SaveAndEnableLastPanel()
    {
        // Save the current panel index to PlayerPrefs
        PlayerPrefs.SetInt("LastPanelIndex", currentPanelIndex);
        PlayerPrefs.Save();
    }


}
