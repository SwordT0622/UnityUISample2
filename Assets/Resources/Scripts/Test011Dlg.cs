using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test011Dlg : MonoBehaviour
{
    [SerializeField] ScrollRect m_CityScroll = null;
    [SerializeField] Button m_StartBtn = null;
    [SerializeField] Button m_ClearBtn = null;
    [SerializeField] Text m_ResultTxt = null;
    [SerializeField] GameObject m_CityItem = null;

    [SerializeField] string[] m_CityNames = null;
    List<CityItem> m_CityItems = new List<CityItem>();
    CityItem selectedItem = null;

    private void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        for(int i = 0; i < m_CityNames.Length; i++)
        {
            CreateItem(i);
        }

        m_StartBtn.onClick.AddListener(OnClicked_Start);
        m_ClearBtn.onClick.AddListener(OnClicked_Clear);
    }

    void OnClicked_Start()
    {
        if(selectedItem == null)
        {
            m_ResultTxt.text = "���ø� �������ּ���";
            return;
        }

        m_ResultTxt.text = string.Format("����� ������ ���ô� <color=#8a2be2>{0}</color> �Դϴ�.", selectedItem.cityName);
    }

    void OnClicked_Clear()
    {
        selectedItem.UnSelected();
        selectedItem = null;
        m_ResultTxt.text = "�ʱ�ȭ�Ǿ����ϴ�.";
    }

    void OnClicked_Item(CityItem kItem)
    {
        if (selectedItem != null)
            selectedItem.UnSelected();
        selectedItem = kItem;
        selectedItem.Selected();

        m_ResultTxt.text = selectedItem.cityName;
    }

    void CreateItem(int i)
    {
        GameObject go = Instantiate(m_CityItem, m_CityScroll.content);
        CityItem kItem = go.GetComponent<CityItem>();
        kItem.Initialize(m_CityNames[i]);

        Button btn = kItem.m_CityBtn;
        btn.onClick.AddListener(() =>
        {
            OnClicked_Item(kItem);
        });
    }

    private void OnDestroy()
    {
        for(int i = 0; i < m_CityItems.Count; i++)
        {
            if (m_CityItems[i] != null)
                Destroy(m_CityItems[i].gameObject);
        }
    }
}
