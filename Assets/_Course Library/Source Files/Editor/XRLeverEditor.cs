using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(XRLever))]
public class XRLeverEditor : UnityEditor.Editor
{
    private SerializedProperty handle;
    private SerializedProperty defaultValue;
    private SerializedProperty onLeverActivate;
    private SerializedProperty onLeverDeactivate;

    private void OnEnable()
    {
        handle = serializedObject.FindProperty("handle");
        defaultValue = serializedObject.FindProperty("defaultValue");
        onLeverActivate = serializedObject.FindProperty("OnLeverActivate");
        onLeverDeactivate = serializedObject.FindProperty("OnLeverDeactivate");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Lever Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(handle);
        EditorGUILayout.PropertyField(defaultValue);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Lever Events", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(onLeverActivate);
        EditorGUILayout.PropertyField(onLeverDeactivate);

        serializedObject.ApplyModifiedProperties();
    }
}
