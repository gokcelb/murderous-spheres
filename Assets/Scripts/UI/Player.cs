using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI health;
    private Models.Player model;

    private void Awake()
    {
        model = new  Models.Player();
        health.text = "Health: " + model.Health;
    }

    private void Update()
    {
        health.text = "Health: " + model.Health;

        if (model.Health <= 0)
        {
            Destroy(gameObject);
            TriggerGameOver();
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
        Projectile projectileScript = otherGameObject.GetComponent(typeof(Projectile)) as Projectile;
        return projectileScript.GetDamage();
    }

    private void TriggerGameOver()
    {
        GameManager gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManagerScript.GameOver();
    }
}
