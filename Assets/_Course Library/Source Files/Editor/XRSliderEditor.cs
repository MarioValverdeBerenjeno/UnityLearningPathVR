using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(XRSlider))]
public class XRSliderEditor : UnityEditor.Editor
{
    private SerializedProperty handle;
    private SerializedProperty start;
    private SerializedProperty end;
    private SerializedProperty defaultValue;
    private SerializedProperty onValueChange;

    private void OnEnable()
    {
        handle = serializedObject.FindProperty("handle");
        start = serializedObject.FindProperty("start");
        end = serializedObject.FindProperty("end");
        defaultValue = serializedObject.FindProperty("defaultValue");
        onValueChange = serializedObject.FindProperty("OnValueChange");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Slider Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(handle);
        EditorGUILayout.PropertyField(start);
        EditorGUILayout.PropertyField(end);
        EditorGUILayout.PropertyField(defaultValue);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Slider Event", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(onValueChange);

        serializedObject.ApplyModifiedProperties();
    }
}
