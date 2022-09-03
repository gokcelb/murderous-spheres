using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Projectile : MonoBehaviour
{
    private Models.Projectile model;

    private void Awake()
    {
        model = InstantiateModel();
    }

    private void Update()
    {
        transform.Translate(model.Speed * Time.deltaTime * Vector3.forward);
    }

    private Models.Projectile InstantiateModel()
    {
        Models.Projectile projectile = PrefabUtility.GetOriginalPrefabName(gameObject.name) switch
        {
            "EnemyEasyProjectile" => new Factories.EnemyEasyProjectile().Create(),
            "EnemyNormalProjectile" => new Factories.EnemyNormalProjectile().Create(),
            "EnemyHardProjectile" => new Factories.EnemyHardProjectile().Create(),
            _ => new Factories.PlayerProjectile().Create(),
        };
        return projectile;
    }

    public float GetDamage()
    {
        return model.Damage;
    }
}
