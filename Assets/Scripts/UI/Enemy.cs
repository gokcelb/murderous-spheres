using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Enemy : MonoBehaviour
{
    public GameObject projectile;
    private Models.Enemy model;
    private const float shootingStart = 1f;

    private void Awake()
    {
        model = InstantiateModel();
    }

    private void Start()
    {
        InvokeRepeating("CreateProjectile", shootingStart, model.ShootingSpeed);
    }

    private void Update()
    {
        if (model.Health <= 0)
        {
            Destroy(gameObject);
            Models.Score.IncreaseKillByDifficulty(GetDifficulty());
        }
    }

    private void CreateProjectile()
    {
        Instantiate(projectile, transform.position, projectile.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            model.TakeDamage(GetProjectileDamage(other.gameObject));
            Destroy(other.gameObject);
        }
    }

    private Models.Enemy InstantiateModel()
    {
        Models.Enemy enemy = GetDifficulty() switch
        {
            Models.EnemyDifficulty.Easy => new Models.EnemyEasy(),
            Models.EnemyDifficulty.Normal => new Models.EnemyNormal(),
            _ => new Models.EnemyHard(),
        };
        return enemy;
    }

    private Models.EnemyDifficulty GetDifficulty()
    {
        Models.EnemyDifficulty difficulty = PrefabUtility.GetOriginalPrefabName(gameObject.name) switch
        {
            "EnemyEasy" => Models.EnemyDifficulty.Easy,
            "EnemyNormal" => Models.EnemyDifficulty.Normal,
            _ => Models.EnemyDifficulty.Hard,
        };
        return difficulty;
    }

    private float GetProjectileDamage(GameObject otherGameObject)
    {
        Projectile projectileScript = otherGameObject.GetComponent(typeof(Projectile)) as Projectile;
        return projectileScript.GetDamage();
    }
}
