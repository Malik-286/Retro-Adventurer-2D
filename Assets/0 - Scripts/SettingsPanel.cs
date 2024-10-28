using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{

    [SerializeField] Slider musicSwitch;
    [SerializeField] AudioClip gamePlayAudio;
    [SerializeField] TextMeshProUGUI versionText;
  
    string fbURL = "https://www.facebook.com/profile.php?viewas=100000686899395&id=61556956161259";
    string instaURL = "https://www.instagram.com/aspire_games_studio/?igsh=dGZhemd3bGpiNHh0";
    string discoedURL = "https://discord.gg/bMmsU8k8";



    string appstoreUrl = "https://apps.apple.com/app/castle-invaders/id6480585969";
    string appstoreMoreGamesUrl = "https://apps.apple.com/app/castle-invaders/id6480585969";

    string googlePlayStoreUrl = "https://play.google.com/store/apps/details?id=com.AspirePlay.RetroAdventurer&pcampaignid=web_share";
    string googlePlayStoreMoreGamesUrl = "https://play.google.com/store/apps/details?id=com.AspirePlay.RetroAdventurer&pcampaignid=web_share";

    void Start()
    {
        versionText.text = Application.version;

     }
    public void AdjustMusicSettings()
    {
        if (AudioManager.GetInstance())
        {
            if (musicSwitch.value > 0)
            {
                AudioManager.GetInstance().GetComponent<AudioSource>().mute = true;
            }
            else if (musicSwitch.value <= 0)
            {
                AudioManager.GetInstance().GetComponent<AudioSource>().mute = false;
            }
        }
    }

  
    public void OpenFaceBook()
    {
        Application.OpenURL(fbURL);
    }
    public void OpenInstagram()
    {
        Application.OpenURL(instaURL);
    }

    public void OpendDiscord()
    {
        Application.OpenURL(discoedURL);
    }

    public void RateUs()
    {
        if (Application.platform != RuntimePlatform.IPhonePlayer)
        {
            // Open Google Play Store URL
            Application.OpenURL(googlePlayStoreUrl);
        }
        else
        {
            // Open Apple App Store URL
            Application.OpenURL(appstoreUrl);
        }
    }

    public void MoreGames()
    {
        if (Application.platform != RuntimePlatform.IPhonePlayer)
        {
            // Open Google Play Store URL
            Application.OpenURL(googlePlayStoreMoreGamesUrl);
        }
        else
        {
            // Open Apple App Store URL
            Application.OpenURL(appstoreMoreGamesUrl);
        }
    }

    public void UpdateGame()
    {
         RateUs();
    }

}

    
