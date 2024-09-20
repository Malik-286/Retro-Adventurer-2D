using Firebase.Extensions;
using Firebase.RemoteConfig;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RemoteConfig : MonoBehaviour
{

    SettingsPanel settingsPanel;

    void Start()
    {
         FetchDataAsync();
         settingsPanel = FindObjectOfType<SettingsPanel>();
    }


    public Task FetchDataAsync()
    {
        Debug.Log("Fetching data...");
        System.Threading.Tasks.Task fetchTask =
        Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.FetchAsync(
            TimeSpan.Zero);
        return fetchTask.ContinueWithOnMainThread(FetchComplete);
    }


    private void FetchComplete(Task fetchTask)
    {
        if (!fetchTask.IsCompleted)
        {
            Debug.LogError("Retrieval hasn't finished.");
            return;
        }

        var remoteConfig = FirebaseRemoteConfig.DefaultInstance;
        var info = remoteConfig.Info;
        if (info.LastFetchStatus != LastFetchStatus.Success)
        {
            Debug.LogError($"{nameof(FetchComplete)} was unsuccessful\n{nameof(info.LastFetchStatus)}: {info.LastFetchStatus}");
            return;
        }

        // Fetch successful. Parameter values must be activated to use.
        remoteConfig.ActivateAsync()
          .ContinueWithOnMainThread(
            task => {
                Debug.Log($"Remote data loaded and ready for use. Last fetch time {info.FetchTime}.");


                string currentGameVersion = Application.version;

                string fetchedGameVerson = remoteConfig.GetValue("Game_Version").StringValue;

                if( currentGameVersion == fetchedGameVerson)
                {
                    Debug.Log("No Update Available");
                    settingsPanel.DeActivateGameUpdateButton();
                }
                else if(currentGameVersion != fetchedGameVerson)
                {
                    Debug.Log("New Update Available");
                    settingsPanel.ActivateGameUpdateButton();
                }

             });
    }


    
      
    

 
}
 