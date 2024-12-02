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
        //ע�����
        continueBtn.onClick.AddListener(() =>
        {
            print("������Ϸ");
            //todo: �˴���Ҫ������޸�
            escPanel.gameObject.SetActive(false);
        });

        settingBtn.onClick.AddListener(() =>
        {
            print("����");
            settingPanel.SetActive(true);
            escPanel.gameObject.SetActive(false);
        });

        backBtn.onClick.AddListener(() =>
        {
            print("�������˵�");
            //todo: �˴���Ҫ������޸�
            //SceneManager.LoadSceneAsync("MenuScene");
            backPanel.SetActive(true);
            escPanel.gameObject.SetActive(false);
        });
    }

    public void EscExit()
    {
        //��ҵ��esc��������escpanel���ٴε��panel��ʧ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (escPanel.gameObject.activeSelf)
            {
                escPanel.gameObject.SetActive(false);

                //��Ϸ���� game continue
                Time.timeScale = 1f;

            }
            else
            {
                escPanel.gameObject.SetActive(true);

                //��Ϸֹͣ game stop
                Time.timeScale = 0f;
            }
        }
    }
}
