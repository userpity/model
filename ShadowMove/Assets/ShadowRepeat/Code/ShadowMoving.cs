using UnityEngine;

public class PositionReplayer : MonoBehaviour
{
    public PositionRecorder positionRecorder; // ���� PositionRecorder�����ڷ��ʼ�¼�Ķ�������
    public Transform startPoint; // ���λ��
    public Transform player;

    public float replaySpeed = 1f; // �����طŵ��ٶ�
    private int currentFrame = 0; // ��ǰ���ŵ�֡��
    private bool isReplaying = false; // �Ƿ����ط�
    private bool endReplaying = false; // �Ƿ��ط����
    private bool isShadow = true;


    // ��¶һ�������� GameController ������/ֹͣ�ط�
    public void StartReplay()
    {
        isReplaying = true;
        endReplaying = false;
        currentFrame = 0; // ��ͷ��ʼ����
    }

    public void StopReplay()
    {
        isReplaying = false;
    }

    public void turnShadow()
    {
        isShadow = !isShadow;
    }

    public void turnShadow(bool sha)
    {
        isShadow = sha;
    }

    void FixedUpdate()
    {
        // ��������طţ���֡��������λ��
        if (isShadow)
        {
            if (isReplaying && (positionRecorder.recordedActions[currentFrame] != null) && endReplaying == false)
            {

                transform.position = positionRecorder.recordedActions[currentFrame].position - startPoint.position + player.position;
                currentFrame++; // �ƶ�����һ֡
            }

            if ((positionRecorder.recordedActions[currentFrame] == null) && currentFrame != 0)
            {
                endReplaying = true;
                currentFrame--; // �ƶ�����һ֡
            }

            if (endReplaying == true)
            {
                transform.position = positionRecorder.recordedActions[currentFrame].position - startPoint.position + player.position;
            }
        }
        if (!isShadow)
        {
            if (isReplaying && (positionRecorder.recordedActions[currentFrame] != null) && endReplaying == false)
            {

                transform.position = -(positionRecorder.recordedActions[currentFrame].position - startPoint.position) + player.position;
                currentFrame++; // �ƶ�����һ֡
            }

            if ((positionRecorder.recordedActions[currentFrame] == null) && currentFrame != 0)
            {
                endReplaying = true;
                currentFrame--; // �ƶ�����һ֡
            }

            if (endReplaying == true)
            {
                transform.position = -(positionRecorder.recordedActions[currentFrame].position - startPoint.position) + player.position;
            }
        }



    }
    
}

