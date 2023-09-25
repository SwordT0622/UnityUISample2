using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test009Dlg : MonoBehaviour
{
    [SerializeField] Dropdown m_CityDrop = null;
    [SerializeField] Text m_ResultTxt = null;
    [SerializeField] Button m_StartBtn = null;
    [SerializeField] Button m_ClearBtn = null;

    string[] cities = new string[] { "����", "����", "�뱸", "���", "����", "�λ�", "��õ" };

    string selectedCity = "";

    private void Start()
    {
        Initialize();
        m_CityDrop.onValueChanged.AddListener(OnValueChanged_City);
        m_StartBtn.onClick.AddListener(OnClicked_Start);
        m_ClearBtn.onClick.AddListener(OnClicked_Clear);
    }

    void Initialize()
    {
        for(int i = 0; i < cities.Length; i++)
        {
            Dropdown.OptionData optionData = new Dropdown.OptionData(cities[i]);
            m_CityDrop.options.Add(optionData);
        }
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
        selectedCity = "";
        m_ResultTxt.text = "�ʱ�ȭ�Ǿ����ϴ�.";
    }

    void SetResult()
    {
        if (selectedCity == string.Empty)
            return;

        m_ResultTxt.text = string.Format("����� ������ ���ô� <color=#8a2be2>{0}</color>�Դϴ�.", selectedCity);
    }
}
