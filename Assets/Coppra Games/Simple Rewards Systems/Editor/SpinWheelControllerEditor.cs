using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CoppraGames
{
    [CustomEditor(typeof(SpinWheelController))]
    public class SpinWheelControllerEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            SpinWheelController myTarget = (SpinWheelController)target;

            DrawDefaultInspector();
            serializedObject.Update();
            if (GUILayout.Button("Apply"))
            {
                myTarget.ApplyValues();
            }
        }
    }
}


