using UnityEngine;

public class TriggerEffect : MonoBehaviour
{
    public string targetComponentName; // Ŀ�������
    public string methodName; // Ŀ�����������

    void OnTriggerEnter(Collider other)
    {
        // ����봥������ײ�������Ƿ��б�ǩ "A"
        if (other.CompareTag("Players"))
        {
            // ��ȡ��ǰ�����ϵ��������
            Component[] components = GetComponents<Component>();

            foreach (var component in components)
            {
                // ����ҵ�Ŀ�����
                if (component.GetType().Name == targetComponentName)
                {
                    // ���Ҳ�����Ŀ�귽��
                    var method = component.GetType().GetMethod(methodName);
                    if (method != null)
                    {
                        method.Invoke(component, null); // ���ø÷���
                    }
                    else
                    {
                        Debug.LogWarning("����������: " + methodName);
                    }
                    return;
                }
            }
        }
    }
}
