using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoppraGames
{
    public class Main : MonoBehaviour
    {
        public static Main instance;

        public GameObject MainMenu;
        public DailyRewardsWindow DailyRewardsWindow;
        public QuestWindow QuestWindow;
        public SpinWheelController SpinWheelWindow;


        void Awake()
        {
            instance = this;

            ShowDailyRewardsWindow(false);
            ShowQuestWindow(false);
            ShowSpinWheelWindow(false);
            ShowMainMenu(true);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnClickDailyRewardsButton()
        {
            ShowDailyRewardsWindow(true);
            ShowQuestWindow(false);
            ShowSpinWheelWindow(false);
            ShowMainMenu(false);
        }

        public void OnClickQuestButton()
        {
            ShowQuestWindow(true);
            ShowDailyRewardsWindow(false);
            ShowSpinWheelWindow(false);
            ShowMainMenu(false);
        }

        public void OnClickSpinwheelButton()
        {
            ShowQuestWindow(false);
            ShowDailyRewardsWindow(false);
            ShowSpinWheelWindow(true);
            ShowMainMenu(false);
        }


        public void ShowMainMenu(bool isTrue)
        {
            if (MainMenu)
            {
                MainMenu.gameObject.SetActive(isTrue);
            }
        }



        //DAILY REWARDS OPTIONS
        public void ShowDailyRewardsWindow(bool isTrue)
        {
            if (DailyRewardsWindow)
            {
                DailyRewardsWindow.gameObject.SetActive(isTrue);

                if (isTrue)
                    DailyRewardsWindow.Init();
                else
                    ShowMainMenu(true);
            }
        }

        public void OnClickResetDailyRewardsButton()
        {
            PlayerPrefs.DeleteAll();
            DailyRewardsWindow.Init();
        }

        public void OnClickNextButton()
        {
            int currentDay = DailyRewardsWindow.GetDaysSinceSignUp();
            var signTime = DateTime.Now - new TimeSpan((currentDay + 1) * 24, 0, 0);
            PlayerPrefs.SetString("sign_up_time", signTime.ToString());
            DailyRewardsWindow.Init();
        }


        //QUESTS OPTIONS
        public void ShowQuestWindow(bool isTrue)
        {
            if (QuestWindow)
            {
                QuestWindow.gameObject.SetActive(isTrue);

                if (isTrue)
                    QuestWindow.Init();
                else
                    ShowMainMenu(true);
            }
        }

        public void OnClickFinishMission()
        {
            QuestManager.instance.OnAchieveQuestGoal(QuestManager.QuestGoals.COMPLETE_MISSION);
        }

        public void OnClickUpgradeHero()
        {
            QuestManager.instance.OnAchieveQuestGoal(QuestManager.QuestGoals.UPGRADE_HERO);
        }

        public void OnClickKillEnemy()
        {
            QuestManager.instance.OnAchieveQuestGoal(QuestManager.QuestGoals.DESTROY_ENEMY);
        }

        public void OnClickCollectDailyRewards()
        {
            ShowDailyRewardsWindow(true);
        }

        public void OnClickResetQuest()
        {
            QuestManager.instance.ResetAllDailyQuests();
        }

        //SPINWHEEL OPTIONS
        public void ShowSpinWheelWindow(bool isTrue)
        {
            if (SpinWheelWindow)
            {
                SpinWheelWindow.gameObject.SetActive(isTrue);

                if (isTrue)
                    SpinWheelWindow.Init();
                else
                    ShowMainMenu(true);
            }
        }

    }
}