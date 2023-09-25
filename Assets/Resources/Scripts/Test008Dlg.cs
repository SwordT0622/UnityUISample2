using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test008Dlg : MonoBehaviour
{
    [SerializeField] Dropdown m_CityDrop = null;
    [SerializeField] Text m_ResultTxt = null;
    [SerializeField] Button m_StartBtn = null;
    [SerializeField] Button m_ClearBtn = null;

    string selectedCity = string.Empty;

    private void Start()
    {
        m_CityDrop.onValueChanged.AddListener(OnValueChanged_City);
        m_StartBtn.onClick.AddListener(OnClicked_Start);
        m_ClearBtn.onClick.AddListener(OnClicked_Clear);
    }

    void OnValueChanged_City(int idx)
    {
        selectedCity = m_CityDrop.options[idx].text;
        m_ResultTxt.text = string.Format("{0} : {1}", idx, selectedCity);
    }

    void OnClicked_Start()
    {
        SetResult();
    }

    void OnClicked_Clear()
    {
        selectedCity = string.Empty;
        m_ResultTxt.text = "초기화되었습니다.";
    }

    void SetResult()
    {
        if (selectedCity == string.Empty)
            return;

        m_ResultTxt.text = string.Format("당신이 선택한 도시는 <color=#8a2be2>{0}</color>입니다.", selectedCity);
    }
}
