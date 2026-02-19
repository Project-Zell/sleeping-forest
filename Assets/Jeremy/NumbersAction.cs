using UnityEngine;
using UnityEngine.Events;

public static class NumbersAction
{
    public static UnityEvent<int, Vector3> EnemyTakeDamage = new UnityEvent<int, Vector3>();
}