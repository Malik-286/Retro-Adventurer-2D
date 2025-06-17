using UnityEngine;
using UnityEngine.UI;
using Steamworks;
using TMPro;

public class SteamSettings : MonoBehaviour
{
    public RawImage avatarImage;       // Assign in Inspector
    public TMP_Text playerNameText;    // Assign a TextMeshProUGUI object

    void Start()
    {
        if (!SteamManager.Initialized)
        {
            Debug.Log("Steam not initialized.");
            return;
        }

        // Display player name
        string steamName = SteamFriends.GetPersonaName();
        if (playerNameText != null)
            playerNameText.text = steamName;

        // Get and display avatar
        int avatarInt = SteamFriends.GetLargeFriendAvatar(SteamUser.GetSteamID());
        if (avatarInt == -1) return;

        uint width, height;
        if (SteamUtils.GetImageSize(avatarInt, out width, out height))
        {
            byte[] image = new byte[4 * (int)width * (int)height];
            if (SteamUtils.GetImageRGBA(avatarInt, image, image.Length))
            {
                Texture2D texture = new Texture2D((int)width, (int)height, TextureFormat.RGBA32, false);
                texture.LoadRawTextureData(image);
                texture.Apply();
                avatarImage.texture = texture;
            }
        }
    }
}

