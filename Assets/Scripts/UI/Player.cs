using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Models.Player model;

    private void Awake()
    {
        model = new  Models.Player();
    }

    private void Update()
    {
        if (model.Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyProjectile"))
        {
            model.TakeDamage(GetProjectileDamage(other.gameObject));
            Destroy(other.gameObject);
        }
    }

    private float GetProjectileDamage(GameObject otherGameObject)
    {
        Projectile projectileScript = otherGameObject.GetComponent("Projectile") as Projectile;
        return projectileScript.GetDamage();
    }
}
