using UnityEngine;
public class GameController : MonoBehaviour
{
    public PositionRecorder positionRecorder; // ��¼λ�õ����
    public PositionReplayer positionReplayer; // �ط�λ�õ����
    public Transform startPoint; // ���λ��
    public ColorChanger cubeColorChanger; // �������� ColorChanger �ű�

    private bool isFirstLife = true; // �ж��Ƿ�Ϊ��һ����
   


    void Start()
    {
        // ��Ϸ��ʼʱ����һص���㲢�����¼ģʽ
        transform.position = startPoint != null ? startPoint.position : Vector3.zero;
        positionRecorder.isRecording = true; // ������¼ģʽ
        positionReplayer.StopReplay(); // ȷ������ģʽΪ�ر�
        if (cubeColorChanger != null)
        {
            cubeColorChanger.ChangeColor(Color.red); // ��һ�����Ǻ�ɫ
        }
    }

    void Update()
    {
        // ������� R �����л�ģʽ
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isFirstLife)
            {
                // ����ڶ��������ص���㣬ֹͣ��¼�����벥��ģʽ
                isFirstLife = false;
                transform.position = startPoint != null ? startPoint.position : Vector3.zero;
                positionRecorder.isRecording = false; // ֹͣ��¼
                positionReplayer.StartReplay(); // ��������
                if (cubeColorChanger != null)
                {
                    cubeColorChanger.ChangeColor(Color.blue); // ��һ�����Ǻ�ɫ
                }
            }
            else
            {
                // ����ǵڶ����������ûص���¼ģʽ������ռ�¼
                isFirstLife = true;
                positionReplayer.StopReplay(); // ֹͣ����
                positionRecorder.recordedActions = new PlayerAction[10000]; // ��ռ�¼
                transform.position = startPoint != null ? startPoint.position : Vector3.zero;
                positionRecorder.StartRecording();// ������¼ģʽ
                if (cubeColorChanger != null)
                {
                    cubeColorChanger.ChangeColor(Color.red); // ��һ�����Ǻ�ɫ
                }

            }
        }

    }
}
