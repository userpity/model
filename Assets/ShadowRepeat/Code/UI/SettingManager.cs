using System.Collections;
using System.Collections.Generic;
using tool;
using UnityEngine;

public class SettingManager : SingletonManager<SettingManager>
{
    //�����������õ�ѡ��
    [Header("=====��ѡ����======")]
    public List<DictTitle<string,bool>> settingDict = new List<DictTitle<string,bool>>();
    [Header("=====��������======")]
    public List<Dict<string, float>> settingExDict = new List<Dict<string, float>>();
}
