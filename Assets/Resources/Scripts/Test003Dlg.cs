using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test003Dlg : MonoBehaviour
{
    [SerializeField] Toggle[] m_FruitTgls = null;
    [SerializeField] Text m_ResultTxt = null;
    [SerializeField] Button m_StartBtn = null;
    [SerializeField] Button m_ClearBtn = null;

    List<string> fruits = new List<string>();
    string selectedFruit = null;

    private void Start()
    {
        m_StartBtn.onClick.AddListener(OnClicked_Start);
        m_ClearBtn.onClick.AddListener(OnClicked_Clear);

        for(int i = 0; i < m_FruitTgls.Length; i++)
        {
            int idx = i;
            m_FruitTgls[i].onValueChanged.AddListener((bool isOn) =>
            {
                OnValueChanged_Fruit(isOn, idx);
            });

            string fruit = m_FruitTgls[i].GetComponentInChildren<Text>().text;
            fruits.Add(fruit);

            if (selectedFruit == null)
                selectedFruit = fruit;
        }
    }

    void OnValueChanged_Fruit(bool isOn, int idx)
    {
        if(isOn)
        {
            selectedFruit = fruits[idx];
            m_ResultTxt.text = fruits[idx];
        }
    }

    void OnClicked_Start()
    {
        m_ResultTxt.text = GetResult();
    }

    void OnClicked_Clear()
    {
        m_FruitTgls[0].isOn = true;
        m_ResultTxt.text = "�ʱ�ȭ�Ǿ����ϴ�.";
    }

    string GetResult()
    {
        string result = string.Format("����� �� ������ <color=#FF7F00>{0}</color> �Դϴ�.", selectedFruit);
        return result;
    }
}
