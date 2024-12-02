using UnityEngine;

public class TriggerEffect : MonoBehaviour
{
    public string targetComponentName; // 目标组件名
    public string methodName; // 目标组件方法名

    void OnTriggerEnter(Collider other)
    {
        // 检查与触发器碰撞的物体是否有标签 "A"
        if (other.CompareTag("Players"))
        {
            // 获取当前物体上的所有组件
            Component[] components = GetComponents<Component>();

            foreach (var component in components)
            {
                // 如果找到目标组件
                if (component.GetType().Name == targetComponentName)
                {
                    // 查找并调用目标方法
                    var method = component.GetType().GetMethod(methodName);
                    if (method != null)
                    {
                        method.Invoke(component, null); // 调用该方法
                    }
                    else
                    {
                        Debug.LogWarning("方法不存在: " + methodName);
                    }
                    return;
                }
            }
        }
    }
}
