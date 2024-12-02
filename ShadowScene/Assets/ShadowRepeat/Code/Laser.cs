using UnityEngine;

public class Laser : MonoBehaviour
{
    public enum LaserType { Red, Black }  // �������ͣ���ɫ���ɫ��
    public LaserType laserType;           // ��ǰ���������
    public float laserLength = 10f;       // ����ĳ���
    public GameController gameController;
    public LayerMask playerLayer;         // ������ڵĲ�
    public LayerMask shadowLayer;         // Ӱ�����ڵĲ�
    public float angle = 45f; // ��ϣ���ĽǶ�
   

    private void Update()
    {
        // ��ÿ֡����ʱ���伤��
        FireLaser();
    }

    private void FireLaser()
    {
        // ����һ������
        RaycastHit hit;
        Vector3 laserDirection = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad),Mathf.Sin(angle * Mathf.Deg2Rad) , 0);
        laserDirection.Normalize();  // ȷ�������ǵ�λ����
        // ʹ�� LayerMask �� Raycast �����ײ
        if (Physics.Raycast(transform.position, laserDirection, out hit, laserLength))
        {
            // ���ݼ�������ͣ��ж��Ƿ�����һ�Ӱ�ӷ�����ײ
            if (laserType == LaserType.Red && ((1 << hit.collider.gameObject.layer) & playerLayer) != 0)
            {
                // ��ɫ����������ң������������
                gameController.Dead = true;
            }
            else if (laserType == LaserType.Black && ((1 << hit.collider.gameObject.layer) & shadowLayer) != 0)
            {
                // ��ɫ��������Ӱ�ӣ�����Ӱ������
                gameController.Dead = true;
            }
        }

        // ���ӻ����⣨���ڵ��ԣ�
        Debug.DrawRay(transform.position, laserDirection * laserLength, Color.red);
    }
}
