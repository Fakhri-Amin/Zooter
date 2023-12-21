using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public static UpgradeSystem Instance;

    public event Action OnUpgradesDisplay;

    [SerializeField] private int maxUpgradeDisplay = 3;
    [SerializeField] private List<UpgradeSO> upgradeSOList;

    private Dictionary<int, UpgradeSO> upgradeSODict = new();

    private void Awake()
    {
        Instance = this;
    }

    public void DisplayUpgrades()
    {
        upgradeSODict.Clear();
        while (upgradeSODict.Count < maxUpgradeDisplay)
        {
            UpgradeSO upgradeSO = upgradeSOList[UnityEngine.Random.Range(0, upgradeSOList.Count)];
            if (upgradeSODict.ContainsKey(upgradeSO.Id))
            {
                continue;
            }
            else
            {
                upgradeSODict.Add(upgradeSO.Id, upgradeSO);
            }
        }
        OnUpgradesDisplay?.Invoke();
    }

    public List<UpgradeSO> GetUpgradeSOList()
    {
        return upgradeSODict.Values.ToList();
    }

    public void ApplyUpgrades(UpgradeSO upgradeSO)
    {
        PlayerStats playerStats = PlayerStats.Instance;
        playerStats.ModifyMovementSpeed(upgradeSO.MovementSpeedPercentage);
        playerStats.ModifyAttackDamage(upgradeSO.AttackDamagePercentage);
        playerStats.ModifyBulletSpeed(upgradeSO.BulletSpeedPercentage);
    }
}