using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class SelectPanel : MonoBehaviour
{
    public string title;
    //所有关闭开启的optionimg
    public List<GameObject> images;
    //用于鼠标点击按钮进行状态切换
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
        // 如果没有选中的图片，则返回默认索引0
        return 0;
    }
}
