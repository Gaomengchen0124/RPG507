using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarFollow : MonoBehaviour
{
    public Transform enemy;
    public Vector3 offset = new Vector3(10.0067f, -14.9603f, 0f);

    void LateUpdate()
    {
        if (enemy != null)
        {
            transform.position = enemy.position + offset;
        }
    }
}
