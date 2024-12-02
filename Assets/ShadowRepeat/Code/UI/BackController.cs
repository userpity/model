using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackController : MonoBehaviour
{
    [Header("=======Button==========")]
    public Button YesBtn;
    public Button NoBtn;
    [Header("=======GameObject==========")]
    public GameObject escPanel;
    public GameObject backPanel;
    // Start is called before the first frame update
    void Start()
    {
        AddAllClick();

    }

    public void AddAllClick()
    {
        //注册监听
        YesBtn.onClick.AddListener(() =>
        {
            print("返回游戏");
            //todo: 此处需要在最后被修改
            SceneManager.LoadSceneAsync("StartScene");
        });

        NoBtn.onClick.AddListener(() =>
        {
            print("不返回");
            backPanel.gameObject.SetActive(false);
            escPanel.gameObject.SetActive(true);
        });
    }
}
