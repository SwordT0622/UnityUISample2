using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Test005Dlg : MonoBehaviour
{
    [SerializeField] Slider[] m_ColorSliders = null;
    [SerializeField] Text[] m_ColorTxts = null;
    [SerializeField] Text m_ResultTxt = null;
    [SerializeField] Button m_StartBtn = null;
    [SerializeField] Button m_ClearBtn = null;

    float[] colors = new float[] { 0, 0, 0 };

    private void Start()
    {
        m_StartBtn.onClick.AddListener(OnClicked_Start);
        m_ClearBtn.onClick.AddListener(OnClicked_Clear);

        for(int i = 0; i < m_ColorSliders.Length; i++)
        {
            int idx = i;
            m_ColorSliders[i].onValueChanged.AddListener((float value) =>
            {
                OnValueChanged_Color(value, idx);
            });
        }
    }

    void OnValueChanged_Color(float value, int idx)
    {
        m_ColorTxts[idx].text = value.ToString();
        colors[idx] = value;
        SetTextColor();
    }

    void OnClicked_Start()
    {
        m_ResultTxt.text = string.Format("���� ����� �� �����Դϴ�.\n(R : {0}  G : {1}  B : {2})", colors[0], colors[1], colors[2]);
    }

    void OnClicked_Clear()
    {
        for (int i = 0; i < m_ColorSliders.Length; i++)
            m_ColorSliders[i].value = 0;

        m_ResultTxt.text = "�ʱ�ȭ�Ǿ����ϴ�.";
    }

    void SetTextColor()
    {
        m_ResultTxt.text = "���� �����Դϴ�.";
        m_ResultTxt.color = new Color32((byte)colors[0], (byte)colors[1], (byte)colors[2], 255);
    }
}
