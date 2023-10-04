using Palmmedia.ReportGenerator.Core.Reporting.Builders.Rendering;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Test013Dlg : MonoBehaviour
{
    [SerializeField] ScrollRect m_CityScroll = null;
    [SerializeField] Text m_ResultTxt = null;
    [SerializeField] Button m_ResultBtn = null;
    [SerializeField] Button m_ClearBtn = null;
    [SerializeField] GameObject m_CityItem = null;
    [SerializeField] string[] m_CityNames = null;

    List<CityItem> m_CityItems = new List<CityItem>();
    CityItem curItem = null;

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

        m_ResultBtn.onClick.AddListener(OnClicked_Result);
        m_ClearBtn.onClick.AddListener(OnClicked_Clear);
    }

    void OnClicked_Result()
    {
        if(curItem != null)
        {
            m_ResultTxt.text = string.Format("당신이 선택한 도시는 <color=#8a2be2>{0}</color> 입니다.", curItem.cityName);
        }
        else
        {
            m_ResultTxt.text = "도시를 선택하세요.";
        }
    }

    void OnClicked_Clear()
    {
        curItem.UnSelected();
        curItem = null;
        m_ResultTxt.text = "초기화되었습니다.";
    }

    void OnClicked_Item(CityItem kItem)
    {
        if (curItem != null)
            curItem.UnSelected();
        curItem = kItem;
        curItem.Selected();

        m_ResultTxt.text = curItem.cityName;
    }

    void CreateItem(int idx)
    {
        GameObject go = Instantiate(m_CityItem, m_CityScroll.content);

        CityItem kItem = go.GetComponent<CityItem>();
        kItem.Initialize(m_CityNames[idx]);

        Button btn = kItem.m_CityBtn;
        btn.onClick.AddListener(() =>
        {
            OnClicked_Item(kItem);
        });

        m_CityItems.Add(kItem);
    }

    private void OnDestroy()
    {
        for(int i= 0; i < m_CityItems.Count; i++)
        {
            Destroy(m_CityItems[i].gameObject);
        }
    }
}
