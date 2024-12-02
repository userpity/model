using UnityEngine;

public class PositionRecorder : MonoBehaviour
{
    public PlayerAction[] recordedActions; // ��������
    private int currentFrame = 0; // ��ǰ֡����
    public bool isRecording = true; // �Ƿ��¼����

    void Start()
    {
        recordedActions = new PlayerAction[10000]; // ��������¼ 10000 ֡
    }


    // ��¶һ�������� GameController ������/ֹͣ�ط�
    public void StartRecording()
    {
        isRecording = true;
        currentFrame = 0; // ��ͷ��ʼ����
    }

    void FixedUpdate()
    {
        // ֻ��¼λ��
        if (isRecording && currentFrame < recordedActions.Length)
        {
            recordedActions[currentFrame] = new PlayerAction
            {
                position = transform.position, // ��¼��ҵ�λ��
            };
            Debug.Log($"Frame {currentFrame}: Position {transform.position}");
            currentFrame++; // ����֡��
        }
    }
}

// �������ݽṹ
[System.Serializable]
public class PlayerAction
{
    public Vector3 position; // ��¼��ҵ�λ��
}
