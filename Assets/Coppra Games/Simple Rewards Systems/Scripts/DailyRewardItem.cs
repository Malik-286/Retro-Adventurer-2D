using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CoppraGames
{
    public class DailyRewardItem : MonoBehaviour
    {
        public static DailyRewardItem selectedItem;

        public Image Icon;
        public TextMeshProUGUI CountText;

        public Image DayPanel;
        public GameObject GreenPanel;
        public GameObject Glow;
        public GameObject TickMark;

        [HideInInspector]
        public int day;

        public void SetData(DailyRewardsWindow.RewardData reward)
        {
            this.Icon.sprite = reward.icon;
            this.CountText.text = reward.count.ToString();
            this.day = reward.day;

            bool isReadyToCollect = Main.instance.DailyRewardsWindow.IsDailyRewardReadyToCollect(day);
            bool isClaimed = Main.instance.DailyRewardsWindow.IsDailyRewardClaimed(day);

            GreenPanel.SetActive(isReadyToCollect);
            Glow.SetActive(!isClaimed && selectedItem == this);

            DayPanel.color = isReadyToCollect && !isClaimed ? Color.green : Color.white;
            TickMark.SetActive(isClaimed);

            if (isReadyToCollect && !isClaimed)
                SetSelected(true);
        }

        public void SetSelected(bool isTrue)
        {
            if (this != selectedItem && selectedItem != null)
                selectedItem.SetSelected(false);
        
            Glow.SetActive(isTrue);

            if(isTrue)
                selectedItem = this;
        }

        //private bool _IsReadyToCollect()
        //{
        //    int loginDay = GetComponentInParent<DailyRewardsWindow>().GetDaysSinceSignUp();
        //    return (loginDay >= _day);
        //}

        //private bool _IsClaimed()
        //{
        //    return GetComponentInParent<DailyRewardsWindow>().IsDailyRewardClaimed(_day);
        //}

       
        public int GetDay()
        {
            return day;
        }

    }
}