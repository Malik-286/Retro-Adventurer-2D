using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{

    public InterstitialAd Instance;

    [SerializeField] string _androidAdUnitId = "Intersitial_Ad_Android";
    [SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
    string _adUnitId;



    public bool areAdsEnabled; 
     


    void Awake()
    {
        
        RunSingelton();
        // Get the Ad Unit ID for the current platform:
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOsAdUnitId
            : _androidAdUnitId;
        
        areAdsEnabled = PlayerPrefs.GetInt("AdsStatus", 1) == 1;
    }
 

    void RunSingelton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.Instance);
              
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        if (areAdsEnabled == false)
        {
            return;
        }
        else
        {
            if(areAdsEnabled == true)
            {
                if (this.gameObject != null)
                {
                    if (Advertisement.isInitialized)
                    {
                        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
                        Debug.Log("Loading Ad: " + _adUnitId);
                        Advertisement.Load(_adUnitId, this);
                    }
                }
            }
        }
                  
         
    }

    // Show the loaded content in the Ad Unit:
    public void ShowAd()
    {
        if(areAdsEnabled == false)
        {
            return;
             
        }
        else if(areAdsEnabled == true)
        {
            if (this.gameObject != null)
            {
                if (Advertisement.isInitialized)
                {
                    // Note that if the ad content wasn't previously loaded, this method will fail
                    Debug.Log("Showing Ad: " + _adUnitId);
                    Advertisement.Show(_adUnitId, this);
                }
            }
        }
                      

    }

    // Implement Load Listener and Show Listener interface methods: 
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        
        // Optionally execute code if the Ad Unit successfully loads content.
    }

    public void OnUnityAdsFailedToLoad(string _adUnitId, UnityAdsLoadError error, string message)
    {
        if (this.gameObject != null)
        {
            Debug.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}");
            // Optionally execute code if the Ad Unit fails to load, such as attempting to try again.
        }

    }

    public void OnUnityAdsShowFailure(string _adUnitId, UnityAdsShowError error, string message)
    {
        if (this.gameObject != null)
        {
            Debug.Log($"Error showing Ad Unit {_adUnitId}: {error.ToString()} - {message}");
            // Optionally execute code if the Ad Unit fails to show, such as loading another ad.
        }

    }

    public void OnUnityAdsShowStart(string _adUnitId) { }
    public void OnUnityAdsShowClick(string _adUnitId) { }
    public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState) { }
}
