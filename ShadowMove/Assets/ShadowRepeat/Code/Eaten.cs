using UnityEngine;

public class Eaten : MonoBehaviour
{
    public enum ItemType
    {
        Key,    // Կ��
        Film    // ����
    }

    public ItemType itemType;  // ����ѡ����Ʒ���ͣ�Կ�׻򽺾�

    private GameController gameController;  // ���� GameController

    void Start()
    {
        // ��ȡ GameController ���
        gameController = FindObjectOfType<GameController>();
    }

    // ���ô˷���ʱ��������ʧ
    public void Disappear()
    {
        // ���� GameController ���Ӷ�Ӧ��Ʒ������
        if (gameController != null)
        {
            if (itemType == ItemType.Key)
            {
                gameController.IncreaseKeyCount();  // ����Կ������
            }
            else if (itemType == ItemType.Film)
            {
                gameController.IncreaseFilmCount();  // ���ӽ�������
            }
        }

    // ���ٵ�ǰ����
    gameObject.SetActive(false);
}
}
