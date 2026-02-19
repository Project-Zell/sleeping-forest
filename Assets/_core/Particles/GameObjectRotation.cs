using DG.Tweening;
using UnityEngine;

public class GameObjectRotation : MonoBehaviour
{
    public enum Direction { Clockwise, Anticlockwise }

    [SerializeField] private float _timeToFullRotation;
    [SerializeField] private Direction _direction;
    [SerializeField] private bool _playOnAwake;

    public void Start()
    {
        if (_playOnAwake is false)
            return;

        var direction = _direction is Direction.Clockwise ? 360 : -360;

        transform.DOLocalRotate(new Vector3(0, direction, 0), _timeToFullRotation, mode: RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1);
    }
}
