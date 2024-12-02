using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject targetObject;  // Ŀ������
    public float moveAngle = 0f;     // �ƶ��Ƕȣ���λΪ��
    public float moveSpeed = 5f;     // �ƶ��ٶȣ���λΪ��λ/��
    public float moveDistance = 10f; // �ƶ����룬��λΪ��λ

    private Vector3 originalPosition; // �����ԭʼλ��
    private float distanceTraveled = 0f; // �������ƶ��ľ���
    private bool hasMoved = false;  // �Ƿ��Ѿ��������ƶ�

    void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("Target object is not assigned.");
            return;
        }

        originalPosition = targetObject.transform.position; // �����ʼλ��
    }

    void Update()
    {
        if (hasMoved)
        {
            // ����Ѿ��������ƶ����ͼ����ƶ�����
            if (distanceTraveled < moveDistance)
            {
                // �����ƶ�����ĵ�λ����
                float angleRad = moveAngle * Mathf.Deg2Rad; // ���Ƕ�ת��Ϊ����
                Vector3 direction = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad), 0f); // ������2Dƽ���ƶ��������3D��z��Ҳ���Լ������

                // �ƶ�����
                float moveAmount = moveSpeed * Time.deltaTime;
                targetObject.transform.position += direction * moveAmount;
                distanceTraveled += moveAmount;

                // ȷ�����岻�ᳬ��ָ�����ƶ�����
                if (distanceTraveled > moveDistance)
                {
                    targetObject.transform.position = originalPosition + direction * moveDistance;
                }
            }
        }
    }

    // �ⲿ���ô˺�������������ƶ�
    public void StartMove()
    {
        if (!hasMoved)
        {
            hasMoved = true; // ����Ѿ��������ƶ�
            distanceTraveled = 0f; // �������ƶ��ľ���
            targetObject.transform.position = originalPosition; // ��������λ��
        }
    }

    // ���Ե����������������λ�ú�״̬
    public void ResetMovement()
    {
        targetObject.transform.position = originalPosition;
        distanceTraveled = 0f;
        hasMoved = false; // ���ô���״̬
    }
}
