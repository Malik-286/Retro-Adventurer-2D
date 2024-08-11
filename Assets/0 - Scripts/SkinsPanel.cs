using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SkinsPanel : MonoBehaviour
{

    [SerializeField] int SelectedSkinNumber;

    public int[] SkinPrices;
    public TextMeshProUGUI[] SkinPricesText;
    public Button[] SkinButtons;
    public Button[] SkinImagesButtons;

    [SerializeField] AudioClip selectedSoundEffect;

    public GameObject SuccessPanel;
    public GameObject FailurePanel;

    [SerializeField] Color defaultTextColour = Color.white;
    [SerializeField] Color selectedTextColour = Color.blue;


    void Awake()
    {
   

        for (int i = 0; i < SkinButtons.Length; i++)
        {
            if (PlayerPrefs.GetInt("SkinPurchased" + i) == 1)
            {
                SkinImagesButtons[i].interactable = true;
                SkinButtons[i].gameObject.SetActive(false);
            }
        }

        // Set the selected skin on panel open
        int currentSkin = PlayerPrefs.GetInt("CurrentPlayer", 0); // Default to skin 0 if not set
        SelectSkin(currentSkin);
    }

     void Start()
    {
        
    }

    public void PurchaseSkin(int SkinNumber)
    {
        print("Player Skin Selected" + SkinNumber+ "And Price is" + SkinPrices[SkinNumber] +" but your coins " + CurrencyManager.instance.GetCurrentCoins());
        if (SkinPrices[SkinNumber] < CurrencyManager.instance.GetCurrentCoins())
        {
            print("Purchasing");
            CurrencyManager.instance.DecreaseCoins(SkinPrices[SkinNumber]);
            SkinImagesButtons[SkinNumber].interactable = true;
            SkinButtons[SkinNumber].gameObject.SetActive(false);
            SuccessPanel.SetActive(true);
            PlayerPrefs.SetInt("SkinPurchased" + SkinNumber, 1);
        }
        else
        {
            print("failed");
            FailurePanel.SetActive(true);
        }
    }

    public void SelectSkin(int SkinNumber)
    {

        if(AudioManager.GetInstance() != null)
        {
            AudioManager.GetInstance().PlaySingleShotAudio(selectedSoundEffect, 1.0f);
        }
        PlayerPrefs.SetInt("CurrentPlayer", SkinNumber);
        for (int i = 0; i < SkinPricesText.Length; i++)
        {
            SkinPricesText[i].text = "Select".ToString();
            SkinPricesText[i].color = defaultTextColour;
        }
        SkinPricesText[SkinNumber].text = "Selected".ToString();
        SkinPricesText[SkinNumber].color = selectedTextColour;
        print("Player Skin Selected");
    }
    void Update()
    {
        
    }
}
