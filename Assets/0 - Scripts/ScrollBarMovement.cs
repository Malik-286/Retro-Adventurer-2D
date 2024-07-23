using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollBarMovement : MonoBehaviour
{
    public static ScrollBarMovement Instance;

    [Header("FillerWorking")]
    public Image Achievements;

    public float scrollSpeed = 1.0f;
    CurrencyManager currencyManager;
    public Text RewardBtnAIncreament;
    public Text RewardBtnAmount;
    public AudioClip Roller;
    private AudioSource MainAudioSource;
    private Scrollbar scrollbar;
    private bool increasing = true;
    public float finalValue = 0;
    public int Value;
    public int MultiplyBy;

    public TextMeshProUGUI[] IncreamentNumber;

    bool Delay = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        // Achievements.fillAmount += 10;
    }
    private void Start()
    {
        Value = PlayerPrefs.GetInt("CollectedCurrency");
        scrollbar = GetComponent<Scrollbar>();
        MainAudioSource = AudioManager.GetInstance().audioSource;
        MainAudioSource.volume = 0.5f;
       // InvokeRepeating("PlayAudio", 1f, 1.1f);
        print("Collected Score in = " + PlayerPrefs.GetInt("CollectedCurrency"));
    }
    public void PlayAudio()
    {
        GetComponent<AudioSource>().PlayOneShot(Roller);
    }
    public void RemoveDelay()
    {
        Delay = true;
    }

    private void Update()
    {
        Value = PlayerPrefs.GetInt("CollectedCurrency");

        float direction = increasing ? 1.0f : -1.0f;
        float step = Time.deltaTime * scrollSpeed * direction;

        scrollbar.value += step;


        if (scrollbar.value >= 1.0f || scrollbar.value <= 0.0f)
        {
            increasing = !increasing;
        }


        if (scrollbar.value >= 0.0f && scrollbar.value <= 0.2f)
        {
            MultiplyBy = 5;
            finalValue = 5f;
            Value = Value * 5;
            RewardBtnAmount.text = Value.ToString();
            RewardBtnAIncreament.text = "Get 5X".ToString();
            for (int i = 0; i < IncreamentNumber.Length; i++)
            {
                IncreamentNumber[i].fontSize = 35;
            }
            IncreamentNumber[0].fontSize = 50;

        }
        else if (scrollbar.value >= 0.21f && scrollbar.value <= 0.4f)
        {
            MultiplyBy = 3;
            finalValue = 3f;
            Value = Value * 3;
            RewardBtnAmount.text = Value.ToString();
            RewardBtnAIncreament.text = "Get 3X".ToString();
            for (int i = 0; i < IncreamentNumber.Length; i++)
            {
                IncreamentNumber[i].fontSize = 35;
            }
            IncreamentNumber[1].fontSize = 50;
        }
        else if (scrollbar.value >= 0.41f && scrollbar.value <= 0.59f)
        {
            MultiplyBy = 2;
            finalValue = 2f;
            Value = Value * 2;
            RewardBtnAmount.text = Value.ToString();
            RewardBtnAIncreament.text = "Get 2X".ToString();
            for (int i = 0; i < IncreamentNumber.Length; i++)
            {
                IncreamentNumber[i].fontSize = 35;
            }
            IncreamentNumber[2].fontSize = 50;
        }
        else if (scrollbar.value >= 0.6f && scrollbar.value <= 0.8f)
        {
            MultiplyBy = 3;

            finalValue = 3f;
            Value = Value * 3;
            RewardBtnAmount.text = Value.ToString();
            RewardBtnAIncreament.text = "Get 3X".ToString();
            for (int i = 0; i < IncreamentNumber.Length; i++)
            {
                IncreamentNumber[i].fontSize = 35;
            }
            IncreamentNumber[3].fontSize = 50;
        }
        else if (scrollbar.value >= 0.81f && scrollbar.value <= 1f)
        {
            MultiplyBy = 5;

            finalValue = 5f;
            Value = Value * 5;
            RewardBtnAmount.text = Value.ToString();
            RewardBtnAIncreament.text = "Get 5X".ToString();
            for (int i = 0; i < IncreamentNumber.Length; i++)
            {
                IncreamentNumber[i].fontSize = 35;
            }
            IncreamentNumber[4].fontSize = 50;
            //if (Delay == true)
            //{
            //    GetComponent<AudioSource>().PlayOneShot(Roller);
            //    Delay = false;
            //    Invoke(nameof(RemoveDelay), 1.5f);
            //}
        }
    }
}
