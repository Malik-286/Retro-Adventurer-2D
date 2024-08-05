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

    public GameObject SuccessPanel;
    public GameObject FailurePanel;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("SkinPurchased" + 0) == 1)
        {
            SkinImagesButtons[0].interactable = true;
            SkinButtons[0].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("SkinPurchased" + 1) == 1)
        {
            SkinImagesButtons[1].interactable = true;
            SkinButtons[1].gameObject.SetActive(false);
        }
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
        PlayerPrefs.SetInt("CurrentPlayer", SkinNumber);
        for (int i = 0; i < SkinPricesText.Length; i++)
        {
            SkinPricesText[i].text = "Select".ToString();
        }
        SkinPricesText[SkinNumber].text = "Selected".ToString();
        print("Player Skin Selected");
    }
    void Update()
    {
        
    }
}
