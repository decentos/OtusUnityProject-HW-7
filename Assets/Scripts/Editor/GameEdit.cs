using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Needed))]
[CanEditMultipleObjects]
public class LookAtPointEditor : Editor
{
    private SerializedProperty lookAtPoint;
    private SerializedProperty targetInerface;

    void OnEnable()
    {
        lookAtPoint = serializedObject.FindProperty("Target");
        //targetInerface = serializedObject.FindProperty("TargetInerface");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(lookAtPoint);
        //EditorGUILayout.PropertyField(targetInerface);
        var o = ((Needed)serializedObject.targetObject).TargetInerface;
        //var o = serializedObject.targetObject.GetType().GetProperty("Target")
        //    .GetValue(serializedObject);
        serializedObject.ApplyModifiedProperties();
        EditorGUILayout.LabelField("Текст = " + o);
        EditorGUILayout.ColorField(Color.red);
    }
}
