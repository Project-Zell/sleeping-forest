using UnityEngine;

public class TorchManager : WeaponManagerBase
{
    private Torch torch;

    private void Awake()
    {
        // Get the Torch component attached to the same GameObject or as a child.
        torch = GetComponentInChildren<Torch>();
        if (torch == null)
        {
            Debug.LogError("TorchManager could not find a Torch component.");
        }
    }

    public override void Attack()
    {
        base.Attack();
        if (torch != null)
        {
            torch.PerformAttack();
        }
        else
        {
            Debug.LogWarning("Torch reference is missing in TorchManager.");
        }
    }
}
