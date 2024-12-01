using UnityEngine;

public class LineDraw : MonoBehaviour
{
    public LineRenderer lineRenderer; // LineRenderer ���
    public PositionRecorder positionRecorder; // ���ڼ�¼�켣��λ�ü�¼��
    public bool isReplayMode = false; // �Ƿ���벥��ģʽ���ڶ�������
    public Transform player;
    public Transform shadowObject;
    public Transform startPoint; // ���λ��
    public bool isShadow = true;

    void Start()
    {
        // ��ʼ�� LineRenderer ���
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default")); // ʹ��Ĭ�ϲ���
        lineRenderer.startColor = Color.white; // ���������ɫ
        lineRenderer.endColor = Color.white;   // �����յ���ɫ
        lineRenderer.startWidth = 0.1f;        // �����߿�
        lineRenderer.endWidth = 0.1f;          // �����߿�
        lineRenderer.positionCount = 0;        // ��ʼʱ����ʾ�κ�����
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
        // ��ÿ֡�л��ƶ����
        lineRenderer.positionCount = 0;
        for (int i = 0; i < positionRecorder.recordedActions.Length; i++)
        {
            Debug.Log(i);  // ���: (1.0, 2.0, 3.0)
            if (positionRecorder.recordedActions[i] == null) break;
            if (isShadow)
            {
                drawPosition = positionRecorder.recordedActions[i].position - startPoint.position + player.position;
            }
            else
            {
                drawPosition = -(positionRecorder.recordedActions[i].position - startPoint.position) + player.position;
            }

                // ���㵱ǰ���λ��
                lineRenderer.positionCount++;
            if(i%20<10)lineRenderer.SetPosition(lineRenderer.positionCount-1 , drawPosition);
        }
        

    }
}

