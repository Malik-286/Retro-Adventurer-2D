using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

namespace CoppraGames
{
    public class QuestItem : UIBehaviour
    {

        #region Variables
        //[Header("Prefabs")]
        [Header("Component Refs")]
        public Image BG;
        public GameObject ClaimedLabel;
        public TextMeshProUGUI DescriptionText;

        public TextMeshProUGUI ProgressText;
        public ProgressBar ProgressBar;

        public Image RewardIcon;
        public TextMeshProUGUI RewardCountText;

        public GameObject GoButton;
        public GameObject ClaimButton;

        public Color ClaimedColor;

        //[Header("Public Vars")]
        private QuestManager.Quest _quest;

        #endregion

        #region Builtin Methods
        void Start()
        {

        }

        void Update()
        {

        }
        #endregion

        #region Custom Methods
        public override void SetData(UIBehaviourOptions data)
        {
            int questIndex = data.index;
            _quest = QuestManager.instance.quests[questIndex];
            _Refresh();
        }



        public void OnClickGoButton()
        {
            GetComponentInParent<QuestWindow>().GoQuest(this);
        }

        public void OnClickClaimButton()
        {
            GetComponentInParent<QuestWindow>().ClaimQuest(this);
        }

 
        private void _Refresh()
        {
            if (_quest != null)
            {
                if (DescriptionText)
                {
                    DescriptionText.text = _quest.description;
                }

                if (RewardIcon && RewardCountText)
                {
                    RewardIcon.sprite = _quest.rewards.icon;
                    RewardCountText.text = _quest.rewards.count.ToString();
                }

                int progress = QuestManager.instance.GetQuestValue(_quest.index);
                int goalValue = _quest.maxValue;

                if (ProgressText && ProgressBar)
                {
                    int percentage = (int)(((float)progress / (float)goalValue) * 100);
                    ProgressText.text = progress.ToString() + "/" + goalValue.ToString();
                    ProgressBar.SetProgress(percentage);
                }

                if (GoButton && ClaimButton)
                {
                    GoButton.SetActive(progress != goalValue);
                    ClaimButton.SetActive(progress >= goalValue);
                }

                bool isClaimed = QuestManager.instance.IsQuestClaimed(_quest.index);
                this.ProgressBar.gameObject.SetActive(!isClaimed);
                this.ClaimedLabel.SetActive(isClaimed);
                BG.color = isClaimed ? ClaimedColor : Color.white;

                GoButton.SetActive(GoButton.activeSelf && !isClaimed);
                ClaimButton.SetActive(ClaimButton.activeSelf && !isClaimed);


            }
        }

        public QuestManager.Quest GetQuest()
        {
            return _quest;
        }

        #endregion
    }
}
