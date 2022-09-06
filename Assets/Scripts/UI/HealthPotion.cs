using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    Models.HealthPotion model;

    private void Start()
    {
        model = new Models.HealthPotion();
    }

    public float GetHeal()
    {
        return model.Heal;
    }
}
