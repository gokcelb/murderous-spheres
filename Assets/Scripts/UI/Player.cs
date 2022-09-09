using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI health;
    public AudioClip healSound;
    public new AudioSource audio;
    private Models.Player model;

    private void Awake()
    {
        model = new  Models.Player();
        audio = GetComponent<AudioSource>();
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

        if (other.gameObject.CompareTag("HealthPotion"))
        {
            model.Heal(GetHealthPotionHeal(other.gameObject));
            audio.PlayOneShot(healSound, 0.5F);
        }
    }

    private float GetProjectileDamage(GameObject otherGameObject)
    {
        Projectile projectileScript = otherGameObject
            .GetComponent(typeof(Projectile)) as Projectile;
        return projectileScript.GetDamage();
    }

    private float GetHealthPotionHeal(GameObject otherGameObject)
    {
        HealthPotion healthPotionScript = otherGameObject
            .GetComponent(typeof(HealthPotion)) as HealthPotion;
        return healthPotionScript.GetHeal();
    }

    private void TriggerGameOver()
    {
        GameManager gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManagerScript.GameOver();
    }
}
