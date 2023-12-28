using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 public class UpdatePanel : MonoBehaviour
{
 
    string gameUrl = "https://play.google.com/store/apps/details?id=com.AspirePlay.RetroAdventurer&pcampaignid=web_share";


    public void UpdateGame()
    {
        Application.OpenURL(gameUrl);

    }

    
}
