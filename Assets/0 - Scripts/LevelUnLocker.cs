using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnLocker : MonoBehaviour
{
    [SerializeField] Button[] levelsButton;
    [SerializeField] Image[] lockedImages;
    [SerializeField] GameObject[] levelsNoText;

    void Start()
    {
         for (int i = 0; i < levelsButton.Length; i++)
        {
            if (IsLevelUnlocked(i))
            {
                levelsButton[i].interactable = true;
                lockedImages[i].enabled = false;
                levelsNoText[i].SetActive(true);
            }
            else
            {
                levelsButton[i].interactable = false;
                lockedImages[i].enabled = true;
                levelsNoText[i].SetActive(false);
            }
        }
    }

     
    public void UnlockLevel(int index)
    {
        // Set the level as unlocked in PlayerPrefs
        PlayerPrefs.SetInt("Level" + index, 1);
        PlayerPrefs.Save();

        // Update the UI
        levelsButton[index].interactable = true;
        lockedImages[index].enabled = false;
        levelsNoText[index].SetActive(true);
    }
      
    public bool IsLevelUnlocked(int index)
    {
        // Check if the level is unlocked in PlayerPrefs
        return PlayerPrefs.GetInt("Level" + index, 0) == 1;
    }
}

