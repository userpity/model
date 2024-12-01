using UnityEngine;

public class LineDraw : MonoBehaviour
{
    public LineRenderer lineRenderer; // LineRenderer 组件
    public PositionRecorder positionRecorder; // 用于记录轨迹的位置记录器
    public bool isReplayMode = false; // 是否进入播放模式（第二条命）
    public Transform player;
    public Transform shadowObject;
    public Transform startPoint; // 起点位置
    public bool isShadow = true;

    void Start()
    {
        // 初始化 LineRenderer 组件
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default")); // 使用默认材质
        lineRenderer.startColor = Color.white; // 设置起点颜色
        lineRenderer.endColor = Color.white;   // 设置终点颜色
        lineRenderer.startWidth = 0.1f;        // 设置线宽
        lineRenderer.endWidth = 0.1f;          // 设置线宽
        lineRenderer.positionCount = 0;        // 初始时不显示任何线条
    }

    void FixedUpdate()
    {
        if (isReplayMode)
        {
            UpdatePath();
        }
        else {
            lineRenderer.positionCount = 0;
        }

    }

    void UpdatePath()
    {
        Vector3 drawPosition;
        // 在每帧中绘制多个点
        lineRenderer.positionCount = 0;
        for (int i = 0; i < positionRecorder.recordedActions.Length; i++)
        {
            Debug.Log(i);  // 输出: (1.0, 2.0, 3.0)
            if (positionRecorder.recordedActions[i] == null) break;
            if (isShadow)
            {
                drawPosition = positionRecorder.recordedActions[i].position - startPoint.position + player.position;
            }
            else
            {
                drawPosition = -(positionRecorder.recordedActions[i].position - startPoint.position) + player.position;
            }

                // 计算当前点的位置
                lineRenderer.positionCount++;
            if(i%20<10)lineRenderer.SetPosition(lineRenderer.positionCount-1 , drawPosition);
        }
        

    }
}

