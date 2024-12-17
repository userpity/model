using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    // �������� Cube �� Renderer ���
    private Renderer cubeRenderer;

    void Start()
    {
        // ��ȡ Cube �� Renderer ���
        cubeRenderer = GetComponent<Renderer>();

        // ����ɹ��ҵ� Renderer�����޸���ɫ
        if (cubeRenderer != null)
        {
            cubeRenderer.material.color = Color.red; // �� Cube ��ɫ��Ϊ��ɫ
        }
    }

    // �л�����ͬ����ɫ
    public void ChangeColor(Color newColor)
    {
        if (cubeRenderer != null)
        {
            cubeRenderer.material.color = newColor; // �����µ���ɫ
        }
    }
}
