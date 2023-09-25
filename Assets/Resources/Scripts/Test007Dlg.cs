using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test007Dlg : MonoBehaviour
{
    [SerializeField] Scrollbar m_AlphaBar = null;
    [SerializeField] Text m_ResultTxt = null;
    [SerializeField] Button m_StartBtn = null;
    [SerializeField] Button m_StopBtn = null;

    float t = 0;
    bool isStart = false;

    private void Start()
    {
        m_AlphaBar.onValueChanged.AddListener(OnValueChanged_Alpha);
        m_StartBtn.onClick.AddListener(OnClicked_Start);
        m_StopBtn.onClick.AddListener(OnClicked_Stop);
    }

    private void Update()
    {
        if (isStart)
        {
            if (m_AlphaBar.value >= 1.0f)
            {
                m_AlphaBar.value = 1;
                return;
            }

            t += Time.deltaTime;
            if(t >= 0.5f)
            {
                m_AlphaBar.value += 0.05f;
                t = 0;
            }
        }
    }

    void OnValueChanged_Alpha(float value)
    {
        Print(value);
    }

    void OnClicked_Start()
    {
        isStart = true;
    }

    void OnClicked_Stop()
    {
        t = 0;
        isStart = false;
    }

    void Print(float value)
    {
        m_ResultTxt.text = string.Format("{0:0.00}", value);
        m_ResultTxt.color = new Color(0.5411765f, 0.1686275f, 0.8862745f, value);
    }
}