using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    [SerializeField] private float additionalMovementSpeed = 0f;
    [SerializeField] private float additionalAttackDamage = 0f;
    [SerializeField] private float additionalBulletSpeed = 0f;

    public float GetMovementSpeed() => additionalMovementSpeed;
    public float GetAttackDamage() => additionalAttackDamage;
    public float GetBulletSpeed() => additionalBulletSpeed;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void ModifyMovementSpeed(float amount)
    {
        additionalMovementSpeed += amount
;
    }
    public void ModifyAttackDamage(float amount)
    {
        additionalAttackDamage += amount
;
    }
    public void ModifyBulletSpeed(float amount)
    {
        additionalBulletSpeed += amount
;
    }
}