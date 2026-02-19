using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Unit Stats", menuName = "Gameplay/Character Unit Stats")]
public class CharacterUnitStatsSO : ScriptableObject
{
    public List<StatStarter> Stats = new();

    [System.Serializable]
    public class StatStarter
    {
        [HideInInspector] public StatType Type;
        [field: SerializeField] public StatStarterType StatStarterType { get; private set; }
        [field: SerializeField] public int Value { get; private set; }

        public StatStarter(StatType type) => Type = type;
    }

    public enum StatStarterType
    {
        Default,
        Dynamic,
    }

    private void OnValidate()
    {
        Stats = Stats.GroupBy(stat => stat.Type).Select(group => group.First()).ToList();

        var currentTypes = Stats.Select(stat => stat.Type.ToString()).ToList();

        var currentEnumNames = Enum.GetNames(typeof(StatType)).ToList();
        var newEntries = currentEnumNames.Except(currentTypes).ToList();

        if (newEntries.Count > 0)
        {
            foreach (string newEntry in newEntries)
            {
                if (Enum.TryParse(newEntry, out StatType parsedType))
                {
                    Stats.Add(new StatStarter(parsedType));
                }
            }
        }
        Stats.RemoveAll(stat => !currentEnumNames.Contains(stat.Type.ToString()));
        Stats = Stats.OrderBy(stat => stat.Type).ToList();
        EditorUtility.SetDirty(this);
    }
}