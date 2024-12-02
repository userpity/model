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
    public GameObject menuPanel;  //���˵���panel
   
    public SelectPanel[] radioPanels;
    public SilderPanel[] sliderPanels;

    void Start()
    {
        //�����������
        basicButton.onClick.AddListener((() =>
        {
            mainPanel.SetActive(true);
            controlMenuPanel.SetActive(false);
        }));

        //�������������
        controlMenuButton.onClick.AddListener((() =>
        {
            mainPanel.SetActive(false);
            controlMenuPanel.SetActive(true);
        }));

        backButton.onClick.AddListener((() =>
        {
            //�洢�ı��˵�����
            SaveData();
            gameObject.SetActive(false);
            menuPanel.SetActive(true);
        }));

        LoadData();
    }

    private void LoadData()
    {
        //ʹ�� scripttable object

        //������е�ѡ����
        radioPanels = mainPanel.GetComponentsInChildren<SelectPanel>();
        foreach (var radioPanel in radioPanels)
        {
            var kv = SettingManager.Instance.settingDict.FirstOrDefault(x => x.title == radioPanel.title);
            if (kv!=null)
            {
                //Debug.Log($"���ڣ��Ƿ�ȫ�� {radioPanel.GetState()}");
                var index = kv.Dicts.FindIndex(x => x.value == true);
                radioPanel.SetState(index);

            }
        }
        //������л���ѡ��
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
        //������е�ѡ����
        radioPanels = mainPanel.GetComponentsInChildren<SelectPanel>();
        foreach (var radioPanel in radioPanels)
        {
            var kv = SettingManager.Instance.settingDict.FirstOrDefault(x => x.title == radioPanel.title);
            if (kv != null)
            {
                Debug.Log($"���ڣ��Ƿ�ȫ�� {radioPanel.GetState()}");
                var index = radioPanel.GetState(); //�ҵ����ѡ���index�л���active��
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
        //������л���ѡ��
        sliderPanels = mainPanel.GetComponentsInChildren<SilderPanel>();
        foreach (var sliderPanel in sliderPanels)
        {
            var kv = SettingManager.Instance.settingExDict.FirstOrDefault(x => x.key == sliderPanel.title);
            if (kv != null)
            {
                Debug.Log($"���ڣ�������Ч��ֵΪ {sliderPanel.GetValue()}");
                kv.value = sliderPanel.GetValue();
            }
        }
    }


}
