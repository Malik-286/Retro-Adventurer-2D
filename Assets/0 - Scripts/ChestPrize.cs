using TMPro;
using UnityEngine;

public class ChestPrize : MonoBehaviour
{

    public static ChestPrize Instance;

    public GameObject PrizeCollectionPanel, CurrentPrizeBox;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    #region PrizeCollection

    int RandomPrize;
    public void ClaimPrize()
    {
        RandomPrize = Random.Range(50, 100);
        PrizeCollectionPanel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "+" + RandomPrize.ToString();
        PrizeCollectionPanel.transform.GetChild(1).gameObject.SetActive(false);
        PrizeCollectionPanel.transform.GetChild(0).gameObject.SetActive(true);
        PrizeCollectionPanel.SetActive(true);
        Invoke(nameof(RemovePrizePanel), 1.5f);
        if (CurrentPrizeBox != null)
            CurrentPrizeBox.GetComponent<Animator>().enabled = true;
    }
    public void RemovePrizePanel()
    {
        PrizeCollectionPanel.SetActive(false);
        PrizeCollectionPanel.transform.GetChild(1).gameObject.SetActive(true);
        PrizeCollectionPanel.transform.GetChild(0).gameObject.SetActive(false);
        if (CurrencyManager.instance)
        {
            CurrencyManager.instance.IncreaseCoins(RandomPrize);
        }
        if (CurrentPrizeBox != null)
            CurrentPrizeBox.GetComponent<BoxCollider2D>().enabled = false;
    }
    #endregion
    // Update is called once per frame
    void Update()
    {
        
    }
}
