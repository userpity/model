using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class SelectPanel : MonoBehaviour
{
    public string title;
    //���йرտ�����optionimg
    public List<GameObject> images;
    //�����������ť����״̬�л�
    public void SetState(int index)
    {
        images.ForEach(x => x.SetActive(false));
        images[index].SetActive(true);
    }
    public int GetState()
    {
        for (int i = 0; i < images.Count; i++)
        {
            if (images[i].activeSelf)
            {
                return i;
            }
        }
        // ���û��ѡ�е�ͼƬ���򷵻�Ĭ������0
        return 0;
    }
}
