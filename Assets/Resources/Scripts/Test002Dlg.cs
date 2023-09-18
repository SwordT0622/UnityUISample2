using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test002Dlg : MonoBehaviour
{
    [SerializeField] Toggle[] m_FruitTgls = null;
    [SerializeField] Text m_ResultTxt = null;
    [SerializeField] Button m_StartBtn = null;
    [SerializeField] Button m_ClearBtn = null;

    //string[] fruits = new string[] { "���", "��", "������" };
    List<string> fruits = new List<string>();

    private void Start()
    {
        for(int i = 0; i < m_FruitTgls.Length; i++)
        {
            int idx = i;
            m_FruitTgls[idx].onValueChanged.AddListener((bool isOn) =>
            {
                OnValueChanged_Fruit(isOn, idx);
            });

            string fruit = m_FruitTgls[i].GetComponentInChildren<Text>().text;
            fruits.Add(fruit);
        }

        m_StartBtn.onClick.AddListener(OnClicked_Start);
        m_ClearBtn.onClick.AddListener(OnClicked_Clear);
    }

    void OnValueChanged_Fruit(bool isOn, int idx)
    {
        if (isOn)
            m_ResultTxt.text = fruits[idx];
        //else
        //    m_ResultTxt.text = "���"; 
    }

    void OnClicked_Start()
    {
        m_ResultTxt.text = GetResult();
    }

    void OnClicked_Clear()
    {
        for(int i = 0; i < m_FruitTgls.Length; i++)
        {
            m_FruitTgls[i].isOn = false;
        }
        m_ResultTxt.text = "�ʱ�ȭ�Ǿ����ϴ�.";
    }

    string GetResult()
    {
        bool notSelected = true;
        string result = "����� ������ ������ ";

        for(int i = 0; i < m_FruitTgls.Length; i++)
        {
            if (m_FruitTgls[i].isOn)
            {
                result += string.Format("<color=#FF7F00>{0}</color> ", fruits[i]);
                notSelected = false;
            }
        }

        result += "�Դϴ�.";

        if (notSelected)
            result = "������ ������ �����ϴ�.";

        return result;
    }
}
