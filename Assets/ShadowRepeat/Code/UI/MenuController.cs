using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [Header("=======Button==========")]
    public Button startBtn;
    //public Button continueBtn;
    public Button settingBtn;
    public Button exitBtn;

    [Header("=======GameObject==========")]
    public GameObject settingPanel;
    private void Start()
    {
        AddAllClick();
    }

    public void AddAllClick()
    {
        //ע�����
        startBtn.onClick.AddListener(() =>
        {
            print("��ʼ��Ϸ");
            //todo: �˴���Ҫ������޸�
            SceneManager.LoadSceneAsync("LevelSelectionScene");
        });

        //continueBtn.onClick.AddListener(() =>
        //{
        //    print("����");
        //});

        settingBtn.onClick.AddListener(() =>
        {
            print("����");
            settingPanel.SetActive(true);
            this.gameObject.SetActive(false);
        });

        exitBtn.onClick.AddListener(() =>
        {
            print("�˳�");
            Application.Quit();
        });
    }

}
