using UnityEngine;
public class GameController : MonoBehaviour
{
    public PositionRecorder positionRecorder; // 记录位置的组件
    public PositionReplayer positionReplayer; // 重放位置的组件
    public Transform startPoint; // 起点位置
    public ColorChanger cubeColorChanger; // 用来引用 ColorChanger 脚本
    public LineDraw lineDraw;
    public GameObject shadowObject;
    public GameObject playerObject;
    private bool RecordingMode = true; // 判断是否为第一条命
    public float checkRadius = 0.5f; // 检测范围，控制检测是否能穿越障碍物




    void Start()
    {
        // 游戏开始时，玩家回到起点并进入记录模式
        playerObject.transform.position = startPoint != null ? startPoint.position : Vector3.zero;
        positionRecorder.isRecording = true; // 开启记录模式
        positionReplayer.StopReplay(); // 确保播放模式为关闭
        if (cubeColorChanger != null)
        {
            cubeColorChanger.ChangeColor(Color.red); // 第一条命是红色
        }
        shadowObject.SetActive(false);  // 禁用物体，使其完全不可见且停用
    }

    void Update()
    {
        // 如果按下 R 键，切换模式
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (RecordingMode)
            {
                // 进入第二条命：回到起点，停止记录，进入播放模式
                positionReplayer.turnShadow(true);
                shadowObject.SetActive(true);  // 禁用物体，使其完全不可见且停用
                RecordingMode = false;
                playerObject.transform.position = startPoint != null ? startPoint.position : Vector3.zero;
                positionRecorder.isRecording = false; // 停止记录
                positionReplayer.StartReplay(); // 启动播放
                lineDraw.isReplayMode = true;
                lineDraw.isShadow = true;
                if (cubeColorChanger != null)
                {
                    cubeColorChanger.ChangeColor(Color.blue); // 第一条命是红色
                }
            }
            else
            {
                // 如果是第二条命，重置回到记录模式，并清空记录
                RecordingMode = true;
                positionReplayer.StopReplay(); // 停止播放
                positionRecorder.recordedActions = new PlayerAction[10000]; // 清空记录
                playerObject.transform.position = startPoint != null ? startPoint.position : Vector3.zero;
                positionRecorder.StartRecording();// 启动记录模式
                lineDraw.isReplayMode = false;
                if (cubeColorChanger != null)
                {
                    cubeColorChanger.ChangeColor(Color.red); // 第一条命是红色
                }
                shadowObject.SetActive(false);  // 禁用物体，使其完全不可见且停用
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


    // 检测目标位置是否被障碍物阻挡
    bool IsPositionBlocked(Vector3 targetPosition)
    {
        // 使用 OverlapSphere 来检测目标位置周围的所有碰撞体
        Collider[] colliders = Physics.OverlapSphere(targetPosition, checkRadius);

        // 如果碰到有启用的碰撞体
        foreach (Collider collider in colliders)
        {
            if (collider != null && collider.enabled)  // 检查碰撞体是否启用
            {
                return true;  // 目标位置被阻挡
            }
        }

        return false;  // 没有障碍物阻挡
    }

    // 检查是否能交换位置，如果可以则交换
    bool SwapPositionsIfNotBlocked(GameObject obj1, GameObject obj2)
    {
        Vector3 target1Position = obj1.transform.position;
        Vector3 target2Position = obj2.transform.position;

        // 检查影子目标位置是否被阻挡
        if (!IsPositionBlocked(target2Position))
        {
            // 如果目标位置没有障碍物，可以交换位置
            obj1.transform.position = target2Position;
            obj2.transform.position = target1Position;
            return true;
        }
        else
        {
            Debug.Log("目标位置被阻挡，无法交换位置");
            return false;
        }
    }
}
