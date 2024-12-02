using UnityEngine;

public class PositionRecorder : MonoBehaviour
{
    public PlayerAction[] recordedActions; // 动作数组
    private int currentFrame = 0; // 当前帧索引
    public bool isRecording = true; // 是否记录动作

    void Start()
    {
        recordedActions = new PlayerAction[10000]; // 假设最大记录 10000 帧
    }


    // 暴露一个方法给 GameController 来启动/停止重放
    public void StartRecording()
    {
        isRecording = true;
        currentFrame = 0; // 从头开始播放
    }

    void FixedUpdate()
    {
        // 只记录位置
        if (isRecording && currentFrame < recordedActions.Length)
        {
            recordedActions[currentFrame] = new PlayerAction
            {
                position = transform.position, // 记录玩家的位置
            };
            Debug.Log($"Frame {currentFrame}: Position {transform.position}");
            currentFrame++; // 增加帧数
        }
    }
}

// 动作数据结构
[System.Serializable]
public class PlayerAction
{
    public Vector3 position; // 记录玩家的位置
}
