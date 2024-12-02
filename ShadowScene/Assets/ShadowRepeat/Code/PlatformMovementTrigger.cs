using UnityEngine;

public class PlatformMovementTrigger : MonoBehaviour
{
    // Ŀ��ƽ̨
    public GameObject platform;
    // �ƶ�����
    public float moveDistance = 5f;      // �ƶ��ľ���
    public float moveSpeed = 3f;         // �ƶ����ٶ�
    public float returnSpeed = 1f;       // ����ԭλ���ٶ�
    public float moveAngle = 45f;        // �ƶ��ĽǶȣ������X�ᣩ

    private Vector3 originalPosition;    // ƽ̨ԭʼλ��
    private Vector3 targetPosition;      // ƽ̨Ŀ��λ��
    private bool isMoving = false;       // �Ƿ������ƶ�
    private bool isReturning = false;    // �Ƿ��ڵ���ԭλ
    private float angleInRadians;        // �Ƕ�תΪ����

    // ������ñ�־λ
    private bool isResetting = false;    // �Ƿ�����ƽ̨

    private void Start()
    {
        // ����ƽ̨�ĳ�ʼλ��
        if (platform != null)
        {
            originalPosition = platform.transform.position;
            // ���Ƕ�ת��Ϊ����
            angleInRadians = moveAngle * Mathf.Deg2Rad;

            // ����Ŀ��λ�ã�����ָ���ǶȺ;��룩
            targetPosition = originalPosition + new Vector3(Mathf.Cos(angleInRadians) * moveDistance, Mathf.Sin(angleInRadians) * moveDistance, 0f);
        }
    }

    private void Update()
    {
        // ���ƽ̨�����ƶ�
        if (isMoving)
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // ���ƽ̨�ﵽ��Ŀ��λ�ã�ֹͣ�ƶ�
            if (platform.transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
        // ���ƽ̨�ڻָ�λ��
        else if (isReturning)
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, originalPosition, returnSpeed * Time.deltaTime);

            // ���ƽ̨�ָ���ԭʼλ�ã�ֹͣ�ָ�
            if (platform.transform.position == originalPosition)
            {
                isReturning = false;
            }
        }
        // �����������ƽ̨
        else if (isResetting)
        {
            // ����ƽ̨λ��
            platform.transform.position = originalPosition;
            isResetting = false;
        }
    }

    // ������봥�����Ӵ�ʱ����ʼƽ̨���ƶ�
    private void OnTriggerEnter(Collider other)
    {
        // �����ҵı�ǩ������
        if (other.CompareTag("Players"))
        {
            isMoving = true;
            isReturning = false;  // ֹͣ�ָ�
            isResetting = false;  // ֹͣ����
        }
    }

    // ������뿪������ʱ����ʼ��ƽ̨��������ԭλ
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Players"))
        {
            isReturning = true;
            isMoving = false;  // ֹͣ�ƶ�
            isResetting = false;  // ֹͣ����
        }
    }

    // ��������ƽ̨λ��
    public void ResetMovement()
    {
        isResetting = true;
        isMoving = false;
        isReturning = false;
    }
}
