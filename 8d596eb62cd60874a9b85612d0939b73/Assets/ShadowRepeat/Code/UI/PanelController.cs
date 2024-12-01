using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    [Header("=======Button==========")]
    public Button basicButton;
    public Button controlMenuButton;
    public Button backButton;
    [Header("=======GameObject==========")]
    public GameObject mainPanel;
    public GameObject controlMenuPanel;
    public GameObject menuPanel;  //主菜单的panel
   
    public SelectPanel[] radioPanels;
    public SilderPanel[] sliderPanels;

    void Start()
    {
        //进入基础界面
        basicButton.onClick.AddListener((() =>
        {
            mainPanel.SetActive(true);
            controlMenuPanel.SetActive(false);
        }));

        //进入控制面板界面
        controlMenuButton.onClick.AddListener((() =>
        {
            mainPanel.SetActive(false);
            controlMenuPanel.SetActive(true);
        }));

        backButton.onClick.AddListener((() =>
        {
            //存储改变了的数据
            SaveData();
            gameObject.SetActive(false);
            menuPanel.SetActive(true);
        }));

        LoadData();
    }

    private void LoadData()
    {
        //使用 scripttable object

        //获得所有单选界面
        radioPanels = mainPanel.GetComponentsInChildren<SelectPanel>();
        foreach (var radioPanel in radioPanels)
        {
            var kv = SettingManager.Instance.settingDict.FirstOrDefault(x => x.title == radioPanel.title);
            if (kv!=null)
            {
                //Debug.Log($"现在，是否全屏 {radioPanel.GetState()}");
                var index = kv.Dicts.FindIndex(x => x.value == true);
                radioPanel.SetState(index);

            }
        }
        //获得所有滑动选项
        sliderPanels = mainPanel.GetComponentsInChildren<SilderPanel>();
        foreach (var sliderPanel in sliderPanels)
        {
            var kv = SettingManager.Instance.settingExDict.FirstOrDefault(x => x.key == sliderPanel.title);
            if (kv !=null)
            {
                sliderPanel.SetValue(kv.value);
            }
        }
    }

    public void SaveData()
    {
        //获得所有单选界面
        radioPanels = mainPanel.GetComponentsInChildren<SelectPanel>();
        foreach (var radioPanel in radioPanels)
        {
            var kv = SettingManager.Instance.settingDict.FirstOrDefault(x => x.title == radioPanel.title);
            if (kv != null)
            {
                Debug.Log($"现在，是否全屏 {radioPanel.GetState()}");
                var index = radioPanel.GetState(); //找到多个选项的index中还是active的
                for (int i=0; i<kv.Dicts.Count;i++)
                {
                    if (i==index)
                    {
                        kv.Dicts[i].value = true;
                    }
                    else
                    {
                        kv.Dicts[i].value = false;
                    }
                }

            }
        }
        //获得所有滑动选项
        sliderPanels = mainPanel.GetComponentsInChildren<SilderPanel>();
        foreach (var sliderPanel in sliderPanels)
        {
            var kv = SettingManager.Instance.settingExDict.FirstOrDefault(x => x.key == sliderPanel.title);
            if (kv != null)
            {
                Debug.Log($"现在，音乐音效的值为 {sliderPanel.GetValue()}");
                kv.value = sliderPanel.GetValue();
            }
        }
    }


}
