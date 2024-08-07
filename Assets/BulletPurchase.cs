using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletPurchase : MonoBehaviour
{
    [Header("References")]
    public GameObject[] BulletPurchaseButtons;
    public Button[] BulletImage;
    public TextMeshProUGUI[] SelectText;

    public int[] BulletPrices;

    [Header("Panels")]
    public GameObject SuccessPanel;
    public GameObject FailurePanel;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("BulletPurchased" + 0) == 1)
        {
            BulletImage[0].interactable = true;
            BulletPurchaseButtons[0].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("BulletPurchased" + 1) == 1)
        {
            BulletImage[1].interactable = true;
            BulletPurchaseButtons[1].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("BulletPurchased" + 2) == 1)
        {
            BulletImage[0].interactable = true;
            BulletPurchaseButtons[0].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("BulletPurchased" + 3) == 1)
        {
            BulletImage[1].interactable = true;
            BulletPurchaseButtons[1].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("BulletPurchased" + 4) == 1)
        {
            BulletImage[0].interactable = true;
            BulletPurchaseButtons[0].gameObject.SetActive(false);
        }
    }
  


    public void PurchaseBllet(int BulletNumber)
    {
        print("Bullet Number Selected" + BulletNumber + "And Price is" + BulletPrices[BulletNumber] + " but your coins " + CurrencyManager.instance.GetCurrentCoins());
        if (BulletNumber == 0)
        {
            if (BulletPrices[BulletNumber] < CurrencyManager.instance.GetCurrentCoins())
            {
                print("Purchasing");
                CurrencyManager.instance.DecreaseCoins(BulletPrices[BulletNumber]);
                BulletImage[BulletNumber].interactable = true;
                BulletPurchaseButtons[BulletNumber].gameObject.SetActive(false);
                SuccessPanel.SetActive(true);
                PlayerPrefs.SetInt("BulletPurchased" + BulletNumber, 1);
            }
        }
        else
        {
            print("failed");
            FailurePanel.SetActive(true);
        }
    }


    public void SelectBullet(int BulletNumber)
    {
        PlayerPrefs.SetInt("PlayerBullet", BulletNumber);
        for (int i = 0; i < SelectText.Length; i++)
        {
            SelectText[i].text = "Select".ToString();
        }
        SelectText[BulletNumber].text = "Selected".ToString();
        print("Player Bullet Selected");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
