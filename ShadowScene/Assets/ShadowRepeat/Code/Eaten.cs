using UnityEngine;

public class Eaten : MonoBehaviour
{
    public enum ItemType
    {
        Key,    // 钥匙
        Film    // 胶卷
    }

    public ItemType itemType;  // 用于选择物品类型（钥匙或胶卷）

    private GameController gameController;  // 引用 GameController

    void Start()
    {
        // 获取 GameController 组件
        gameController = FindObjectOfType<GameController>();
    }

    // 调用此方法时让物体消失
    public void Disappear()
    {
        // 调用 GameController 增加对应物品的数量
        if (gameController != null)
        {
            if (itemType == ItemType.Key)
            {
                gameController.IncreaseKeyCount();  // 增加钥匙数量
            }
            else if (itemType == ItemType.Film)
            {
                gameController.IncreaseFilmCount();  // 增加胶卷数量
            }
        }

    // 销毁当前物体
    gameObject.SetActive(false);
}
}
