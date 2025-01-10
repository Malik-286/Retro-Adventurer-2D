using UnityEngine;
using TMPro;

public class PlayerLevelManager : MonoBehaviour
{

    public static PlayerLevelManager instance;

    public TextMeshProUGUI XPIncreamentText;
    [SerializeField] TextMeshProUGUI playerLevelNoText;
    [SerializeField] TextMeshProUGUI playerNameText;
    [SerializeField] TextMeshProUGUI levelXpText;

    [SerializeField] TMP_InputField inputField;

    [SerializeField] int[] levelsXp;

    [SerializeField] int defaultLevelNo;
    [SerializeField] int currentPlayerLevelNo;
    [SerializeField] int currentPlayerXp;


    // Keys to store and load data from PlayerPrefs
    private const string PlayerNameKey = "PlayerName";
    private const string PlayerLevelKey = "PlayerLevel";
    private const string currentXpKey = "PlayerCurrentXp";
    private void Awake()
    {
        if(instance == null)
        {
          instance = this;
        }

        if(PlayerPrefs.GetInt("Once") == 0)
        {
            inputField.gameObject.transform.parent.gameObject.SetActive(true);
            PlayerPrefs.SetInt("Once", 1);
        }
        else
        {
            inputField.gameObject.transform.parent.gameObject.SetActive(false);
        }

    }

    void Start()
    {
        if (PlayerPrefs.GetInt(PlayerLevelKey) <= 0)
        {
            PlayerPrefs.SetInt(PlayerLevelKey , defaultLevelNo) ;
            playerLevelNoText.text = PlayerPrefs.GetInt(PlayerLevelKey).ToString("0");
        }
    }
    void Update()
    {
        LoadPlayerData();
        UpdatePlayerCurrentXp();
        SavePlayerData();
    }

    public void SavePlayerData()
    {      
            // Save the player's name from the input field
            PlayerPrefs.SetString(PlayerNameKey, inputField.text);

            // Apply the changes
            PlayerPrefs.Save();

            // Update the playerNameText with the inputted name
            playerNameText.text = inputField.text;       
        
    }

    // Load the player's name and level from PlayerPrefs
    void LoadPlayerData()
    {
        // Load the player's name and set the text in the UI
        if (PlayerPrefs.HasKey(PlayerNameKey))
        {
            string savedName = PlayerPrefs.GetString(PlayerNameKey);
            playerNameText.text = savedName;
           
             inputField.text = savedName;  // Optionally set the input field text          
             
        }

        playerLevelNoText.text = PlayerPrefs.GetInt(PlayerLevelKey).ToString();

    }

    void UpdatePlayerCurrentXp()
    {
         levelXpText.text = PlayerPrefs.GetInt(currentXpKey) + "/"+ levelsXp[PlayerPrefs.GetInt(PlayerLevelKey)];
    }

    // Add this code inside the PlayerLevelManager class

    // Method to increase XP
    public void IncreasePlayerXp(int amount)
    {
        PlayerPrefs.SetInt(currentXpKey, PlayerPrefs.GetInt(currentXpKey) + amount); /*currentPlayerXp = amount + currentPlayerXp;*/

        // Ensure the XP doesn't exceed the current level's required XP
        if (PlayerPrefs.GetInt(currentXpKey) >= levelsXp[PlayerPrefs.GetInt(PlayerLevelKey) - 1])
        {
            // If player has enough XP to level up, increase level and reset XP
            LevelUpPlayer();
        }

        // Save the current XP value
        //PlayerPrefs.SetInt(currentXpKey, currentPlayerXp);
        PlayerPrefs.Save();

        XPIncreamentText.gameObject.SetActive(true);
        Invoke(nameof(UpdateUIXPText), 1.1f);

        // Update the UI
        UpdatePlayerCurrentXp();
        SavePlayerData();
    }

    public void UpdateUIXPText()
    {
        XPIncreamentText.gameObject.SetActive(false);
    }

    // Method to handle leveling up
    public void LevelUpPlayer()
    {
        PlayerPrefs.SetInt(PlayerLevelKey, PlayerPrefs.GetInt(PlayerLevelKey) + 1);
        PlayerPrefs.SetInt(currentXpKey, 0); // Reset XP when leveling up

        // Ensure that the level doesn't go beyond the available levels
        if (PlayerPrefs.GetInt(PlayerLevelKey) > levelsXp.Length)
        {
            PlayerPrefs.SetInt(PlayerLevelKey, levelsXp.Length); // Cap the level at the maximum available level
        }
        // Save the new level
        //PlayerPrefs.SetInt(PlayerLevelKey, currentPlayerLevelNo);
        PlayerPrefs.Save();

        // Update the UI with the new level
        playerLevelNoText.text = PlayerPrefs.GetInt(PlayerLevelKey).ToString();

        SavePlayerData();
    }

    // Load the player's current XP when the game starts
    public void LoadPlayerXp()
    {
        if (PlayerPrefs.HasKey(currentXpKey))
        {
            currentPlayerXp = PlayerPrefs.GetInt(currentXpKey);
        }
        else
        {
            currentPlayerXp = 0; // Default to 0 if no XP is saved
        }

        // Update the UI with the current XP
        UpdatePlayerCurrentXp();
    }

  


}


