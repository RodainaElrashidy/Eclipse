#if UNITY_EDITOR
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(Quest))]
public class QuestEditor : Editor
{
    private SerializedProperty nameProp;
    private SerializedProperty goalsProp;
    private SerializedProperty onQuestCompleteProp;

    private void OnEnable()
    {
        nameProp = serializedObject.FindProperty("name");
        goalsProp = serializedObject.FindProperty("Goals");
        onQuestCompleteProp = serializedObject.FindProperty("OnQuestComplete");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.LabelField("Quest Details", EditorStyles.boldLabel);

        EditorGUILayout.PropertyField(nameProp);
        EditorGUILayout.PropertyField(onQuestCompleteProp);

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Quest Goals", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;

        EditorGUILayout.PropertyField(goalsProp, true);

        EditorGUI.indentLevel--;

        serializedObject.ApplyModifiedProperties();
    }
}
#endif
