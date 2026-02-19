using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    [SerializeField] private DamagePopupChannel _eventChannel;
    [SerializeField] private DamagePopupInstance _prefab;
    private List<DamagePopupInstance> _popupPool = new();

    private void OnEnable()=> _eventChannel.Subscribe(RequestNewPopup);
    private void OnDisable()=> _eventChannel.Unsubscribe(RequestNewPopup);

    public void RequestNewPopup(DamagePopupContainer container)
    {
        var instance = _popupPool.FirstOrDefault(instance => !instance.gameObject.activeSelf);
        if (instance == null)
        {
            instance = Instantiate(_prefab, transform);
            instance.Initialize();
            _popupPool.Add(instance);
        }
        instance.SetPosition(container.Position);
        instance.Activate(container.Damage);
    }
}
