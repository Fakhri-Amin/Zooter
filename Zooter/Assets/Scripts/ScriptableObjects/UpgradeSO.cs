using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UpgradeSO")]
public class UpgradeSO : ScriptableObject
{
    public int Id;
    public string DescriptionText;
    public float MovementSpeedPercentage;
    public float AttackDamagePercentage;
    public float BulletSpeedPercentage;
}