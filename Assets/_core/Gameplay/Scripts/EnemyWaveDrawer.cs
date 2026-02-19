using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(EnemyWave))]
public class EnemyWaveDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        label.text = label.text.Replace("Element", "Wave №");
        EditorGUI.PropertyField(position, property, label, true);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }
}
