using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System;
using static GateSceneManager;

public class UpgradeSingleUI : MonoBehaviour
{
    [SerializeField] private GateSceneManager gateSceneManager;
    [SerializeField] private UpgradeUI upgradeUI;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Button button;

    public void SetUpgradeSO(UpgradeSO upgradeSO)
    {
        descriptionText.text = upgradeSO.DescriptionText;
        button.onClick.AddListener(() =>
        {
            ChooseUpgrade(upgradeSO);
        });
    }

    public void ChooseUpgrade(UpgradeSO upgradeSO)
    {
        Time.timeScale = 1;

        // FloatingJoystick.Instance.enabled = true;
        UpgradeSystem.Instance.ApplyUpgrades(upgradeSO);
        gateSceneManager.SwitchSpriteToOpen();
        upgradeUI.Hide();

        GateType gateType = gateSceneManager.GetGateType();
        if (gateType == GateType.Close)
        {
            Invoke(nameof(FadeTransition), 1);
        }
        else if (gateType == GateType.BossGate)
        {
            Invoke(nameof(DoLoadWinCondition), 1);
        }
    }

    private void FadeTransition()
    {
        gateSceneManager.FadeTransition();
    }

    private void DoLoadWinCondition()
    {
        gateSceneManager.LoadWinCondition();
    }
}