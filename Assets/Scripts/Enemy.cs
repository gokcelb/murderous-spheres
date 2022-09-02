using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject projectile;

    private const float shootingInterval = 1f;

    void Start()
    {
        InvokeRepeating("CreateProjectile", Time.time, shootingInterval);
    }

    void CreateProjectile()
    {
        Instantiate(projectile, transform.position, projectile.transform.rotation);
    }
}
