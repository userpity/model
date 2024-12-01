using UnityEngine;

public class PositionReplayer : MonoBehaviour
{
    public PositionRecorder positionRecorder; // 引用 PositionRecorder，用于访问记录的动作数组
    public Transform startPoint; // 起点位置
    public Transform player;

    public float replaySpeed = 1f; // 控制重放的速度
    private int currentFrame = 0; // 当前播放的帧数
    private bool isReplaying = false; // 是否在重放
    private bool endReplaying = false; // 是否重放完毕
    private bool isShadow = true;


    // 暴露一个方法给 GameController 来启动/停止重放
    public void StartReplay()
    {
        isReplaying = true;
        endReplaying = false;
        currentFrame = 0; // 从头开始播放
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
        // 如果正在重放，按帧更新物体位置
        if (isShadow)
        {
            if (isReplaying && (positionRecorder.recordedActions[currentFrame] != null) && endReplaying == false)
            {

                transform.position = positionRecorder.recordedActions[currentFrame].position - startPoint.position + player.position;
                currentFrame++; // 移动到下一帧
            }

            if ((positionRecorder.recordedActions[currentFrame] == null) && currentFrame != 0)
            {
                endReplaying = true;
                currentFrame--; // 移动到上一帧
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
                currentFrame++; // 移动到下一帧
            }

            if ((positionRecorder.recordedActions[currentFrame] == null) && currentFrame != 0)
            {
                endReplaying = true;
                currentFrame--; // 移动到上一帧
            }

            if (endReplaying == true)
            {
                transform.position = -(positionRecorder.recordedActions[currentFrame].position - startPoint.position) + player.position;
            }
        }



    }
    
}

