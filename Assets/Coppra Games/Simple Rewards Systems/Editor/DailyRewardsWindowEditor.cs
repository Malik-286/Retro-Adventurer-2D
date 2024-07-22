using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CoppraGames
{
    [CustomEditor(typeof(DailyRewardsWindow))]
    public class DailyRewardsEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            DailyRewardsWindow myTarget = (DailyRewardsWindow)target;

            DrawDefaultInspector();
            serializedObject.Update();
            if (GUILayout.Button("Apply"))
            {
                myTarget.ApplyValues();
            }
        }
    }
}


