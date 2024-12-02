using UnityEngine;

public class Laser : MonoBehaviour
{
    public enum LaserType { Red, Black }  // 激光类型（红色或黑色）
    public LaserType laserType;           // 当前激光的类型
    public float laserLength = 10f;       // 激光的长度
    public GameController gameController;
    public LayerMask playerLayer;         // 玩家所在的层
    public LayerMask shadowLayer;         // 影子所在的层
    public float angle = 45f; // 你希望的角度
   

    private void Update()
    {
        // 在每帧更新时发射激光
        FireLaser();
    }

    private void FireLaser()
    {
        // 发射一条射线
        RaycastHit hit;
        Vector3 laserDirection = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad),Mathf.Sin(angle * Mathf.Deg2Rad) , 0);
        laserDirection.Normalize();  // 确保方向是单位向量
        // 使用 LayerMask 和 Raycast 检测碰撞
        if (Physics.Raycast(transform.position, laserDirection, out hit, laserLength))
        {
            // 根据激光的类型，判断是否与玩家或影子发生碰撞
            if (laserType == LaserType.Red && ((1 << hit.collider.gameObject.layer) & playerLayer) != 0)
            {
                // 红色激光碰到玩家，触发玩家死亡
                gameController.Dead = true;
            }
            else if (laserType == LaserType.Black && ((1 << hit.collider.gameObject.layer) & shadowLayer) != 0)
            {
                // 黑色激光碰到影子，触发影子死亡
                gameController.Dead = true;
            }
        }

        // 可视化激光（用于调试）
        Debug.DrawRay(transform.position, laserDirection * laserLength, Color.red);
    }
}
