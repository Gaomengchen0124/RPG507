using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarFollower : MonoBehaviour
{
    public Transform enemy;  // 拖拽敌人
    public Vector3 offset = new Vector3(0, 1.5f, 0);  // 可调整的偏移量

    void LateUpdate()
    {
        if (enemy != null && Camera.main != null)
        {
            // 跟随敌人位置 + 偏移
            transform.position = enemy.position + offset;
            
            // 朝向摄像机
            transform.LookAt(Camera.main.transform);
            transform.Rotate(0, 180, 0);
        }
    }
}
