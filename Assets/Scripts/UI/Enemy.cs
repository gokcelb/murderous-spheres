using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Enemy : MonoBehaviour
{
    public GameObject projectile;
    private Models.Enemy model;

    private void Awake()
    {
        model = InstantiateModel();
    }

    private void Start()
    {
        InvokeRepeating("CreateProjectile", Time.time, model.ShootingSpeed);
    }

    private void Update()
    {
        if (model.Health <= 0)
        {
            Destroy(gameObject);
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
        Models.Enemy enemy = PrefabUtility.GetOriginalPrefabName(gameObject.name) switch
        {
            "EnemyEasy" => new Factories.EnemyEasy().Create(),
            "EnemyHard" => new Factories.EnemyHard().Create(),
            _ => new Factories.EnemyNormal().Create(),
        };
        return enemy;
    }

    private float GetProjectileDamage(GameObject otherGameObject)
    {
        Projectile projectileScript = otherGameObject.GetComponent(typeof(Projectile)) as Projectile;
        return projectileScript.GetDamage();
    }
}
