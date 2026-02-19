using UnityEditor;
using UnityEngine;
using static CharacterUnitStatsSO;

[CustomPropertyDrawer(typeof(StatStarter))]
public class StatDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var typeProp = property.FindPropertyRelative("Type");
        label = new GUIContent(typeProp.enumDisplayNames[typeProp.enumValueIndex]);
        EditorGUI.PropertyField(position, property, label, true);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }
}