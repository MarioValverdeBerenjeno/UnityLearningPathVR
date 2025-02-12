using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(XRKnob))]
public class XRKnobEditor : UnityEditor.Editor
{
    private SerializedProperty knobTransform;
    private SerializedProperty minimum;
    private SerializedProperty maximum;
    private SerializedProperty defaultValue;
    private SerializedProperty onValueChange;

    private void OnEnable()
    {
        knobTransform = serializedObject.FindProperty("knobTransform");
        minimum = serializedObject.FindProperty("minimum");
        maximum = serializedObject.FindProperty("maximum");
        defaultValue = serializedObject.FindProperty("defaultValue");
        onValueChange = serializedObject.FindProperty("OnValueChange");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Knob Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(knobTransform);
        EditorGUILayout.PropertyField(minimum);
        EditorGUILayout.PropertyField(maximum);
        EditorGUILayout.PropertyField(defaultValue);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Knob Event", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(onValueChange);

        serializedObject.ApplyModifiedProperties();
    }
}
