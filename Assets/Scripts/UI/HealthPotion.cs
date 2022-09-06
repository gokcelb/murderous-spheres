using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public AudioSource healSound;
    Models.HealthPotion model;

    private void Start()
    {
        model = new Models.HealthPotion();
        healSound = GetComponent<AudioSource>();
    }

    public float GetHeal()
    {
        return model.Heal;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            healSound.Play();
            Destroy(gameObject, healSound.clip.length);
        }
    }
}
