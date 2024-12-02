using UnityEngine;

public class LaserLine : MonoBehaviour
{
    public LineRenderer lineRenderer; // ������Ⱦ��
    public float laserLength = 100f;  // �������󳤶�
    public LayerMask hitLayer;        // ������ײ��

    void Start()
    {
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        // ���� LineRenderer
        lineRenderer.positionCount = 2;  // ����ֻ�������㣺�����յ�
        lineRenderer.startWidth = 0.5f;  // ������
        lineRenderer.endWidth = 0.5f;    // ������
        lineRenderer.material = new Material(Shader.Find("Unlit/Color")); // ���ò���Ϊ Unlit
        lineRenderer.startColor = Color.red; // ���ü�����ɫ
        lineRenderer.endColor = Color.red;   // ���ü�����ɫ
    }

    void Update()
    {
        // ��ȡ��������
        Vector3 startPoint = transform.position;

        // ���㼤��ķ���
        Vector3 laserDirection = transform.forward;

        // ���㼤����յ�
        RaycastHit hit;
        Vector3 endPoint = startPoint + laserDirection * laserLength; // Ĭ�ϼ�����󳤶�

        // �������߲�����Ƿ���������ײ
        if (Physics.Raycast(startPoint, laserDirection, out hit, laserLength, hitLayer))
        {
            // ����������壬�յ�Ϊ��ײ��
            endPoint = hit.point;
        }

        // ���� LineRenderer �������յ�
        lineRenderer.SetPosition(0, startPoint); // ���
        lineRenderer.SetPosition(1, endPoint);   // �յ�
    }
}
