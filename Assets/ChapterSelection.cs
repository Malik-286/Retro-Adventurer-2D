using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChapterSelection : MonoBehaviour
{
    public GameObject ChapterPanel;
    public GameObject[] ChapterLevels;
    public GameObject[] ChapterLocks;
    public TextMeshProUGUI[] ChaptersProgressTexts;

    string chapterKey;
    int chapterProgress;

    private void OnEnable()
    {
        PlayerPrefs.SetInt("ChapterUnlocked", 1);

        for (int i = 0; i < 5; i++)
        {
            if (i <= PlayerPrefs.GetInt("ChapterUnlocked"))
            {
                ChaptersProgressTexts[i].text = "Progress: " + ChapterProgressManager.GetChapterProgress(i) + "%".ToString();
            }
            else
            {
                ChaptersProgressTexts[i].gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < PlayerPrefs.GetInt("ChapterUnlocked"); i++)
        {
            ChapterLocks[i].SetActive(false);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void SelectChapter(int ChapterNumber)
    {
        for (int i = 0; i < ChapterLevels.Length; i++)
        {
            ChapterLevels[i].SetActive(false);
        }
        ChapterLevels[ChapterNumber].SetActive(true);
        ChapterPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        print("chapeterlocks = " + PlayerPrefs.GetInt("ChapterUnlocked"));
    }
}
public static class ChapterProgressManager
{
    public static int GetChapterProgress(int chapterIndex)
    {
        string chapterKey = $"{(chapterIndex + 1)}ChapterProgress"; // Dynamically generate the key
        return PlayerPrefs.GetInt(chapterKey, 0); // Return the progress, default to 0 if key doesn't exist
    }

    public static void SetChapterProgress(int chapterIndex, int progress)
    {
        string chapterKey = $"{(chapterIndex + 1)}ChapterProgress"; // Dynamically generate the key
        PlayerPrefs.SetInt(chapterKey, progress); // Save the progress
    }
}
