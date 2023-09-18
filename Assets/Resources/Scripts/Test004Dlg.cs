using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test004Dlg : MonoBehaviour
{
    [SerializeField] Slider m_NumberSlider = null;
    [SerializeField] Text m_ResultTxt = null;
    [SerializeField] Button m_StartBtn = null;
    [SerializeField] Button m_ClearBtn = null;

    private void Start()
    {
        m_NumberSlider.onValueChanged.AddListener(OnValueChanged_Number);
        m_StartBtn.onClick.AddListener(OnClicked_Start);
        m_ClearBtn.onClick.AddListener(OnClicked_Clear);
    }

    void OnValueChanged_Number(float value)
    {
        m_ResultTxt.text = value.ToString();
    }

    void OnClicked_Start()
    {
        m_ResultTxt.text = string.Format("현재 진행된 값은 <color=#0DEE2B>{0}</color>입니다.", m_NumberSlider.value);
    }

    void OnClicked_Clear()
    {
        m_NumberSlider.value = 0;
        m_ResultTxt.text = "초기화되었습니다.";
    }
}
