using UnityEngine;

public class PositionReplayer : MonoBehaviour
{
    public PositionRecorder positionRecorder; // ���� PositionRecorder�����ڷ��ʼ�¼�Ķ�������
    public Transform startPoint; // ���λ��
    public Transform player;

    private int currentFrame = 0; // ��ǰ���ŵ�֡��
    private bool isReplaying = false; // �Ƿ����ط�
    private bool isShadow = true;


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
            transform.position = positionRecorder.recordedActions[currentFrame].position - startPoint.position + player.position;
            if (isReplaying && (positionRecorder.recordedActions[currentFrame+1] != null)) currentFrame++;
        }
        if (!isShadow)
        {
            
            transform.position = -(positionRecorder.recordedActions[currentFrame].position - startPoint.position) + player.position;
            if (isReplaying && (positionRecorder.recordedActions[currentFrame + 1] != null))currentFrame++;
        }



    }
    
}

