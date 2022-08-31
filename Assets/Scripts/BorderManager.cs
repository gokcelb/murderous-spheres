using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderManager : MonoBehaviour
{
    private const float horizontalBorder = 15.0f;
    private const float bottomBorder = -30.0f;
    private const float topBorder = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= bottomBorder)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bottomBorder);
        }
        else if (transform.position.z >= topBorder)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, topBorder);
        }

        if (transform.position.x >= horizontalBorder)
        {
            transform.position = new Vector3(horizontalBorder, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -horizontalBorder)
        {
            transform.position = new Vector3(-horizontalBorder, transform.position.y, transform.position.z);
        }
    }
}
