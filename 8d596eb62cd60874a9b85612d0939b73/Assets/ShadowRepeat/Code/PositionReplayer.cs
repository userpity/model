using UnityEngine;

public class PositionReplayer : MonoBehaviour
{
    public PositionRecorder positionRecorder; // ���� PositionRecorder�����ڷ��ʼ�¼�Ķ�������
    public float replaySpeed = 1f; // �����طŵ��ٶ�
    private int currentFrame = 0; // ��ǰ���ŵ�֡��
    private bool isReplaying = false; // �Ƿ����ط�

    // ��¶һ�������� GameController ������/ֹͣ�ط�
    public void StartReplay()
    {
        isReplaying = true;
        currentFrame = 0; // ��ͷ��ʼ����
    }

    public void StopReplay()
    {
        isReplaying = false;
    }

    void FixedUpdate()
    {
        // ��������طţ���֡��������λ��
        if (isReplaying && currentFrame < positionRecorder.recordedActions.Length)
        {
            transform.position = positionRecorder.recordedActions[currentFrame].position;

            currentFrame++; // �ƶ�����һ֡

            if (currentFrame >= positionRecorder.recordedActions.Length)
            {
                isReplaying = false; // �ط���ɺ�ֹͣ
            }
        }
    }
}
