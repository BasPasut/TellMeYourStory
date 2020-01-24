using UnityEditor;
using UnityEngine;
using System;

[CustomEditor(typeof(Trigger))]
public class TriggerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var trigger = target as Trigger;
        EditorGUILayout.PrefixLabel("Trigger Type");
        trigger.type = (TriggerType)EditorGUILayout.EnumPopup(trigger.type);

        using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(trigger.type == TriggerType.Action)))
        {            
            if (group.visible == true)
            {
                EditorGUI.indentLevel++;              
                EditorGUILayout.PrefixLabel("Perform Object");
                trigger.obj = (GameObject)EditorGUILayout.ObjectField(trigger.obj, typeof(GameObject), false);
                EditorGUI.indentLevel--;
            }
        }
    }
    
}
