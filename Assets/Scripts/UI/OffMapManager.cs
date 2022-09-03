using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffMapManager : MonoBehaviour
{
    private const float horizontalBorder = 30f;
    private const float verticalBorder = 40f;

    private void Update()
    {
        bool offMapHorizontal = transform.position.x >= horizontalBorder || transform.position.x <= -horizontalBorder;
        bool offMapVertical = transform.position.z >= verticalBorder || transform.position.z <= -verticalBorder;

        if (offMapHorizontal || offMapVertical)
        {
            Destroy(gameObject);
        }
    }
}
