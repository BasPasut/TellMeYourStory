using UnityEditor;
using UnityEngine;
using System;
using UnityEngine.Playables;

#if UNITY_EDITOR
[CustomEditor(typeof(Trigger))]
public class TriggerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var trigger = target as Trigger;
        EditorGUILayout.PrefixLabel("Trigger Type");
        trigger.triggerType = (TriggerType)EditorGUILayout.EnumPopup(trigger.triggerType);

        using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(trigger.triggerType == TriggerType.Action)))
        {            
            if (group.visible == true)
            {
                EditorGUI.indentLevel++;              
                EditorGUILayout.PrefixLabel("Perform Object");
                trigger.obj = (GameObject)EditorGUILayout.ObjectField(trigger.obj, typeof(GameObject), true);
                EditorGUI.indentLevel--;
            }
        }

        using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(trigger.triggerType == TriggerType.Timeline)))
        {
            if (group.visible == true)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PrefixLabel("Can player move?");
                trigger.CanPlayerMove = EditorGUILayout.Toggle(trigger.CanPlayerMove);
                EditorGUI.indentLevel--;
            }
        }
    }
}
#endif
