using UnityEngine;

public class PositionReplayer : MonoBehaviour
{
    public PositionRecorder positionRecorder; // 引用 PositionRecorder，用于访问记录的动作数组
    public Transform startPoint; // 起点位置
    public Transform player;

    private int currentFrame = 0; // 当前播放的帧数
    private bool isReplaying = false; // 是否在重放
    private bool isShadow = true;


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

