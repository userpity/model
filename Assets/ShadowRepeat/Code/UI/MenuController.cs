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
        //注册监听
        startBtn.onClick.AddListener(() =>
        {
            print("开始游戏");
            //todo: 此处需要在最后被修改
            SceneManager.LoadSceneAsync("LevelSelectionScene");
        });

        //continueBtn.onClick.AddListener(() =>
        //{
        //    print("加载");
        //});

        settingBtn.onClick.AddListener(() =>
        {
            print("设置");
            settingPanel.SetActive(true);
            this.gameObject.SetActive(false);
        });

        exitBtn.onClick.AddListener(() =>
        {
            print("退出");
            Application.Quit();
        });
    }

}
