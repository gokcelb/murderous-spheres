using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject projectile;

    private float creationTime;
    private const float shootingInterval = 1f;

    private void Awake()
    {
        creationTime = Time.time;
    }

    void Start()
    {
        InvokeRepeating("CreateProjectile", creationTime, shootingInterval);
    }

    void CreateProjectile()
    {
        Instantiate(projectile, transform.position, projectile.transform.rotation);
    }
}
