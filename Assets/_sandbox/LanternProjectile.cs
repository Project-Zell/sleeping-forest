using UnityEngine;

public class LanternProjectile : MonoBehaviour
{
    [SerializeField] private TrailRenderer _trailRenderer;

    public bool IsActive { get; private set; } = false;
    
    private WeaponStats _weaponStats;
    private float _lifetime;

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _weaponStats.Speed);
        _lifetime += Time.deltaTime;
        if(_lifetime > _weaponStats.Lifespawn)
        {
            PutToSleep();
        }
    }

    public void Initialize(WeaponStats weaponStats)
    {
        _weaponStats = weaponStats;
    }

    public void LaunchProjectile()
    {
        WakeUp();
    }

    private void WakeUp()
    {
        _trailRenderer.enabled = true;
        gameObject.SetActive(true);

        IsActive = true;
    }

    public void PutToSleep()
    {
        _trailRenderer.enabled = false;
        gameObject.SetActive(false);

        IsActive = false;
        _lifetime = 0;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagGlossary.ENEMY))
        {
            if (other.TryGetComponent(out IHealth health))
            {
                health.TakeDamage(GetFinalDamage());
            }
        }
        PutToSleep();
    }

    private float GetFinalDamage()
    {
        return _weaponStats.Damage;
    }
}
