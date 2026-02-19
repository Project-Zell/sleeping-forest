using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "Skills")]

public class SkillSO : ScriptableObject
{
    [field: SerializeField] public string skillName { get; private set; }
    [field: SerializeField] public GameObject SkillPrefab { get; private set; }
    [field: SerializeField] public GameObject SkillManagerPrefab { get; private set; }

    public Vector3 spawnOffset;
    public float damage = 1f;
    public float damageOverTime = 5f;
    public float armorReduction = 10f;
    public float movementSpeedReduction = 2f;
    public float speed = 20f;
    public float cooldown = 1f;
    public float lifetime = 5f;
    public bool isActive = false;
    public Vector3 scale;
    [Header("Strike Only Variables")]
    public float attackRadius = 2f;
    public float attackAngle = 90f;
    [Header("Orbit Only Variables")]
    public float radius = 2f;
}
