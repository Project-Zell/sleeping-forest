using UnityEngine;

[CreateAssetMenu(fileName = "Player Health Channel", menuName = "Event Channel/Player Health")]
public class PlayerHealthChannel : EventChannel<IHealth> { }