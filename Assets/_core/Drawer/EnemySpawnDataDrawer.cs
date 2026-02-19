using Coollel.Stephen;
using UnityEditor;
using UnityEngine;
using static EnemyWave;

[CustomPropertyDrawer(typeof(EnemyDataContainer))]
public class EnemySpawnDataDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var enemyProp = property.FindPropertyRelative("_enemy");
        if (enemyProp != null && enemyProp.objectReferenceValue is BaseEnemy enemy)
        {
            label.text = enemy.name;
            label.text = label.text.Replace("[Enemy]", "");
        }
        else
        {
            label.text = "???";
        }
        EditorGUI.PropertyField(position, property, label, true);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }
}