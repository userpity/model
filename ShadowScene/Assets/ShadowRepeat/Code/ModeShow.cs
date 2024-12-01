using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    // 用来引用 Cube 的 Renderer 组件
    private Renderer cubeRenderer;

    void Start()
    {
        // 获取 Cube 的 Renderer 组件
        cubeRenderer = GetComponent<Renderer>();

        // 如果成功找到 Renderer，就修改颜色
        if (cubeRenderer != null)
        {
            cubeRenderer.material.color = Color.red; // 将 Cube 颜色改为红色
        }
    }

    // 切换到不同的颜色
    public void ChangeColor(Color newColor)
    {
        if (cubeRenderer != null)
        {
            cubeRenderer.material.color = newColor; // 设置新的颜色
        }
    }
}
