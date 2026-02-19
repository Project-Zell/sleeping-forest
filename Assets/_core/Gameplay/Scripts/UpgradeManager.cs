using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private CharacterUnit _character;    
    private List<BasicStatUpgradeTree> _upgradesTrees = new();

    private void Start() => PopulateUpgrades(_character.GetUpgradeTrees());

    public List<BasicStatUpgradeTree> GetLevelUpOptions(int choisesCount)
    {
        var levelUpChoises = new List<BasicStatUpgradeTree>();

        var random = new System.Random();
        levelUpChoises = _upgradesTrees.Where(upgrade => upgrade.IsAvailableForUpgrade).OrderBy(upgrade => random.Next()).Take(choisesCount).ToList();
        return levelUpChoises;
    }

    public void PopulateUpgrades(List<BasicStatUpgradeTreeSO> trees)
    {
        _upgradesTrees = new();
        foreach (var tree in trees)
        {
            var characterStat = _character.Stats.GetStat(tree.Stat);
            _upgradesTrees.Add(new BasicStatUpgradeTree(tree, characterStat));
        }
    }

    public void Upgrade(BasicStatUpgradeTree tree)
    {
        if (tree.IsAvailableForUpgrade is false)
            return;

        tree.RiseTier();
    }
}