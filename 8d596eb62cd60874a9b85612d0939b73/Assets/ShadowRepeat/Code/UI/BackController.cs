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
        //ע�����
        YesBtn.onClick.AddListener(() =>
        {
            print("������Ϸ");
            //todo: �˴���Ҫ������޸�
            SceneManager.LoadSceneAsync("StartScene");
        });

        NoBtn.onClick.AddListener(() =>
        {
            print("������");
            backPanel.gameObject.SetActive(false);
            escPanel.gameObject.SetActive(true);
        });
    }
}
