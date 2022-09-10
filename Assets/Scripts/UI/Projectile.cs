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
            "EnemyEasyProjectile" => new Models.ProjectileEnemyEasy(),
            "EnemyNormalProjectile" => new Models.ProjectileEnemyNormal(),
            "EnemyHardProjectile" => new Models.ProjectileEnemyHard(),
            _ => new Models.ProjectilePlayer(),
        };
        return projectile;
    }

    public float GetDamage()
    {
        return model.Damage;
    }
}
