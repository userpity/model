using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscController : MonoBehaviour
{
    [Header("=======Button==========")]
    public Button settingBtn;
    public Button continueBtn;
    public Button backBtn;
    // Start is called before the first frame update
    [Header("=======GameObject==========")]
    public GameObject settingPanel;
    public GameObject escPanel;
    public GameObject backPanel;

    void Start()
    {
        AddAllClick();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Esc key was pressed");
            EscExit();
        }
    }
    public void AddAllClick()
    {
        //注册监听
        continueBtn.onClick.AddListener(() =>
        {
            print("返回游戏");
            //todo: 此处需要在最后被修改
            escPanel.gameObject.SetActive(false);
        });

        settingBtn.onClick.AddListener(() =>
        {
            print("设置");
            settingPanel.SetActive(true);
            escPanel.gameObject.SetActive(false);
        });

        backBtn.onClick.AddListener(() =>
        {
            print("返回主菜单");
            //todo: 此处需要在最后被修改
            //SceneManager.LoadSceneAsync("MenuScene");
            backPanel.SetActive(true);
            escPanel.gameObject.SetActive(false);
        });
    }

    public void EscExit()
    {
        //玩家点击esc键，出现escpanel，再次点击panel消失
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (escPanel.gameObject.activeSelf)
            {
                escPanel.gameObject.SetActive(false);

                //游戏继续 game continue
                Time.timeScale = 1f;

            }
            else
            {
                escPanel.gameObject.SetActive(true);

                //游戏停止 game stop
                Time.timeScale = 0f;
            }
        }
    }
}
