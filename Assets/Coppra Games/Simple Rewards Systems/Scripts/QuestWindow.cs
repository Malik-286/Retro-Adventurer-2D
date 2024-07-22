using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CoppraGames
{
    public class QuestWindow : MonoBehaviour
    {

        public static QuestWindow instance;

        /* prefabs */
        public QuestItem QuestItemPrefab;

        /* component references */
        public DataList DataList;

        public GameObject RewardClaimingPanel;
        public Image RewardClaimingIcon;
        public TextMeshProUGUI RewardClaimingCount;


        /* private variables */

        private void Awake()
        {
            instance = this;
            HideRewardClaiming();
        }

        private void Update()
        {

        }

        public void Init()
        {
            this.Refresh();
        }


        public void Refresh()
        {
            _LoadItemsList();
        }


        private void _LoadItemsList()
        {
            if (DataList != null)
            {
                DataList.Clear();
                DataListOptions options = new DataListOptions();
                List<UIBehaviourOptions> list = new List<UIBehaviourOptions>();

                foreach(QuestManager.Quest quest in QuestManager.instance.quests)
                {
                    //if (!QuestManager.instance.IsQuestClaimed(quest.index))
                    //{
                        UIBehaviourOptions option = new UIBehaviourOptions();
                        option.index = quest.index;
                        list.Add(option);
                    //}
                }

                if (QuestItemPrefab != null)
                {
                    options.prefab = QuestItemPrefab;
                }

                options.list = list;
                DataList.SetData(options);
            }

        }

        public void Close()
        {
            Main.instance.ShowQuestWindow(false);
            //Destroy(this.gameObject);
        }

        public void ClaimQuest(QuestItem questItem)
        {
            QuestManager.Quest quest = questItem.GetQuest();
            if(quest != null)
            {
                QuestManager.instance.ClaimQuest(quest.index, true);
                StartCoroutine(_ShowRewardClaiming(quest.rewards));
                this.Refresh();
            }
            
        }

        public void GoQuest(QuestItem questItem)
        {
            QuestManager.Quest quest = questItem.GetQuest();
            if (quest != null)
            {

                switch (quest.goal)
                {
                    case QuestManager.QuestGoals.COLLECT_DAILY_REWARDS:
                        Debug.Log("COLLECT_DAILY_REWARDS");
                        Debug.Log("You can add your own logic here!");
                        //LOGIC
                        break;

                    case QuestManager.QuestGoals.COMPLETE_MISSION:
                        Debug.Log("COMPLETE_MISSION");
                        Debug.Log("You can add your own logic here!");
                        //LOGIC
                        break;
                    case QuestManager.QuestGoals.DESTROY_ENEMY:
                        Debug.Log("DESTROY_ENEMY");
                        Debug.Log("You can add your own logic here!");
                        //LOGIC
                        break;
                    case QuestManager.QuestGoals.UPGRADE_HERO:
                        Debug.Log("UPGRADE_HERO");
                        Debug.Log("You can add your own logic here!");
                        //LOGIC
                        break;
                }
            }
        }

        private IEnumerator _ShowRewardClaiming(QuestManager.RewardItem reward)
        {
            if (RewardClaimingPanel && reward != null)
            {
                RewardClaimingPanel.SetActive(true);

                if (reward != null)
                {
                    RewardClaimingIcon.sprite = reward.icon;
                    RewardClaimingCount.text = "x" + reward.count.ToString();
                }

                RewardClaimingPanel.GetComponent<Animator>().Play("clip");
            }
            yield return new WaitForSeconds(3.3f);
            HideRewardClaiming();

            Debug.Log("Reward claimed. You can do your own logic here!");
        }


        public void HideRewardClaiming()
        {
            if (RewardClaimingPanel)
            {
                RewardClaimingPanel.SetActive(false);
            }
        }


    }
}
