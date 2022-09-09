using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;

    private const float speed = 20f;

    private float horizontalInput;
    private float verticalInput;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // create a projectile
            Instantiate(projectile, transform.position, projectile.transform.rotation);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);
        transform.Translate(speed * Time.deltaTime * verticalInput * Vector3.forward);
    }
}
