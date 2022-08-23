//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Quest))]
public class QuestSystemEditor : Editor
{
    private Quest QuestScript;

    SerializedProperty GoalList;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        QuestScript = (Quest)target;

        if(GUILayout.Button("Start Quest"))
        {
            QuestScript.StartQuest();
        }

        //EditorGUILayout.HelpBox("This is a Help Box", MessageType.Info);
    }

    [MenuItem("Tools /Quest #Q")]
    public static void Quest()
    {
        var newQuest = CreateInstance<Quest>();

        ProjectWindowUtil.CreateAsset(newQuest, pathName:"assets/data/quests/quest.asset");
    }
}
