using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CoppraGames
{
    public class DailyRewardsWindow : MonoBehaviour
    {
        [System.Serializable]
        public class RewardData
        {
            public Sprite icon;
            public int count;
            public int day;
        }

        public GameObject ResultPanel;
        public Image ResultIcon;
        public TextMeshProUGUI ResultCount;

        public Button ClaimButton;

        public RewardData[] rewards;
        public DailyRewardItem[] rewardItemComponents;

        void Awake()
        {
            HideResult();
            //Init();
        }

        public void Init()
        {
            ApplyValues();
        }

        public void Close()
        {
            Main.instance.ShowDailyRewardsWindow(false);
        }

        public void ApplyValues()
        {
            int index = 0;
            foreach (var r in rewards)
            {
                if (rewardItemComponents.Length > index)
                {
                    rewardItemComponents[index].SetData(r);
                }

                index++;
            }

            RefreshClaimButton();
        }

        public int GetDaysSinceSignUp()
        {
            DateTime current = DateTime.Now;
            DateTime signTime;

            string signTimeString = PlayerPrefs.GetString("sign_up_time");
            if (string.IsNullOrEmpty(signTimeString))
            {
                signTime = DateTime.Now;
                PlayerPrefs.SetString("sign_up_time", signTime.ToString());
            }
            else
            {
                if (!DateTime.TryParse(signTimeString, out signTime))
                {
                    signTime = DateTime.Now;
                }
            }

            TimeSpan timeSpan = current - signTime;
            return timeSpan.Days;
        }

        public bool IsDailyRewardReadyToCollect(int day)
        {
            int loginDay = GetDaysSinceSignUp();
            return (loginDay >= day);
        }

        public bool IsDailyRewardClaimed(int day)
        {
            string key = "reward_claimed_" + day;
            return (PlayerPrefs.GetInt(key, 0) == 1);
        }

        public void ClaimDailyReward(int day)
        {
            string key = "reward_claimed_" + day;
            PlayerPrefs.SetInt(key, 1);

            QuestManager.instance.OnAchieveQuestGoal(QuestManager.QuestGoals.COLLECT_DAILY_REWARDS);
        }

        public void ShowResult(int resultIndex)
        {
            StartCoroutine(_ShowResult(resultIndex));
            SoundController.instance.PlaySoundEffect("collection", false, 1);
        }


        private IEnumerator _ShowResult(int resultIndex)
        {
            if (ResultPanel)
            {
                ResultPanel.SetActive(true);

                if (rewards.Length > resultIndex)
                {
                    ResultIcon.sprite = rewards[resultIndex].icon;
                    ResultCount.text = "x" + rewards[resultIndex].count.ToString();
                }

                ResultPanel.GetComponent<Animator>().Play("clip");
            }
            yield return new WaitForSeconds(3.3f);
            HideResult();
        }

        public void HideResult()
        {
            if (ResultPanel)
            {
                ResultPanel.SetActive(false);
            }
        }

        public void OnClickClaimButton()
        {
            if (DailyRewardItem.selectedItem != null)
            {
                int day = DailyRewardItem.selectedItem.GetDay();
                if (!IsDailyRewardClaimed(day))
                {
                    ClaimDailyReward(day);
                    ShowResult(DailyRewardItem.selectedItem.GetDay() - 1);

                    Init();
                }
            }
        }

        public void RefreshClaimButton()
        {
            if (DailyRewardItem.selectedItem != null)
            {
                int day = DailyRewardItem.selectedItem.GetDay();
                bool isClaimed = IsDailyRewardClaimed(day);
                bool isReadyToCollect = IsDailyRewardReadyToCollect(day);

                this.ClaimButton.interactable = !isClaimed && isReadyToCollect;
            }
            else
                this.ClaimButton.interactable = false;
        }

        public void OnClickCloseButton()
        {
            this.Close();
        }
    }
}
