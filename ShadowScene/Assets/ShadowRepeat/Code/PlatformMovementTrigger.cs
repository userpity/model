using UnityEngine;

public class PlatformMovementTrigger : MonoBehaviour
{
    // 目标平台
    public GameObject platform;
    // 移动参数
    public float moveDistance = 5f;      // 移动的距离
    public float moveSpeed = 3f;         // 移动的速度
    public float returnSpeed = 1f;       // 弹回原位的速度
    public float moveAngle = 45f;        // 移动的角度（相对于X轴）

    private Vector3 originalPosition;    // 平台原始位置
    private Vector3 targetPosition;      // 平台目标位置
    private bool isMoving = false;       // 是否正在移动
    private bool isReturning = false;    // 是否在弹回原位
    private float angleInRadians;        // 角度转为弧度

    // 添加重置标志位
    private bool isResetting = false;    // 是否重置平台

    private void Start()
    {
        // 保存平台的初始位置
        if (platform != null)
        {
            originalPosition = platform.transform.position;
            // 将角度转换为弧度
            angleInRadians = moveAngle * Mathf.Deg2Rad;

            // 计算目标位置（沿着指定角度和距离）
            targetPosition = originalPosition + new Vector3(Mathf.Cos(angleInRadians) * moveDistance, Mathf.Sin(angleInRadians) * moveDistance, 0f);
        }
    }

    private void Update()
    {
        // 如果平台正在移动
        if (isMoving)
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // 如果平台达到了目标位置，停止移动
            if (platform.transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
        // 如果平台在恢复位置
        else if (isReturning)
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, originalPosition, returnSpeed * Time.deltaTime);

            // 如果平台恢复到原始位置，停止恢复
            if (platform.transform.position == originalPosition)
            {
                isReturning = false;
            }
        }
        // 如果正在重置平台
        else if (isResetting)
        {
            // 重置平台位置
            platform.transform.position = originalPosition;
            isResetting = false;
        }
    }

    // 当玩家与触发器接触时，开始平台的移动
    private void OnTriggerEnter(Collider other)
    {
        // 检测玩家的标签或名字
        if (other.CompareTag("Players"))
        {
            isMoving = true;
            isReturning = false;  // 停止恢复
            isResetting = false;  // 停止重置
        }
    }

    // 当玩家离开触发器时，开始让平台缓慢返回原位
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Players"))
        {
            isReturning = true;
            isMoving = false;  // 停止移动
            isResetting = false;  // 停止重置
        }
    }

    // 触发重置平台位置
    public void ResetMovement()
    {
        isResetting = true;
        isMoving = false;
        isReturning = false;
    }
}
