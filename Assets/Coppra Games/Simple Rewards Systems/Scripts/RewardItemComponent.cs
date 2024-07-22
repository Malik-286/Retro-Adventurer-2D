using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace CoppraGames
{
    public class RewardItemComponent : MonoBehaviour
    {
        public Image Icon;
        public TextMeshProUGUI CountText;

        public void SetData(SpinWheelController.RewardItem reward)
        {
            this.Icon.sprite = reward.icon;
            this.CountText.text = reward.count.ToString();
        }

    }
}
