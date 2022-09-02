using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private const float speed = 30f;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Destroyable(other.gameObject))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    bool Destroyable(GameObject otherGameObject)
    {
        bool playerShootingEnemy = gameObject.CompareTag("PlayerProjectile") && otherGameObject.CompareTag("Enemy");
        bool enemyShootingPlayer = gameObject.CompareTag("EnemyProjectile") && otherGameObject.CompareTag("Player");
        return playerShootingEnemy || enemyShootingPlayer;
    }
}
