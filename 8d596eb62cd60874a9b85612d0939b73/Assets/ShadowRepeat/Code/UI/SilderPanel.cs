using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilderPanel : MonoBehaviour
{
    public string title;
    public Slider slider;

    //value �� 0-1 �ƶ�
    public void SetValue(float value)
    {
        slider.value = value;
    }

    public float GetValue()
    {
        return slider.value;
    }
}
