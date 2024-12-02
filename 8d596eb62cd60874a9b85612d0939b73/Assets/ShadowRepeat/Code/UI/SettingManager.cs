using System.Collections;
using System.Collections.Generic;
using tool;
using UnityEngine;

public class SettingManager : SingletonManager<SettingManager>
{
    //包含所有设置的选项
    [Header("=====单选设置======")]
    public List<DictTitle<string,bool>> settingDict = new List<DictTitle<string,bool>>();
    [Header("=====滑条设置======")]
    public List<Dict<string, float>> settingExDict = new List<Dict<string, float>>();
}
