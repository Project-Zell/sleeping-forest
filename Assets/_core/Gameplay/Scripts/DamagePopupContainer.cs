using UnityEngine;

public struct DamagePopupContainer
{
    public Vector3 Position { get; private set; }
    public int Damage { get; private set; } 

    public DamagePopupContainer(Vector3 position, int damage)
    {
        Position = position;
        Damage = damage;
    }
}
