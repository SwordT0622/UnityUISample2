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
        m_ResultTxt.text = string.Format("���� ����� ���� <color=#0DEE2B>{0}</color>�Դϴ�.", m_NumberSlider.value);
    }

    void OnClicked_Clear()
    {
        m_NumberSlider.value = 0;
        m_ResultTxt.text = "�ʱ�ȭ�Ǿ����ϴ�.";
    }
}
