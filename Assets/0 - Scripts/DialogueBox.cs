using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] Sprite[] itemsSprites;
    [SerializeField] Image uiImage;  
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] string[] lines;
    [SerializeField] float textSpeed = 0.3f;
    [SerializeField] Button continueButton;
    [SerializeField] TextMeshProUGUI continueToFinishText;



    [Header("Lines Rotation")]
    [SerializeField] GameObject lineToRotate;
    [SerializeField] float rotateSpeed = 1f;


    [SerializeField] int index;

    void Awake()
    {
    }

    void Start()
    { 
        textComponent.text = string.Empty;
        continueButton.interactable = false;
        uiImage.enabled = false;
        lineToRotate.gameObject.SetActive(false);

        // Only start dialogue if the game object is active
        StartDialogue();
    }

      void Update()
    {
        lineToRotate.gameObject.transform.Rotate(0, 0, rotateSpeed);
        if(index == 3)
        {
            PlayerPrefs.SetInt("OneTime", 1);
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        // Set the continue button to interactable once the line is fully typed out
        continueButton.interactable = true;
    }

    public void PressContinueButton()
    {
        if (textComponent.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
            continueButton.interactable = true; // Ensure button is interactable if skipping
        }
    }

    public void NextLine()
    {
        continueButton.interactable = false; // Make button non-interactable when starting a new line

        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());

            // Update the image based on the current line index
            if (index < itemsSprites.Length)
            {
                uiImage.enabled = true;
                lineToRotate.gameObject.SetActive(true);

                uiImage.sprite = itemsSprites[index];
            }

            // If the next line is the last one, update the button text to "Finish"
            if (index == lines.Length - 1)
            {
                continueToFinishText.text = "Finish"; // Fixed variable name
            }
        }
        else
        {
           gameObject.SetActive(false);

        }
    }
}
