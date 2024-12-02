using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject targetObject;  // 目标物体
    public float moveAngle = 0f;     // 移动角度，单位为度
    public float moveSpeed = 5f;     // 移动速度，单位为单位/秒
    public float moveDistance = 10f; // 移动距离，单位为单位

    private Vector3 originalPosition; // 物体的原始位置
    private float distanceTraveled = 0f; // 物体已移动的距离
    private bool hasMoved = false;  // 是否已经触发过移动

    void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("Target object is not assigned.");
            return;
        }

        originalPosition = targetObject.transform.position; // 保存初始位置
    }

    void Update()
    {
        if (hasMoved)
        {
            // 如果已经触发过移动，就继续移动物体
            if (distanceTraveled < moveDistance)
            {
                // 计算移动方向的单位向量
                float angleRad = moveAngle * Mathf.Deg2Rad; // 将角度转换为弧度
                Vector3 direction = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad), 0f); // 假设是2D平面移动，如果是3D，z轴也可以加入计算

                // 移动物体
                float moveAmount = moveSpeed * Time.deltaTime;
                targetObject.transform.position += direction * moveAmount;
                distanceTraveled += moveAmount;

                // 确保物体不会超出指定的移动距离
                if (distanceTraveled > moveDistance)
                {
                    targetObject.transform.position = originalPosition + direction * moveDistance;
                }
            }
        }
    }

    // 外部调用此函数触发物体的移动
    public void StartMove()
    {
        if (!hasMoved)
        {
            hasMoved = true; // 标记已经触发过移动
            distanceTraveled = 0f; // 重置已移动的距离
            targetObject.transform.position = originalPosition; // 重置物体位置
        }
    }

    // 可以调用这个方法来重置位置和状态
    public void ResetMovement()
    {
        targetObject.transform.position = originalPosition;
        distanceTraveled = 0f;
        hasMoved = false; // 重置触发状态
    }
}
