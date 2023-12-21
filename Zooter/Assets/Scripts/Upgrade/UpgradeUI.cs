using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using Unity.Mathematics;
using static GateSceneManager;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform upgradeCardTemplate;

    private void Awake()
    {
        upgradeCardTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        UpgradeSystem.Instance.OnUpgradesDisplay += UpgradeSystem_OnUpgradesDisplay;
        Hide();
    }

    private void UpgradeSystem_OnUpgradesDisplay()
    {
        UpdateVisual();
        Show();
    }

    private void UpdateVisual()
    {
        foreach (Transform child in container)
        {
            if (child == upgradeCardTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach (UpgradeSO upgradeSO in UpgradeSystem.Instance.GetUpgradeSOList())
        {
            Transform upgradeTransform = Instantiate(upgradeCardTemplate, container);
            upgradeTransform.gameObject.SetActive(true);
            upgradeTransform.GetComponent<UpgradeSingleUI>().SetUpgradeSO(upgradeSO);
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }


}
