using UnityEngine;
public class GameController : MonoBehaviour
{
    public PositionRecorder positionRecorder; // ��¼λ�õ����
    public PositionReplayer positionReplayer; // �ط�λ�õ����
    public Transform startPoint; // ���λ��
    public ColorChanger cubeColorChanger; // �������� ColorChanger �ű�
    public LineDraw lineDraw;
    public GameObject shadowObject;
    public GameObject playerObject;
    private bool RecordingMode = true; // �ж��Ƿ�Ϊ��һ����
    public float checkRadius = 0.5f; // ��ⷶΧ�����Ƽ���Ƿ��ܴ�Խ�ϰ���




    void Start()
    {
        // ��Ϸ��ʼʱ����һص���㲢�����¼ģʽ
        playerObject.transform.position = startPoint != null ? startPoint.position : Vector3.zero;
        positionRecorder.isRecording = true; // ������¼ģʽ
        positionReplayer.StopReplay(); // ȷ������ģʽΪ�ر�
        if (cubeColorChanger != null)
        {
            cubeColorChanger.ChangeColor(Color.red); // ��һ�����Ǻ�ɫ
        }
        shadowObject.SetActive(false);  // �������壬ʹ����ȫ���ɼ���ͣ��
    }

    void Update()
    {
        // ������� R �����л�ģʽ
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (RecordingMode)
            {
                // ����ڶ��������ص���㣬ֹͣ��¼�����벥��ģʽ
                positionReplayer.turnShadow(true);
                shadowObject.SetActive(true);  // �������壬ʹ����ȫ���ɼ���ͣ��
                RecordingMode = false;
                playerObject.transform.position = startPoint != null ? startPoint.position : Vector3.zero;
                positionRecorder.isRecording = false; // ֹͣ��¼
                positionReplayer.StartReplay(); // ��������
                lineDraw.isReplayMode = true;
                lineDraw.isShadow = true;
                if (cubeColorChanger != null)
                {
                    cubeColorChanger.ChangeColor(Color.blue); // ��һ�����Ǻ�ɫ
                }
            }
            else
            {
                // ����ǵڶ����������ûص���¼ģʽ������ռ�¼
                RecordingMode = true;
                positionReplayer.StopReplay(); // ֹͣ����
                positionRecorder.recordedActions = new PlayerAction[10000]; // ��ռ�¼
                playerObject.transform.position = startPoint != null ? startPoint.position : Vector3.zero;
                positionRecorder.StartRecording();// ������¼ģʽ
                lineDraw.isReplayMode = false;
                if (cubeColorChanger != null)
                {
                    cubeColorChanger.ChangeColor(Color.red); // ��һ�����Ǻ�ɫ
                }
                shadowObject.SetActive(false);  // �������壬ʹ����ȫ���ɼ���ͣ��
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (RecordingMode == false) 
            {
                if (SwapPositionsIfNotBlocked(playerObject, shadowObject))
                {
                    positionReplayer.turnShadow(); 
                    lineDraw.isShadow = !lineDraw.isShadow;
                }
            }
        }
    }


    // ���Ŀ��λ���Ƿ��ϰ����赲
    bool IsPositionBlocked(Vector3 targetPosition)
    {
        // ʹ�� OverlapSphere �����Ŀ��λ����Χ��������ײ��
        Collider[] colliders = Physics.OverlapSphere(targetPosition, checkRadius);

        // ������������õ���ײ��
        foreach (Collider collider in colliders)
        {
            if (collider != null && collider.enabled)  // �����ײ���Ƿ�����
            {
                return true;  // Ŀ��λ�ñ��赲
            }
        }

        return false;  // û���ϰ����赲
    }

    // ����Ƿ��ܽ���λ�ã���������򽻻�
    bool SwapPositionsIfNotBlocked(GameObject obj1, GameObject obj2)
    {
        Vector3 target1Position = obj1.transform.position;
        Vector3 target2Position = obj2.transform.position;

        // ���Ӱ��Ŀ��λ���Ƿ��赲
        if (!IsPositionBlocked(target2Position))
        {
            // ���Ŀ��λ��û���ϰ�����Խ���λ��
            obj1.transform.position = target2Position;
            obj2.transform.position = target1Position;
            return true;
        }
        else
        {
            Debug.Log("Ŀ��λ�ñ��赲���޷�����λ��");
            return false;
        }
    }
}
