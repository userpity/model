using UnityEngine;

public class PositionReplayer : MonoBehaviour
{
    public PositionRecorder positionRecorder; // 引用 PositionRecorder，用于访问记录的动作数组
    public float replaySpeed = 1f; // 控制重放的速度
    private int currentFrame = 0; // 当前播放的帧数
    private bool isReplaying = false; // 是否在重放

    // 暴露一个方法给 GameController 来启动/停止重放
    public void StartReplay()
    {
        isReplaying = true;
        currentFrame = 0; // 从头开始播放
    }

    public void StopReplay()
    {
        isReplaying = false;
    }

    void FixedUpdate()
    {
        // 如果正在重放，按帧更新物体位置
        if (isReplaying && currentFrame < positionRecorder.recordedActions.Length)
        {
            transform.position = positionRecorder.recordedActions[currentFrame].position;

            currentFrame++; // 移动到下一帧

            if (currentFrame >= positionRecorder.recordedActions.Length)
            {
                isReplaying = false; // 重放完成后停止
            }
        }
    }
}
