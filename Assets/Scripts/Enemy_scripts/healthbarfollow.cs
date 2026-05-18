using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarFollower : MonoBehaviour
{
    public Transform target;  // 拖拽目标（敌人或玩家）
    public Vector3 offset = new Vector3(0, 2, 0);
    public bool faceCamera = true;  // 玩家设 false，敌人设 true

    void LateUpdate()
    {
        if (target != null && Camera.main != null)
        {
            // 跟随目标位置 + 偏移
            transform.position = target.position + offset;
            Debug.Log($"血条位置：{transform.position}，摄像机位置：{Camera.main.transform.position}");
            
            // 只有敌人需要面向摄像机
            if (faceCamera)
            {
                transform.LookAt(Camera.main.transform);
                transform.Rotate(0, 180, 0);
            }
        }
    }
}
