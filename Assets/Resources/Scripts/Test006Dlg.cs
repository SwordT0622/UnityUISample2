using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test006Dlg : MonoBehaviour
{
    [SerializeField] Scrollbar m_NumberBar = null;
    [SerializeField] Text m_ResultTxt = null;
    [SerializeField] Button m_StartBtn = null;
    [SerializeField] Button m_ClearBtn = null;

    private void Start()
    {
        m_NumberBar.onValueChanged.AddListener(OnValueChanged_Number);
        m_StartBtn.onClick.AddListener(OnClicked_Start);
        m_ClearBtn.onClick.AddListener(OnClicked_Clear);
    }

    void OnValueChanged_Number(float value)
    {
        m_ResultTxt.text = string.Format("{0:0.00}", value);
    }

    void OnClicked_Start()
    {
        m_ResultTxt.text = string.Format("현재 당신의 값은 <color=#8a2be2>{0:0.00}</color>입니다.", m_NumberBar.value);
    }

    void OnClicked_Clear()
    {
        m_NumberBar.value = 0;
        m_ResultTxt.text = "초기화되었습니다.";
    }
}
