using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LanternWeapon : Weapon
{
    [SerializeField] private LanternProjectile _projectilePrefab;
    [SerializeField] private WeaponBaseSettings _projectileSettings;
    [SerializeField] private Transform _firingPoint;
    
    private bool _isReady = true;

    private List<LanternProjectile> _projectilePool = new();
    private WeaponStats _weaponUpgradedStats;

    private void Start()
    {
        Activate();
    }

    public void Activate()
    {
        IsActive = true;
        CheckLaunch();
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    private void CheckLaunch()
    {
        if (IsActive) LaunchProjectile();
    }

    private void LaunchProjectile()
    {
        _isReady = false;
        PrewarmProjectile();
        StartCoroutine(Cooldown(GetCurrentCooldown()));
    }

    private IEnumerator Cooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        _isReady = true;
        CheckLaunch();
    }

    private int GetCurrentCooldown()
    {
        var cooldown = _projectileSettings.WeaponStats.BaseCooldown;
        return (int)cooldown;
    }

    private void PrewarmProjectile()
    {
        LanternProjectile readyProjectile = _projectilePool.FirstOrDefault(x => x.IsActive is false);
        if (readyProjectile == null)
        {
            readyProjectile = CreateAndReturnNewProjectile();
        }

        readyProjectile.transform.position = _firingPoint.position;
        readyProjectile.transform.rotation = _firingPoint.rotation;

        readyProjectile.Initialize(GetCurrentWeaponStats());

        readyProjectile.LaunchProjectile();
    }

    private LanternProjectile CreateAndReturnNewProjectile()
    {
        LanternProjectile projectile = Instantiate(_projectilePrefab);
        _projectilePool.Add(projectile);

        projectile.PutToSleep();

        return projectile;
    }

    private WeaponStats GetCurrentWeaponStats()
    {
        var weaponStats = new WeaponStats(playerStats: _playerStats, weaponBaseStats: _projectileSettings.WeaponStats);
        return weaponStats;
    }

}
