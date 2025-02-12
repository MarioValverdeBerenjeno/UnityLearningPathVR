using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(XRButton))]
public class XRButtonEditor : UnityEditor.Editor
{
    private SerializedProperty buttonTransform;
    private SerializedProperty pressDistance;
    private SerializedProperty onPress;
    private SerializedProperty onRelease;

    private void OnEnable()
    {
        buttonTransform = serializedObject.FindProperty("buttonTransform");
        pressDistance = serializedObject.FindProperty("pressDistance");
        onPress = serializedObject.FindProperty("OnPress");
        onRelease = serializedObject.FindProperty("OnRelease");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Button Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(buttonTransform);
        EditorGUILayout.PropertyField(pressDistance);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Button Events", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(onPress);
        EditorGUILayout.PropertyField(onRelease);

        serializedObject.ApplyModifiedProperties();
    }
}
