using UnityEngine;
public class GameController : MonoBehaviour
{
    public PositionRecorder positionRecorder; // 记录位置的组件
    public PositionReplayer positionReplayer; // 重放位置的组件
    public Transform startPoint; // 起点位置
    public ColorChanger cubeColorChanger; // 用来引用 ColorChanger 脚本
    public GameObject targetObject;

    private bool isFirstLife = true; // 判断是否为第一条命
   


    void Start()
    {
        // 游戏开始时，玩家回到起点并进入记录模式
        transform.position = startPoint != null ? startPoint.position : Vector3.zero;
        positionRecorder.isRecording = true; // 开启记录模式
        positionReplayer.StopReplay(); // 确保播放模式为关闭
        if (cubeColorChanger != null)
        {
            cubeColorChanger.ChangeColor(Color.red); // 第一条命是红色
        }
        targetObject.SetActive(false);  // 禁用物体，使其完全不可见且停用
    }

    void Update()
    {
        // 如果按下 R 键，切换模式
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isFirstLife)
            {
                // 进入第二条命：回到起点，停止记录，进入播放模式
                targetObject.SetActive(true);  // 禁用物体，使其完全不可见且停用
                isFirstLife = false;
                transform.position = startPoint != null ? startPoint.position : Vector3.zero;
                positionRecorder.isRecording = false; // 停止记录
                positionReplayer.StartReplay(); // 启动播放
                if (cubeColorChanger != null)
                {
                    cubeColorChanger.ChangeColor(Color.blue); // 第一条命是红色
                }
            }
            else
            {
                // 如果是第二条命，重置回到记录模式，并清空记录
                isFirstLife = true;
                positionReplayer.StopReplay(); // 停止播放
                positionRecorder.recordedActions = new PlayerAction[10000]; // 清空记录
                transform.position = startPoint != null ? startPoint.position : Vector3.zero;
                positionRecorder.StartRecording();// 启动记录模式
                if (cubeColorChanger != null)
                {
                    cubeColorChanger.ChangeColor(Color.red); // 第一条命是红色
                }
                targetObject.SetActive(false);  // 禁用物体，使其完全不可见且停用
            }
        }

    }
}
