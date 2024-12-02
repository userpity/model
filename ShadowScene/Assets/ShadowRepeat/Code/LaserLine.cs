using UnityEngine;

public class LaserLine : MonoBehaviour
{
    public LineRenderer lineRenderer; // 线条渲染器
    public float laserLength = 100f;  // 激光的最大长度
    public LayerMask hitLayer;        // 激光碰撞层

    void Start()
    {
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        // 配置 LineRenderer
        lineRenderer.positionCount = 2;  // 激光只有两个点：起点和终点
        lineRenderer.startWidth = 0.5f;  // 激光宽度
        lineRenderer.endWidth = 0.5f;    // 激光宽度
        lineRenderer.material = new Material(Shader.Find("Unlit/Color")); // 设置材质为 Unlit
        lineRenderer.startColor = Color.red; // 设置激光颜色
        lineRenderer.endColor = Color.red;   // 设置激光颜色
    }

    void Update()
    {
        // 获取激光的起点
        Vector3 startPoint = transform.position;

        // 计算激光的方向
        Vector3 laserDirection = transform.forward;

        // 计算激光的终点
        RaycastHit hit;
        Vector3 endPoint = startPoint + laserDirection * laserLength; // 默认激光最大长度

        // 发射射线并检测是否与物体碰撞
        if (Physics.Raycast(startPoint, laserDirection, out hit, laserLength, hitLayer))
        {
            // 如果碰到物体，终点为碰撞点
            endPoint = hit.point;
        }

        // 设置 LineRenderer 的起点和终点
        lineRenderer.SetPosition(0, startPoint); // 起点
        lineRenderer.SetPosition(1, endPoint);   // 终点
    }
}
