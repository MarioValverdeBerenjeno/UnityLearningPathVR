using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(XRJoystick))]
public class XRJoystickEditor : UnityEditor.Editor
{
    private SerializedProperty rateOfChange;
    private SerializedProperty leverType;
    private SerializedProperty handle;
    private SerializedProperty onXValueChange;
    private SerializedProperty onYValueChange;

    private void OnEnable()
    {
        rateOfChange = serializedObject.FindProperty("rateOfChange");
        leverType = serializedObject.FindProperty("leverType");
        handle = serializedObject.FindProperty("handle");
        onXValueChange = serializedObject.FindProperty("OnXValueChange");
        onYValueChange = serializedObject.FindProperty("OnYValueChange");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Joystick Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(rateOfChange);
        EditorGUILayout.PropertyField(leverType);
        EditorGUILayout.PropertyField(handle);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Joystick Events", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(onXValueChange);
        EditorGUILayout.PropertyField(onYValueChange);

        serializedObject.ApplyModifiedProperties();
    }
}
